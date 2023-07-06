namespace Framework.Utils
{
    internal static class EnumUtil
    {
        public static T ConvertStringToEnum<T>(string value) where T : Enum 
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
