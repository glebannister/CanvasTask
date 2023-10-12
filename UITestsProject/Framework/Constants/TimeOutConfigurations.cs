using Framework.Helpers;

namespace Framework.Constants
{
    public static class TimeOutConfigurations
    {
        public static double DefaultRetryForTimeout => _appSettingsHelper.GetConfigurationOnlyFileValue<double>("DefaulConditionWaitTime");

        public static double DefaultIntervalTimeout => _appSettingsHelper.GetConfigurationOnlyFileValue<double>("DefaultInterval");

        public static double SearchForElementTimeout => _appSettingsHelper.GetConfigurationOnlyFileValue<double>("DefaulTimeoutForFindingElement");
        private static AppSettingsHelper _appSettingsHelper = new AppSettingsHelper();
    }
}
