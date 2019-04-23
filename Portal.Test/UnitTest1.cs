using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Portal.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ArticleIsSavedToDb()
        {
            var system = new PortalSystem();
            Article articleCreated = null;
            try
            {
                articleCreated = system.ArticleSet(new Article(id: 0, title: "Test 1", content: "Content 2"));
                var article = system.ArticleGet(new Article(id: articleCreated.Id, title: null, content: null));
                Assert.IsNotNull(article);
                Assert.AreEqual(article.Id,articleCreated.Id);
            }

            finally
            {
                system.ArticleDelete(articleCreated);
            }
        }
    }
}
