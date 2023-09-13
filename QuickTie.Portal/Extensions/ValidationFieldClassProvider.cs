using Microsoft.AspNetCore.Components.Forms;

namespace QuickTie.Portal.Extensions
{
    public class ValidationFieldClassProvider : FieldCssClassProvider
    {
        public override string GetFieldCssClass(EditContext editContext,
            in FieldIdentifier fieldIdentifier)
        {
            var isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();

            return isValid ? "valid" : "invalid";
        }
    }
}
