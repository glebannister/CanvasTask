using Framework.Application;
using NUnit.Framework;

namespace UITestsProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            BrowserManager.NavigateToUrl("https://demo.1crmcloud.com");
        }
    }
}