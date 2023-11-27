namespace Framework.Elements.Interfaces
{
    public interface IWebTextField : IBaseWebElement
    {
        public void ClearText();
        public void SetText(string text);
    }
}
