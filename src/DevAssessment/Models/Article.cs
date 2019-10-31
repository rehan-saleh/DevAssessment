﻿using System;

namespace DevAssessment.Models
{
    public class ArticleSource
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Article
    {
        public ArticleSource source { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public DateTime publishedAt { get; set; }
        public string content { get; set; }
    }
}
