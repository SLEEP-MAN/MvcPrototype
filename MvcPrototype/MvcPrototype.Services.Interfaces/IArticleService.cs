using System.Collections.Generic;
using MvcPrototype.Models;

namespace MvcPrototype.Services.Interfaces
{
    public interface IArticleService : IService
    {
        IEnumerable<Article> GetArticles();
    }
}
