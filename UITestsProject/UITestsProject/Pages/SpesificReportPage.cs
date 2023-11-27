using Framework.Constants;
using Framework.Elements;
using Framework.Page;
using Framework.Waits;
using OpenQA.Selenium;

namespace UITestsProject.Pages
{
    public class SpesificReportPage : BaseWebPage
    {
        private WebButton RunReportWebButton => new WebButton(By.XPath("//span[text()='Run Report']"), "Run report web button");
        private WebTable RunReportResultTable => new WebTable(By.XPath("//tr[@class='listViewRow oddListRowS1']"), "Run report result table");

        public SpesificReportPage() 
            : base(new WebLabel(By.XPath("//div[contains(@class, 'card-header') and contains(@class, 'form-header')]//h4[contains(text(),'Project Profitability')]"), "Project Profitability label"),
                  "Spesific project page")
        {
        }

        public void ClickRunReportButton() => RunReportWebButton.Click();

        public bool IsReportReturnedValues() 
        {
            return ExplicitWait.WaitForCondition(() =>
                    RunReportResultTable.IsElementExists(), TimeSpan.FromSeconds(TimeOutConfigurations.DefaultRetryForTimeout));
        }
    }
}
