namespace Framework.Utils
{
    public static class EnvironmentVariablesUtil
    {
        public static string GetEnvironmentVariableFromAllTargets(string name) 
        {
            List<string> values = new List<string>
            {
                Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process),
                Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Machine),
                Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User)
            };
            return values.FirstOrDefault(value => value != string.Empty);
        }
    }
}
