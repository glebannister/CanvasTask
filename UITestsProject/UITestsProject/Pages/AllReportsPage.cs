using Framework.Elements.Classes;
using Framework.Page;
using OpenQA.Selenium;

namespace UITestsProject.Pages
{
    public class AllReportsPage : BaseWebPage
    {
        private WebTextField FilterReportsTextField => new WebTextField(By.Id("filter_text"), "Filter text field");
        private WebLabel NameTebleLabel => new WebLabel(By.XPath("//div[@class='listColHeadInner']//div[text()='Name']"), "Name table column");
        private WebLabel SpesificProject(string reportName) => new WebLabel(By.XPath($"//a[text()='{reportName}']"), "All reports web table");

        public AllReportsPage() 
            : base(new WebLabel(By.XPath("//span[text()='Reports']"), "Reports label"), "All reports Page")
        {
        }

        public bool IsReportExistsInTheTable(string reportName)
        {
            FilterReportsTextField.SetText(reportName);
            FilterReportsTextField.Click();
            NameTebleLabel.Click();
            return SpesificProject(reportName).IsElementDisplayed();
        }

        public void ClickOnSpesificProject(string reportName) => SpesificProject(reportName).Click();
    }
}
