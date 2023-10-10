using Framework.Constants;
using Framework.Enums;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.ComponentModel;

namespace Framework.Waits
{
    public class ExplicitWait
    {
        private IWebDriver _driver;

        public ExplicitWait(IWebDriver driver) 
        {
            _driver = driver;
        }

        public T WaitFor<T>(Func<IWebDriver, T> condition, TimeSpan? retryFor = null, TimeSpan? retryInterval = null, string message = null, IList<Type> exceptionsToIgnore = null)
        {
            var resolvedForTimeout = ResolveTimeoutValue(retryFor, TimeoutTypesEnum.RetryForTimeout);
            var resolvedRetryTimeout = ResolveTimeoutValue(retryInterval, TimeoutTypesEnum.RetryInterval);
            var wait = new WebDriverWait(_driver, resolvedForTimeout)
            {
                Message = message,
                PollingInterval = resolvedRetryTimeout
            };
            var ignoreExceptions = exceptionsToIgnore ?? new List<Type> { typeof(StaleElementReferenceException) };
            wait.IgnoreExceptionTypes(ignoreExceptions.ToArray());
            var result = wait.Until(condition);
            return result;
        }

        public static bool WaitForCondition(Func<bool> getMethod, TimeSpan? retryFor = null, TimeSpan? retryInterval = null)
        {
            var resolvedForTimeout = ResolveTimeoutValue(retryFor, TimeoutTypesEnum.RetryForTimeout);
            var resolvedRetryTimeout = ResolveTimeoutValue(retryInterval, TimeoutTypesEnum.RetryInterval);
            return For(getMethod, (bool g) => !g, resolvedForTimeout, resolvedRetryTimeout);
        }

        /// <summary>
        /// The method is recommended to use only in specific situations
        /// </summary>
        /// <returns></returns>
        public static void SleepWait(double timeout) 
        {
            Thread.Sleep((int)timeout * 1000);
        }

        private static T For<T>(Func<T> getMethod, Predicate<T> shouldRetry, TimeSpan retryFor, TimeSpan retryInterval)
        {
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
                    Thread.Sleep(retryInterval);
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

                Thread.Sleep(retryInterval);
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

        private static TimeSpan ResolveTimeoutValue(TimeSpan? timeSpan, TimeoutTypesEnum timeoutTypesEnum) 
        {
            switch (timeoutTypesEnum) 
            {
                case TimeoutTypesEnum.RetryForTimeout:
                    return (TimeSpan)(timeSpan != null
                        ? timeSpan
                        : TimeSpan.FromSeconds(TimeOutConfigurations.DefaultRetryForTimeout));
                case TimeoutTypesEnum.RetryInterval:
                    return (TimeSpan)(timeSpan != null
                        ? timeSpan
                        : TimeSpan.FromSeconds(TimeOutConfigurations.DefaultIntervalTimeout));
                default: throw new InvalidEnumArgumentException($"Timeout type {timeoutTypesEnum} hasn't been recognized");
            }
        }
    }
}
