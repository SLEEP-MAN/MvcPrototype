using System.Collections.Generic;
using MvcPrototype.Models;

namespace MvcPrototype.DAL.Interfaces.Repositories
{
    public interface IArticleRepository : IRepository
    {
        IEnumerable<Article> GetArticles();
        Article GetArticletByID(int articleId);
        void InsertArticle(Article article);
        void DeleteArticle(int articleID);
        void UpdateArticle(Article article);
        void Save();
    }
}
