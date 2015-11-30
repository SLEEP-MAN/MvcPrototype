using System.Web.Mvc;
using MvcPrototype.DAL.Interfaces.Repositories;
using PagedList;

namespace MvcPrototype.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleRepository _articleRepository;
        
        public ArticleController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        //
        // GET: /Article/
        public ViewResult Index(int? page)
        {
            var articles = _articleRepository.GetArticles();
            
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(articles.ToPagedList(pageNumber, pageSize));
        }
    }
}
