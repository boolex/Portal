using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Portal.Articles;
using Portal.Web.Models;
namespace Portal.Web.Controllers
{
    public class ArticleController : Controller
    {
        [HttpGet]
        public ActionResult New(int id = 0)
        {
            return View(new ArticlePageViewModel(Fetch(new Article(id: id, title: null, content: null))));
        }
        [HttpPost]
        public ActionResult New(ArticlePageViewModel viewModel)
        {
            Article article = null;
            using (PortalContext context = new PortalContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (viewModel.Id.HasValue)
                        {
                            article = context.Articles.FirstOrDefault(x => x.Id == viewModel.Id.Value);
                            article.Title = viewModel.Title;
                            article.Content = viewModel.Content;
                            context.SaveChanges();
                        }
                        else
                        {
                            article = context.Articles.Add(viewModel.Article());
                            context.SaveChanges();
                        }
                       // context.ArticlePages.Add(viewModel.Page());
                       
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }
            return View(new ArticlePageViewModel(article: article));
        }
        [HttpGet]
        public ActionResult Index()
        {
            using (PortalContext context = new PortalContext())
            {
                return View(new ArticleCatalogViewModel()
                {
                    Articles = context.Articles.ToList<Article>()
                });
            }
        }
        private Article Fetch(Article article)
        {
            if (article == null || article.Id == 0)
            {
                return new Article();
            }
            using (PortalContext context = new PortalContext())
            {
                return context.Articles.FirstOrDefault(x => x.Id == article.Id);
            }
        }
    }
}
