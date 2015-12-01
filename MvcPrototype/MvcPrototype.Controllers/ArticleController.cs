using System.Data;
using System.Web.Mvc;
using Common.Logging;
using FluentValidation.Results;
using MvcPrototype.Models;
using MvcPrototype.Services.Interfaces;
using MvcValidation.Validators;
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
            Article article = _articleService.GetArticleById(id);
            return View(article);
        }

        //
        // GET: /Article/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Article/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name, Description, Price")]Article article)
        {
            ArticleValidator validator = new ArticleValidator();
            ValidationResult result = validator.Validate(article);
            if (result.IsValid)
            {
                _articleService.InsertArticle(article);
                _articleService.Save();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (ValidationFailure failer in result.Errors)
                {
                    ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
                }
                return View(article);
            }
        }

        //
        // GET: /Article/Edit/5
        public ActionResult Edit(int id)
        {
            Article article = _articleService.GetArticleById(id);
            return View(article);
        }

        //
        // POST: /Article/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Description, Price")]Article article)
        {
            ArticleValidator validator = new ArticleValidator();
            ValidationResult result = validator.Validate(article);
            if (result.IsValid)
            {
                _articleService.UpdateArticle(article);
                _articleService.Save();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (ValidationFailure failer in result.Errors)
                {
                    ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
                }
                return View(article);
            }
        }

        //
        // GET: /Article/Delete/5
        public ActionResult Delete(bool? saveChangesError = false, int id = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Article article = _articleService.GetArticleById(id);
            return View(article);
        }

        //
        // POST: /Article/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Article article = _articleService.GetArticleById(id);
                _articleService.DeleteArticle(id);
                _articleService.Save();
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
    }
}
