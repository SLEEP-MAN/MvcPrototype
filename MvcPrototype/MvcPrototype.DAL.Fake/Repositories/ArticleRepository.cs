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
            article.Id = _articles.Select(x => x.Id).Max() + 1;
            _articles.Add(article);
        }

        public void UpdateArticle(Article article)
        {
            _articles.First(x => x.Id == article.Id).Name = article.Name;
            _articles.First(x => x.Id == article.Id).Description = article.Description;
            _articles.First(x => x.Id == article.Id).Price = article.Price;
        }

        public void DeleteArticle(int articleID)
        {
            _articles.Remove(_articles.First(x => x.Id == articleID));
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
