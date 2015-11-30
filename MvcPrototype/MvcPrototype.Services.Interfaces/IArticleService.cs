using System.Collections.Generic;
using MvcPrototype.Models;

namespace MvcPrototype.Services.Interfaces
{
    public interface IArticleService : IService
    {
        IEnumerable<Article> GetArticles();
        Article GetArticleById(int id);
        void InsertArticle(Article article);
        void UpdateArticle(Article article);
        void DeleteArticle(int id);
        void Save();
    }
}
