namespace QuickTie.Portal.Extensions
{
    public static class RegularExpressions
    {
        public const string Email = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        public const string ZipCode = @"^\d{5}(-\d{4})?$";

        public const string CardNumber = @"^\d{4} \d{4} \d{4} \d{1,4}$";
        public const string ExpirationDate = @"^(0[1-9]|1[0-2])\/\d{2,4}$";
        public const string SecurityCode = @"^\d{4}$";
    }
}
