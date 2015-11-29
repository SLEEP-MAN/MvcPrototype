using System;
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void ctor_WhenArticleContextIsNull_ShouldThrowArgumentNullException()
        {
            sut = new ArticleRepository(null);

            Assert.Fail("Should throw ArgumentNullException");
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
        
        [TestMethod]
        public void GetArticles_WhenRepositoryIsNotEmpty_ShouldReturnCorrectNumberOfElements()
        {
            var data = new List<Article>
            {
                new Article(),
                new Article()
            }.AsQueryable();

            setMock.As<IQueryable<Article>>().Setup(m => m.Provider).Returns(data.Provider);
            setMock.As<IQueryable<Article>>().Setup(m => m.Expression).Returns(data.Expression);
            setMock.As<IQueryable<Article>>().Setup(m => m.ElementType).Returns(data.ElementType);
            setMock.As<IQueryable<Article>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var articles = sut.GetArticles();

            Assert.AreEqual(2, articles.Count());
        }

        [TestMethod]
        public void GetArticles_WhenRepositoryIsNotEmpty_ShouldReturnElementsFromRepository()
        {
            Article art1 = new Article() { Id = 1, Name = "Test_ABS", Price = 13.666 };
            Article art2 = new Article() { Id = 2, Name = "Testing!!!", Price = 6.9 };

            var data = new List<Article>
            {
                art1,
                art2
            }.AsQueryable();

            setMock.As<IQueryable<Article>>().Setup(m => m.Provider).Returns(data.Provider);
            setMock.As<IQueryable<Article>>().Setup(m => m.Expression).Returns(data.Expression);
            setMock.As<IQueryable<Article>>().Setup(m => m.ElementType).Returns(data.ElementType);
            setMock.As<IQueryable<Article>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var articles = sut.GetArticles();

            Assert.AreEqual(art1, articles.ElementAt(0));
            Assert.AreEqual(art2, articles.ElementAt(1));
        }
    }
}
