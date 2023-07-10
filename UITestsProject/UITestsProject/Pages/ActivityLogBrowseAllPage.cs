using Framework.Application;
using Framework.Elements;
using Framework.Page;
using OpenQA.Selenium;

namespace UITestsProject.Pages
{
    public class ActivityLogBrowseAllPage : BaseWebPage
    {
        private WebButton ActionsButton => new WebButton(By.XPath("//div[@class='inline-elt']//span"), "Actions button");
        private WebButton DeleteButton => new WebButton(By.XPath("//div[text()='Delete']"), "Delete button");

        public ActivityLogBrowseAllPage() 
            : base(new WebLabel(By.XPath("//span[text()='Activity Log']"), "Activity log label"), "Activity log browse all page")
        {
        }

        public void DeleteFirstItemsFormTheTable() 
        {
            ActionsButton.Click();
            DeleteButton.Click();
            BrowserManager.AcceptAlert();
        }
    }
}
