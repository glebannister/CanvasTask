using Framework.Elements;
using Framework.Page;
using OpenQA.Selenium;

namespace UITestsProject.Pages
{
    public class CreatedContactPage : BaseWebPage
    {
        public CreatedContactPage() 
            : base(new WebLabel(By.XPath("//div[@class='buttons-inline']"), "Inline buttons"), "Created contact page")
        {
        }
    }
}
