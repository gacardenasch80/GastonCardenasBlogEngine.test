using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GastonCardenas.Test.Domain.Posts;

namespace GastonCardenasBlogEngine.test.Web.App
{
    /// <summary>
    /// Contract for post service
    /// </summary>
    public interface IPostsService
    {
        /// <summary>
        /// Return all registered posts
        /// </summary>
        /// <returns>List of post entities</returns>
        Task<IList<Post>> GetAllPosts();

        /// <summary>
        /// Get an instance of a post
        /// </summary>
        /// <param name="postId">Post id</param>
        /// <returns></returns>
        Task<Post> GetPost(int postId);

        /// <summary>
        /// Add comment to existing post
        /// </summary>
        /// <param name="postId">Post id</param>
        /// <param name="authorName">Author name</param>
        /// <param name="authorEmail">Author email</param>
        /// <param name="comment">Comment to add</param>
        /// <returns></returns>
        Task<bool> AddPostComment(int postId, string authorName, string authorEmail, string comment);
    }
}
