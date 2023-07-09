namespace UITestsProject.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveAllSpaces(this string str) 
        {
            return str.Replace(" ", string.Empty);
        }
    }
}
