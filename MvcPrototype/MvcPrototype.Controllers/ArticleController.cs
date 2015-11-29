using System.Web.Mvc;
using MvcPrototype.DAL.Interfaces.Repositories;

namespace MvcPrototype.Controllers
{
    class ArticleController : Controller
    {
        private IArticleRepository _articleRepository;

        public ArticleController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
    }
}
