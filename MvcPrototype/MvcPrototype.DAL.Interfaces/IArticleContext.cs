using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MvcPrototype.Models;

namespace MvcPrototype.DAL.Interfaces
{
    public interface IArticleContext : IDbContext
    {
        DbSet<Article> Articles { get; set; }
        DbEntityEntry<Article> Entry(Article entity);
    }
}
