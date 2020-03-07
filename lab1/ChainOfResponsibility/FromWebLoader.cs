using System.Text.RegularExpressions;

namespace Patterns.ChainOfResponsibility
{
    public class FromWebLoader:AbstractLoader
    {
        private const string PatternWeb =
            @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$";

        public override object Handle(string path)
        {
            if (Regex.IsMatch(path, PatternWeb))
            {
                var proxy = new HtmlStoreProxy();
                return proxy.GetMyHtmlModel(path).Result;
            }
            return base.Handle(path);
        }
    }
}
