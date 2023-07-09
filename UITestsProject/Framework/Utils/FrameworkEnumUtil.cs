namespace Framework.Utils
{
    public static class FrameworkEnumUtil
    {
        public static T ConvertStringToEnum<T>(string value) where T : Enum 
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
