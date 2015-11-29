using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using MvcPrototype.DAL.Interfaces;
using MvcPrototype.Models;

namespace MvcPrototype.DAL
{
    class ArticleContext : DbContext, IArticleContext
    {
        public DbSet<Article> Articles { get; set; }

        public new DbEntityEntry<Article> Entry(Article entity)
        {
            return Entry(entity);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
