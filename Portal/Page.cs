using System.Collections.Generic;
namespace Portal.Articles
{
    public class Page
    {
        public Article Article { get; protected set; }
        public Page(
            List<string> keyWords,
            string name)
        {
            KeyWords = keyWords;
            UrlName = name;
        }
        public List<string> KeyWords { get; protected set; }
        public string UrlName { get; protected set; }
    }
}
