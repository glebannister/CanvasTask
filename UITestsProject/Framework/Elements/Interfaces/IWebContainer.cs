namespace Framework.Elements.Interfaces
{
    public interface IWebContainer : IBaseWebElement
    {
        public void ClickElementByHrefContains(string text);
    }
}
