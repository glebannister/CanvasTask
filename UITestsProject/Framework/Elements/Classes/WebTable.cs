using Framework.Elements.Interfaces;
using Framework.Enums;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Framework.Elements.Classes
{
    public class WebTable : BaseWebUiElement, IWebTable
    {
        protected WebLabel RowLbl => new WebLabel(new ByChained(Locator, By.XPath("(//tbody)[1]//tr")), "RowLbl");
        protected WebLabel TableHeader => new WebLabel(new ByChained(Locator, By.XPath("//thead//th | .//thead//tr//td")), "Table header");
        protected WebLabel ColumnCell(int columnIndex) => new WebLabel(new ByChained(Locator, By.XPath($"//tbody//tr//td[{columnIndex}]")), "Table Cell");
        protected WebLabel ColumnCell(int rowNumber, int columnIndex) => new WebLabel(new ByChained(Locator, By.XPath($"//tbody//tr[{rowNumber}]//td[{columnIndex}]")), $"Table Cell");

        public WebTable(By locator, string elementName, ElementState elementState = ElementState.Displayed)
            : base(locator, elementName, elementState)
        {
        }

        public IEnumerable<string> GetColumnValues(string columnName)
        {
            var columnIndex = FindColumnIndexByName(columnName);
            return ColumnCell(columnIndex + 1).GetTexts();
        }

        public string GetColumnValue(int rowNumber, string columnName)
        {
            var columnIndex = FindColumnIndexByName(columnName);
            return ColumnCell(rowNumber, columnIndex + 1).GetText();
        }

        public int GetRowsCount() => RowLbl.GetNumberOfFoundElements();

        public int FindColumnIndexByName(string columnName)
        {
            var headers = TableHeader.GetTexts();
            var index = headers.FindIndex(header => header == columnName);
            return index == -1
                ? throw new Exception($"Failed to find '{columnName}' column index in table")
                : index;
        }
    }
}
