using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GastonCardenas.Test.Domain.Posts;

namespace GastonCardenasBlogEngine.test.Web.Models.Home
{
    public class HomeViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
    }
}
