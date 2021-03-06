﻿using Portal.Images;
using Portal.Tags;
using System.Collections.Generic;

namespace Portal
{
    public class Article
    {
        public Article() { }
        public Article(Article article)
        {
            if (article != null)
            {
                Id = article.Id;
                Title = article.Title;
                Content = article.Content;
            }
        }
        public Article(int id, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
