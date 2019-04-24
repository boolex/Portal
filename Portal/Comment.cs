using System;
namespace Portal
{
    public class Comment
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public DateTime Added { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
    }
}
