using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GastonCardenasBlogEngine.test.Web.App;
using GastonCardenasBlogEngine.test.Web.Models.Posts;

namespace GastonCardenasBlogEngine.test.Web.Controllers
{
    public class PostsController : Controller
    {
        IPostsService _postsService;

        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        public async Task<IActionResult> Index(int id)
        {
            PostDetailViewModel model = new PostDetailViewModel();
            model.PostId = id;
            model.Post = await _postsService.GetPost(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int id, PostDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _postsService.AddPostComment(id, model.AuthorName, model.AuthorEmail, model.Comment);
                model.AuthorName = string.Empty;
                model.AuthorEmail = string.Empty;
                model.Comment = string.Empty;

                return RedirectToAction("Index", new { id = id });
            }

            model.PostId = id;
            model.Post = await _postsService.GetPost(id);

            return View(model);
        }
    }
}
