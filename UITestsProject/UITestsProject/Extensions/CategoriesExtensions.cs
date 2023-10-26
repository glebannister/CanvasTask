using UITestsProject.Configuration.Constants.TestDataConstants;
using UITestsProject.Configuration.Constants.TestProjectConstants;

namespace UITestsProject.Extensions
{
    public static class CategoriesExtensions
    {
        public static string NormoizeCategoriesValue(this string str)
        {
            return str
                .RemoveAllSpaces().Replace(TestDataConstants.CategoryValue, string.Empty)
                .Replace(SymbolConstants.SlashR, string.Empty)
                .Replace(SymbolConstants.SlashN, string.Empty);
        }
    }
}
