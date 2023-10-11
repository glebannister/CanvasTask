using Framework.Utils;

namespace Framework.Constants
{
    public static class TimeOutConfigurations
    {
        public static double DefaultRetryForTimeout => new AppSettings().GetConfigurationOnlyFileValue<double>("DefaulConditionWaitTime");

        public static double DefaultIntervalTimeout => new AppSettings().GetConfigurationOnlyFileValue<double>("DefaultInterval");

        public static double SearchForElementTimeout => new AppSettings().GetConfigurationOnlyFileValue<double>("DefaulTimeoutForFindingElement");
    }
}
