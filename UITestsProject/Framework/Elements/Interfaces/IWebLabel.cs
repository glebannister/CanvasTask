using Framework.Enums;

namespace Framework.Elements.Interfaces
{
    internal interface IWebLabel : IBaseWebElement
    {
        public List<string> GetTextsFromLabels(ElementState elementState);
    }
}
