using Framework.Utils;

namespace Framework.Constants
{
    public static class TimeOutConfigurations
    {
        public static double DefaultRetryForTimeout => FrameworkJsonUtil.GetValueFromAppettingsFile<double>("DefaulConditionWaitTime");

        public static double DefaultIntervalTimeout => FrameworkJsonUtil.GetValueFromAppettingsFile<double>("DefaultInterval");

        public static double SearchForElementTimeout => FrameworkJsonUtil.GetValueFromAppettingsFile<double>("DefaulTimeoutForFindingElement");
    }
}
