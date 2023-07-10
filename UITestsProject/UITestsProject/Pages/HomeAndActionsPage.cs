using Framework.Elements;
using Framework.Page;
using Framework.Waits;
using OpenQA.Selenium;
using UITestsProject.Constants;
using UITestsProject.Extensions;

namespace UITestsProject.Pages
{
    public class HomeAndActionsPage : BaseWebPage
    {
        private WebButton SalesAndMarketingButton => new WebButton(By.XPath("//a[contains(@class, 'mouseonly') and contains(@class, 'menu-tab') and contains(@class, 'sales-marketing')]"), "Sales&Marketing button");
        private WebButton ReportsAndSettingsButton => new WebButton(By.XPath("//a[contains(@class, 'mouseonly') and contains(@class, 'menu-tab') and contains(@class, 'reports-settings')]"), "Report$Settings button");
        private WebContainer NavigationWebContainer = new WebContainer(By.XPath("//div[@class='tab-nav-sub']//a[@class='menu-tab-sub-list']"), "Navigation container");


        public HomeAndActionsPage()
            : base(new WebLabel(By.XPath("//div[@class='main-title']//span[text()='Home Dashboard']"), "Home Dashboard label"),
                  "Home And Actions Page")
        {
        }

        public void ClickOnItemInSalesAndMarketingContainer(string itemName) 
        {
            SalesAndMarketingButton.Focus();
            ClickOnSpesificItem(itemName);
        }

        public void ClickOnItemInReportsSettingsContainer(string itemName) 
        {
            ReportsAndSettingsButton.Focus();
            ClickOnSpesificItem(itemName);
        }

        private void ClickOnSpesificItem(string itemName) 
        {
            ExplicitWait.WaitForCondition(() =>
                NavigationWebContainer.IsElementExist(),
                TimeSpan.FromSeconds(Timeouts.DefaulConditionWaitTime));
            NavigationWebContainer.ClickElementByHrefContains(itemName.RemoveAllSpaces());
        }
    }
}
