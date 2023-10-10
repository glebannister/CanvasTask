using Framework.Application;
using Framework.Enums;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Reflection.Emit;

namespace Framework.Elements
{
    public class WebTable : BaseWebUiElement
    {
        protected WebLabel columnCell(int columnIndex) => new WebLabel(new ByChained(Locator, By.XPath($"//tbody//tr//td[{columnIndex}]")), $"Table Cell");
        protected WebLabel columnCell(int rowNumber, int columnIndex) => new WebLabel(new ByChained(Locator, By.XPath($"//tbody//tr[{rowNumber}]//td[{columnIndex}]")), $"Table Cell");
        protected WebLabel rowLbl => new WebLabel(new ByChained(Locator, By.XPath("(//tbody)[1]//tr")), "RowLbl");
        protected WebLabel tableHeader => new WebLabel(new ByChained(Locator, By.XPath($"//thead//th | .//thead//tr//td")), "Table header");

        public WebTable(By locator, string elementName, ElementState elementState = ElementState.Displayed) 
            : base(locator, elementName, elementState)
        {
        }

        public IEnumerable<string> GetColumnValues(string columnName)
        {
            var columnIndex = FindColumnIndexByName(columnName);
            return columnCell(columnIndex + 1).GetTexts();
        }

        public string GetColumnValue(int rowNumber, string columnName)
        {
            var columnIndex = FindColumnIndexByName(columnName);
            return columnCell(rowNumber, columnIndex + 1).GetText();
        }

        public int GetRowsCount() => rowLbl.GetNumberOfFoundElements();

        protected int FindColumnIndexByName(string columnName)
        {
            var headers = tableHeader.GetTexts().ToList();
            var index = headers.FindIndex(header => header == columnName);
            return index == -1 ? throw new Exception($"Failed to find '{columnName}' column index in table") : index;
        }
    }
}
