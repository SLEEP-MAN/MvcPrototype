using System;
using System.Collections.Generic;
using MvcPrototype.DAL.Interfaces.Repositories;
using MvcPrototype.DAL.Interfaces;
using MvcPrototype.Models;
using System.Data.Entity;
using System.Linq;

namespace MvcPrototype.DAL.Repositories
{
    public class ArticleRepository : IArticleRepository, IDisposable
    {
        private IArticleContext _articleContext;
        private bool disposed = false;

        public ArticleRepository(IArticleContext applicationContext)
        {
            if (applicationContext == null)
                throw (new ArgumentNullException("applicationContext"));

            _articleContext = applicationContext;
        }

        public IEnumerable<Article> GetArticles()
        {
            return _articleContext.Articles.ToList();
        }

        public Article GetArticletByID(int articleId)
        {
            return _articleContext.Articles.Find(articleId);
        }

        public void InsertArticle(Article article)
        {
            _articleContext.Articles.Add(article);
        }

        public void UpdateArticle(Article article)
        {
            _articleContext.Entry(article).State = EntityState.Modified;
        }

        public void DeleteArticle(int articleID)
        {
            Article article = _articleContext.Articles.Find(articleID);
            _articleContext.Articles.Remove(article);
        }

        public void Save()
        {
            _articleContext.SaveChanges();
        }
        

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _articleContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
