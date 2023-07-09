using Framework.Utils;

namespace Framework.Waits
{
    public static class ExplicitWait
    {
        private const string DefaultIntervalKey = "DefaultInterval";

        public static bool WaitForCondition(Func<bool> getMethod, TimeSpan retryFor, TimeSpan? retryInterval = null)
        {
            return For(getMethod, (bool g) => !g, retryFor, retryInterval);
        }

        private static T For<T>(Func<T> getMethod, Predicate<T> shouldRetry, TimeSpan retryFor, TimeSpan? retryInterval = null)
        {
            var defaultRetryIntervalValue = FrameworkJsonUtil.GetValueFromAppettingsFile<double>(DefaultIntervalKey);
            DateTime now = DateTime.Now;
            while (DateTime.Now.Subtract(now).TotalMilliseconds < retryFor.TotalMilliseconds)
            {
                T val;
                try
                {
                    val = getMethod();
                }
                catch (Exception)
                {
                    Thread.Sleep(retryInterval ?? TimeSpan.FromSeconds(defaultRetryIntervalValue));
                    continue;
                }

                if (!typeof(T).IsValueType && val != null && !shouldRetry(val))
                {
                    return val;
                }

                if (typeof(T) == typeof(bool) && !shouldRetry(val))
                {
                    return val;
                }

                if (typeof(T) != typeof(bool) && !IsReferenceTypeAndIsNull(val) && !shouldRetry(val))
                {
                    return val;
                }

                Thread.Sleep(retryInterval ?? TimeSpan.FromSeconds(defaultRetryIntervalValue));
            }

            return getMethod();
        }

        private static bool IsReferenceTypeAndIsNull<T>(T element)
        {
            if (!typeof(T).IsValueType)
            {
                return element == null;
            }

            return false;
        }
    }
}
