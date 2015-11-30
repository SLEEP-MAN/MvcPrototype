using System.Web.Mvc;
using MvcPrototype.Models;
using MvcPrototype.Services.Interfaces;
using PagedList;

namespace MvcPrototype.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleService _articleService;
        
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        //
        // GET: /Article/
        public ViewResult Index(int? page)
        {
            var articles = _articleService.GetArticles();
            
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(articles.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Article/Details/5

        public ViewResult Details(int id)
        {
            Article student = _articleService.GetArticleById(id);
            return View(student);
        }

    }
}
