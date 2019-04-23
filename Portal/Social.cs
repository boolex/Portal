using System.Collections.Generic;
namespace Portal
{
    public class Social
    {
        public int ArticleId { get; protected set; }
        public Article Article { get; protected set; }
        public Stats Statis { get; protected set; }
        public Comments Comments { get; protected set; }
        public SocialNetworkLinks Links { get; protected set; }
    }

    public class Comments
    {
        public int ArticleId { get; protected set; }
        public Article Article { get; protected set; }
        public List<Comment> UserComments { get; protected set; }
    }
    public class Stats
    {
        public int ArticleId { get; protected set; }
        public Article Article { get; protected set; }
        public int Likes { get; protected set; }
        public int Dislikes { get; protected set; }
    }

    public class SocialNetworkLinks
    {
        public Article Article { get; protected set; }
        public SocialNetworkLinks()
        {
        }
        public Dictionary<string, string> Links { get; set; }
    }
}
