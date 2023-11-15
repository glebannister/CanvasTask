using System.Diagnostics;

namespace Framework.Utils
{
    public static class ProcessUtil
    {
        public static void RunProcess(ProcessStartInfo startInfo) 
        {
            var process = new Process
            {
                StartInfo = startInfo
            };
            process.Start();
        }
    }
}
