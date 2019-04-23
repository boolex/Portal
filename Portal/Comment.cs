using System;
namespace Portal
{
    public class Comment
    {
        public int ArticleId { get; protected set; }
        public Article Article { get; protected set; }
        public DateTime Added { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
    }
}
