using Framework.Application;
using Framework.Constants;
using Framework.Elements;
using Framework.Enums;
using Framework.Page;
using OpenQA.Selenium;

namespace UITestsProject.Pages
{
    internal class ActivityLogBrowseAllPage : BaseWebPage
    {
        private WebButton ActionsButton => new WebButton(By.XPath("//div[@class='inline-elt']//span"), "Actions button");
        private WebButton DeleteButton => new WebButton(By.XPath("//div[text()='Delete']"), "Delete button");
        private WebLabel ActivitiesNamesLabels = new WebLabel(By.XPath("//td//span[@class='detailLink']//a[@class='listViewExtLink']"), "Activilies names labels");
        private WebCheckBox SelectActivitiesCheckBoxes => new WebCheckBox(By.XPath("//td//input[@type='checkbox']"), "Select activities check boxes", ElementState.ExistsInAnyState);
        private WebLabel SpesificActivityLabel(string activityName) => new WebLabel(By.XPath($"//td//span[@class='detailLink']//a[@class='listViewExtLink' and text()='{activityName}']"), $"{activityName} label", ElementState.ExistsInAnyState);

        public ActivityLogBrowseAllPage() 
            : base(new WebLabel(By.XPath("//span[text()='Activity Log']"), "Activity log label"), "Activity log browse all page")
        {
        }

        public List<string> GetItemsToDeleteNames(int amountOfItemsToDetele) 
        {
            return ActivitiesNamesLabels
                .GetTextsFromLabels()
                .Take(amountOfItemsToDetele)
                .ToList();
        }

        public void DeleteFirstItemsFormTheTable(int amountOfItems) 
        {
            SelectActivitiesCheckBoxes.SetCheckBoxesValues(amountOfItems, true);
            ActionsButton.Click();
            DeleteButton.Click();
            BrowserManager.AcceptAlert();
        }

        public bool IsSpesificActivityNotExist(string activityName) 
        {
            return BrowserManager
                .ExplicitWaits()
                .WaitForCondition(() => !SpesificActivityLabel(activityName).IsElementExists(), TimeSpan.FromSeconds(BaseConfigurations.DefaultRetryForTimeout));
        }
    }
}
