using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GastonCardenas.Test.Domain.Posts;

namespace GastonCardenasBlogEngine.test.Web.Areas.PublishFlow.Models.Publish
{
    public class PostsViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
    }
}
