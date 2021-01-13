using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using GastonCardenas.Test.Domain.Posts;
using GastonCardenas.Test.Infrastructure.Data;
using GastonCardenas.Test.Infrastructure.Data.Repository;
using GastonCardenasBlogEngine.test.Web.App;

namespace GastonCardenas.Test.Tests
{
    public class PostsServiceTest
    {
        
        IPostsService _postsService;

        public PostsServiceTest()
        {
            var services = new ServiceCollection();

            //Register entity framework context for app
            services.AddDbContext<EngineContext>(options =>
            {
                options.UseSqlServer("Server=DESARROLLO7;Database=BlogEngineApp;User Id=BlogEngineUsr;Password=@!P@ssword;",
                                     sqlServerOptionsAction: sqlOptions =>
                                     {
                                         //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 
                                         sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                     });
            });

            #region [Dependency Injection]
            services.AddTransient<IPostsRepository, SQLPostsRepository>();
            services.AddTransient<IPostsService, PostsService>();
            #endregion

            var serviceProvider = services.BuildServiceProvider();
            _postsService = serviceProvider.GetRequiredService<IPostsService>();
        }

        [Test]
        public async Task GetAllPosts()
        {
            var posts = await _postsService.GetAllPosts();

            Assert.IsNotNull(posts);
        }

        [Test]
        public async Task GetPost()
        {
            var post = await _postsService.GetPost(1);

            Assert.IsNotNull(post);
        }

    }
}
