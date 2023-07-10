using Framework.Elements;
using Framework.Page;
using Framework.Waits;
using OpenQA.Selenium;
using UITestsProject.Constants;

namespace UITestsProject.Pages
{
    public class HomeAndActionsPage : BaseWebPage
    {
        private WebButton SalesAndMarketingButton = new WebButton(By.XPath("//a[contains(@class, 'mouseonly') and contains(@class, 'menu-tab') and contains(@class, 'sales-marketing')]"), "Sales&Marketing button");
        private WebContainer SalesAndMarketingWebContainer = new WebContainer(
            By.XPath("//div[@class='tab-nav-sub']//a[@class='menu-tab-sub-list']"), "SalesAndMarketing container");


        public HomeAndActionsPage()
            : base(new WebLabel(By.XPath("//div[@class='main-title']//span[text()='Home Dashboard']"), "Home Dashboard label"),
                  "Home And Actions Page")
        {
        }

        public void ClickOnItemInSalesAndMarketingContainer(string itemName) 
        {
            SalesAndMarketingButton.Focus();
            ExplicitWait.WaitForCondition(() => 
                SalesAndMarketingWebContainer.IsElementExist(),
                TimeSpan.FromSeconds(Timeouts.DefaulConditionWaitTime));
            SalesAndMarketingWebContainer.ClickElementByHrefContains(itemName);
        }
    }
}
