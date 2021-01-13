using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GastonCardenas.Test.Common.Framework;
using GastonCardenas.Test.Domain.Posts;

namespace GastonCardenas.Test.Infrastructure.Data.Repository
{
    /// <summary>
    /// Post repository implementation
    /// </summary>
    public class SQLPostsRepository : IPostsRepository
    {
        private readonly EngineContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public SQLPostsRepository(EngineContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public void Add(Post post)
        {
            _context.Posts.Add(post);
        }

        public void Update(Post post)
        {
            _context.Posts.Update(post);
        }

        public async Task<Post> GetPost(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);

            if (post != null)
            {
                await _context.Entry<Post>(post).Collection(t => t.PostComments).LoadAsync();
                await _context.Entry<Post>(post).Reference(t => t.PostStatus).LoadAsync();
            }

            return post;
        }

        public async Task Delete(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post != null)
                _context.Posts.Remove(post);
        }

        public async Task<IList<Post>> GetAll()
        {
            var posts = await _context.Posts.ToListAsync();

            foreach (var post in posts)
            {
                await _context.Entry<Post>(post).Collection(t => t.PostComments).LoadAsync();
                await _context.Entry<Post>(post).Reference(t => t.PostStatus).LoadAsync();
            }

            return posts;
        }

        public async Task<IList<Post>> GetByStatus(int? postStatusId)
        {
            var posts = await _context.Posts.Where(t => t.PostId > 0 && (!postStatusId.HasValue || t.PostStatusId == postStatusId.Value)).ToListAsync();

            foreach (var post in posts)
            {
                await _context.Entry<Post>(post).Collection(t => t.PostComments).LoadAsync();
                await _context.Entry<Post>(post).Reference(t => t.PostStatus).LoadAsync();
            }

            return posts;
        }
    }
}
