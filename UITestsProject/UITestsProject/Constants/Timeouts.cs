using Framework.Utils;

namespace UITestsProject.Constants
{
    internal static class Timeouts
    {
        public static readonly double DefaulConditionWaitTime = FrameworkJsonUtil.GetValueFromAppettingsFile<double>(KeyForDefaultFindElementTimeout);
        private const string KeyForDefaultFindElementTimeout = "DefaulTimeoutForFindingElement";
    }
}
