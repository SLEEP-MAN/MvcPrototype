using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using MvcPrototype.DAL.Interfaces.Repositories;
using MvcPrototype.Models;
using MvcPrototype.Services.Interfaces;

namespace MvcPrototype.Services
{
    public class ArticleService : IArticleService
    {
        private ILog _logger;
        private IArticleRepository _articleRepository;

        public ArticleService(ILog logger, IArticleRepository articleRepository)
        {
            _logger = logger;
            _articleRepository = articleRepository;
        }

        public IEnumerable<Article> GetArticles()
        {
            return _articleRepository.GetArticles().ToList();
        }

        public Article GetArticleById(int id)
        {
            return _articleRepository.GetArticletByID(id);
        }

        public void InsertArticle(Article article)
        {
            _articleRepository.InsertArticle(article);
            _logger.Info("Article inserted: " + article.ToString());
        }

        public void UpdateArticle(Article article)
        {
            _articleRepository.UpdateArticle(article);
            _logger.Info("Article updated: " + article.ToString());
        }

        public void Save()
        {
            _articleRepository.Save();
        }

        public void DeleteArticle(int id)
        {
            Article article = _articleRepository.GetArticletByID(id);
            _articleRepository.DeleteArticle(id);
            _logger.Info("Article updated: " + article.ToString());
        }
    }
}
