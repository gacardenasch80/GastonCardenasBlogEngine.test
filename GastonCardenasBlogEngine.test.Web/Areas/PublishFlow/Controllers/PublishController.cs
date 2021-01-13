using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GastonCardenas.Test.Domain.Posts;
using GastonCardenasBlogEngine.test.Web.Areas.PublishFlow.Models.Publish;
using GastonCardenasBlogEngine.test.Web.App;

namespace GastonCardenasBlogEngine.test.Web.Areas.PublishFlow.Controllers
{
    [Area("PublishFlow")]
    [Authorize(Roles = "Editor,Writer")]
    public class PublishController : Controller
    {
        IPostsService _postsService;
        IPostsApprovalFlowService _postsApprovalFlowService;

        public PublishController(IPostsService postsService, IPostsApprovalFlowService postsApprovalFlowService)
        {
            _postsService = postsService;
            _postsApprovalFlowService = postsApprovalFlowService;
        }

        public async Task<IActionResult> Index()
        {
            PostsViewModel model = new PostsViewModel();
            model.Posts = await _postsService.GetAllPosts();
            return View(model);
        }

        public async Task<IActionResult> Post(int? id)
        {
            PostInputModel model = new PostInputModel();

            if (id.HasValue)
            {
                var post = await _postsService.GetPost(id.Value);
                if (post != null)
                {
                    model.Title = post.Title;
                    model.Text = post.Text;
                    model.PostStatusId = post.PostStatusId;
                    model.PostStatusName = post.PostStatus.Name;
                    model.IsEditMode = true;
                }
            }
            else
                model.PostStatusName = "Draft";

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(int? id, PostInputModel model)
        {
            //Evaluate each submit type
            switch (model.SendType)
            {
                case "SAVE":
                    if (ModelState.IsValid)
                    {
                        Post post = null;
                        if (id.HasValue)
                        {
                            post = await _postsService.GetPost(id.Value);
                            post.Update(model.Title, model.Text);
                            await _postsApprovalFlowService.UpdatePost(post);
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            post = new Post(model.Title, model.Text, User.Identity.Name);
                            int postId = await _postsApprovalFlowService.AddPost(post);

                            return RedirectToAction("Post", new { id = postId });
                        }
                    }
                    break;
                case "APPROVE":
                    if (id.HasValue)
                    {
                        var post = await _postsService.GetPost(id.Value);
                        post.UpdatePostStatus(GastonCardenas.Test.Domain.Enum.PostStatusEnum.PendingPublishApproval, User.Identity.Name);
                        await _postsApprovalFlowService.UpdatePost(post);

                        return RedirectToAction("Index");
                    }
                    break;
                case "PUBLISH":
                    if (id.HasValue)
                    {
                        var post = await _postsService.GetPost(id.Value);
                        post.UpdatePostStatus(GastonCardenas.Test.Domain.Enum.PostStatusEnum.Published, User.Identity.Name);
                        await _postsApprovalFlowService.UpdatePost(post);

                        return RedirectToAction("Index");
                    }
                    break;
                case "REJECT":
                    if (id.HasValue)
                    {
                        var post = await _postsService.GetPost(id.Value);
                        post.UpdatePostStatus(GastonCardenas.Test.Domain.Enum.PostStatusEnum.Draft, User.Identity.Name);
                        await _postsApprovalFlowService.UpdatePost(post);

                        return RedirectToAction("Index");
                    }
                    break;
                case "DELETE":
                    if (id.HasValue)
                    {
                        await _postsApprovalFlowService.RemovePost(id.Value);
                        return RedirectToAction("Index");
                    }
                    break;
            }

            if (id.HasValue)
            {
                var post = await _postsService.GetPost(id.Value);
                if (post != null)
                {
                    model.Title = post.Title;
                    model.Text = post.Text;
                    model.PostStatusId = post.PostStatusId;
                    model.PostStatusName = post.PostStatus.Name;
                }
            }
            else
                model.PostStatusName = "Draft";

            return View(model);
        }
    }
}
