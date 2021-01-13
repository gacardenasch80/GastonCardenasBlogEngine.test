using System.Collections.Generic;
using System.Threading.Tasks;
using GastonCardenas.Test.Common.Framework;

namespace GastonCardenas.Test.Domain.Posts
{
    /// <summary>
    /// Contract for posts repository
    /// </summary>
    public interface IPostsRepository : IRepository<Post>
    {
        /// <summary>
        /// Add a new post.
        /// </summary>
        /// <param name="post">Post entity</param>
        /// <returns></returns>
        void Add(Post post);

        /// <summary>
        /// Update an existing post
        /// </summary>
        /// <param name="post">Post entity</param>
        /// <returns></returns>
        void Update(Post post);

        /// <summary>
        /// Get a post intance
        /// </summary>
        /// <param name="postId">Post id</param>
        /// <returns>POst entity</returns>
        Task<Post> GetPost(int postId);

        /// <summary>
        /// Delete post
        /// </summary>
        /// <param name="postId">Post id</param>
        /// <returns></returns>
        Task Delete(int postId);

        /// <summary>
        /// Get all registered posts
        /// </summary>
        /// <returns>List of posts</returns>
        Task<IList<Post>> GetAll();

        Task<IList<Post>> GetByStatus(int? postStatusId);
    }
}
