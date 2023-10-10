namespace UITestsProject.Extensions
{
    internal static class StringExtensions
    {
        public static string RemoveAllSpaces(this string str) 
        {
            return str.Replace(" ", string.Empty);
        }
    }
}
