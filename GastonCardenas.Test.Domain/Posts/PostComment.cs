using System;

namespace GastonCardenas.Test.Domain.Posts
{
    /// <summary>
    /// Post comment entity
    /// </summary>
    public class PostComment
    {
        public int PostCommentId { get; protected set; }

        public int PostId { get; private set; }
        public virtual Post Post { get; set; }

        public string AuthorName { get; private set; }

        public string AuthorEmail { get; private set; }

        public DateTime CreationtDate { get; private set; }

        public string Comment { get; private set; }

        public PostComment(string authorName, string authorEmail, string comment)
        {
            AuthorName = authorName;
            AuthorEmail = authorEmail;
            Comment = comment;
            CreationtDate = DateTime.Now;
        }
    }
}
