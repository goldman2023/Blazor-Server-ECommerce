using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;

namespace QuickTie.Portal.Extensions
{
    public static class ReflectionExtensions
    {
        public static string GetEnumDisplayName(this Enum enumValue)
        {
            string displayName = enumValue.GetType()
                                   .GetMember(enumValue.ToString())
                                   .FirstOrDefault()
                                   .GetCustomAttribute<DisplayAttribute>()?
                                   .GetName();
            if (String.IsNullOrEmpty(displayName))
            {
                displayName = enumValue.ToString();
            }
            return displayName;
        }

        public static string HighlightText(this string sourceText, string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                return sourceText;
            }

            string highlightedText = Regex.Replace(sourceText, searchText, match => $"<span class='highlight'>{match.Value}</span>", RegexOptions.IgnoreCase);

            return highlightedText;
        }
    }
}
