using Framework.Constants;
using Framework.Enums;
using Framework.Logging;
using Framework.Waits;
using OpenQA.Selenium;

namespace Framework.Elements
{
    public class WebLabel : BaseWebUiElement
    {
        public WebLabel(By locator, string elementName, ElementState elementState = ElementState.Displayed) 
            : base(locator, elementName, elementState)
        {
        }

        public List<string> GetTextsFromLabels(ElementState elementState = ElementState.Displayed) 
        {
            FrameworkLogger.Info($"Getting texts from label by Locator[{Locator}] and Name {ElementName}");
            var listOfTexts = new List<string>();
            ExplicitWait.WaitForCondition(() =>
            {
                try
                {
                    listOfTexts = GetWebElements()
                        .Select(label => label.Text)
                        .ToList();
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    ReFindWebElements(elementState);
                    return false;
                }
            }, TimeSpan.FromSeconds(TimeOutConfigurations.DefaultRetryForTimeout));
            return listOfTexts;
        }
    }
}
