using System;
using System.Collections.Generic;
using System.Linq;
using MvcPrototype.DAL.Interfaces.Repositories;
using MvcPrototype.Models;
using MvcPrototype.Services.Interfaces;

namespace MvcPrototype.Services
{
    public class ArticleService : IArticleService
    {
        private IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
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
        }

        public void UpdateArticle(Article article)
        {
            _articleRepository.UpdateArticle(article);
        }

        public void Save()
        {
            _articleRepository.Save();
        }

        public void DeleteArticle(int id)
        {
            _articleRepository.DeleteArticle(id);
        }
    }
}
