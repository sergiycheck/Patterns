namespace Patterns.ChainOfResponsibility
{
    public interface ILoader
    {
        ILoader SetNext(ILoader loader);
        object Handle(string path);
    }
}
