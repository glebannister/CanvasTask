using UITestsProject.Constants;

namespace UITestsProject.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveAllSpaces(this string str) 
        {
            return str.Replace(" ", string.Empty);
        }

        public static string NormoizeCategoriesValue(this string str) 
        {
            return str
                .RemoveAllSpaces().Replace(TestDataConstants.CategoryValue, string.Empty)
                .Replace(SymbolConstants.SlashR, string.Empty)
                .Replace(SymbolConstants.SlashN, string.Empty);
        }
    }
}
