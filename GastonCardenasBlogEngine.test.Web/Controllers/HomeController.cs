using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GastonCardenasBlogEngine.test.Web.Models;
using GastonCardenasBlogEngine.test.Web.Models.Home;
using GastonCardenas.Test.Domain.Enum;
using GastonCardenasBlogEngine.test.Web.App;

namespace GastonCardenasBlogEngine.test.Web.Controllers
{
    public class HomeController : Controller
    {
        IPostsApprovalFlowService _postsApprovalFlowService;

        public HomeController(IPostsApprovalFlowService postsApprovalFlowService)
        {
            _postsApprovalFlowService = postsApprovalFlowService;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel model = new HomeViewModel();
            if (User.Identity.IsAuthenticated)
                model.Posts = await _postsApprovalFlowService.GetPostsByStatus(null);
            else
                model.Posts = await _postsApprovalFlowService.GetPostsByStatus(PostStatusEnum.Published.GetHashCode());
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
