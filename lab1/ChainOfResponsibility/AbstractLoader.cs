namespace Patterns.ChainOfResponsibility
{
    public class AbstractLoader : ILoader
    {
        private ILoader _nextLoader;
        public ILoader SetNext(ILoader loader)
        {
            _nextLoader = loader;
            return loader;
        }

        public virtual object Handle(string path)
            => _nextLoader != null ? _nextLoader.Handle(path) : null;

    }
}
