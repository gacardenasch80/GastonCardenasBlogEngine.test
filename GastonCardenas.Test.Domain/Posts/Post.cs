using System;
using System.Collections.Generic;
using GastonCardenas.Test.Common.Framework;
using GastonCardenas.Test.Domain.Enum;

namespace GastonCardenas.Test.Domain.Posts
{
    public class Post : IAggregateRoot
    {
        public int PostId { get; protected set; }

        public string Title { get; private set; }
        public string Text { get; private set; }
        public string AuthorName { get; private set; }

        public DateTime CreationtDate { get; private set; }

        public DateTime LastUpdateDate { get; private set; }

        public int PostStatusId { get; private set; }

        public virtual PostStatus PostStatus { get; set; }

        private readonly List<PostComment> _postComments;
        public virtual IReadOnlyCollection<PostComment> PostComments => _postComments;

        public string ApproverName { get; private set; }

        public DateTime? ApprovalDate { get; private set; }

        protected Post()
        {
            _postComments = new List<PostComment>();
        }

        public Post(string title, string text, string authorName)
        {

            Title = title;
            Text = text;
            AuthorName = authorName;
            CreationtDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            PostStatusId = (int)PostStatusEnum.Draft;

            _postComments = new List<PostComment>();
        }

        public void Update(string title, string text)
        {
            Title = title;
            Text = text;
            LastUpdateDate = DateTime.Now;
        }

        public void UpdatePostStatus(PostStatusEnum postStatus, string user)
        {
            switch (postStatus)
            {
                case PostStatusEnum.Draft:
                    PostStatusId = (int)postStatus;
                    LastUpdateDate = DateTime.Now;
                    break;
                case PostStatusEnum.PendingPublishApproval:
                    PostStatusId = (int)postStatus;
                    LastUpdateDate = DateTime.Now;
                    break;
                case PostStatusEnum.Published:
                    PostStatusId = (int)postStatus;
                    LastUpdateDate = DateTime.Now;
                    ApprovalDate = DateTime.Now;
                    ApproverName = user;
                    break;
            }
        }

        public bool AddComment(string authorName, string authorEmail, string comment)
        {
            if (PostStatusId != (int)PostStatusEnum.Published)
                return false;

            _postComments.Add(new PostComment(authorName, authorEmail, comment));
            return true;
        }
    }    
}
