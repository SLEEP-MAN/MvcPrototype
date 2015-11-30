﻿using System;
using System.Collections.Generic;
using System.Linq;
using MvcPrototype.DAL.Interfaces.Repositories;
using MvcPrototype.Models;
using MvcPrototype.Services.Interfaces;

namespace MvcPrototype.Services
{
    public class ArticleService : IArticleService
    {
        private IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public IEnumerable<Article> GetArticles()
        {
            return _articleRepository.GetArticles().ToList();
        }
    }
}