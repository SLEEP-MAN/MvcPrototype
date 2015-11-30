using System;
using System.Collections.Generic;
using System.Linq;
using MvcPrototype.DAL.Interfaces.Repositories;
using MvcPrototype.Models;

namespace MvcPrototype.DAL.Fake.Repositories
{
    public class ArticleRepository : IArticleRepository, IDisposable
    {
        List<Article> _articles;

        public ArticleRepository()
        {
            _articles = new List<Article>()
            {
                new Article() { Id = 1, Name = "Test_ABS", Price = 13.666 },
                new Article() { Id = 2, Name = "Testing!!!", Price = 6.9 }
            };
        }

        public IEnumerable<Article> GetArticles()
        {
            return _articles;
        }

        public Article GetArticletByID(int articleId)
        {
            return _articles.Where(x => x.Id == articleId).FirstOrDefault();
        }

        public void InsertArticle(Article article)
        {
            _articles.Add(article);
        }

        public void UpdateArticle(Article article)
        {
        }

        public void DeleteArticle(int articleID)
        {
        }

        public void Save()
        {
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
