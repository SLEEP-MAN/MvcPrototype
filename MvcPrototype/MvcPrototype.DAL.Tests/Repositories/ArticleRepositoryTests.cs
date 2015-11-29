using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcPrototype.DAL.Interfaces;
using MvcPrototype.DAL.Interfaces.Repositories;
using MvcPrototype.DAL.Repositories;
using MvcPrototype.Models;

namespace MvcPrototype.DAL.Tests.Repositories
{
    [TestClass]
    public class ArticleRepositoryTests
    {
        Mock<DbSet<Article>> setMock;
        Mock<IArticleContext> articleContextMock;
        IArticleRepository sut;

        [TestInitialize]
        public void Setup()
        {
            setMock = new Mock<DbSet<Article>>();

            articleContextMock = new Mock<IArticleContext>();
            articleContextMock.Setup(m => m.Articles).Returns(setMock.Object);

            sut = new ArticleRepository(articleContextMock.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            setMock = null;
            articleContextMock = null;
            sut = null;
        }

        [TestMethod]
        public void GetArticles_WhenRepositoryIsEmpty_ShouldReturnEmptyList()
        {
            var data = new List<Article>
            {}.AsQueryable();

            setMock.As<IQueryable<Article>>().Setup(m => m.Provider).Returns(data.Provider);
            setMock.As<IQueryable<Article>>().Setup(m => m.Expression).Returns(data.Expression);
            setMock.As<IQueryable<Article>>().Setup(m => m.ElementType).Returns(data.ElementType);
            setMock.As<IQueryable<Article>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var articles = sut.GetArticles();

            Assert.AreEqual(0, articles.Count());

        }
    }
}
