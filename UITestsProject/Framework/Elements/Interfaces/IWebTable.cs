namespace Framework.Elements.Interfaces
{
    public interface IWebTable : IBaseWebElement
    {
        public IEnumerable<string> GetColumnValues(string columnName);
        public string GetColumnValue(int rowNumber, string columnName);
        public int GetRowsCount();
        public int FindColumnIndexByName(string columnName);
    }
}
