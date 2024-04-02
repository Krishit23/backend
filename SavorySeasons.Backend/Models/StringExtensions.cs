namespace SavorySeasons.Backend.Models
{
    public static class StringExtensions
    {
        public static bool IsNotBlank(this string value)
        {
            return !value.IsBlank();
        }

        public static bool IsBlank(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}
