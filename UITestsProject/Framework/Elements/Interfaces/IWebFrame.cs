namespace Framework.Elements.Interfaces
{
    public interface IWebFrame : IBaseWebElement
    {
        public void DoInFrame(Action action);
        public T DoInFrame<T>(Func<T> func);
        public void DoInFrameIfPresent(Action action);
        public T DoInFrameIfPresent<T>(Func<T> func);
    }
}
