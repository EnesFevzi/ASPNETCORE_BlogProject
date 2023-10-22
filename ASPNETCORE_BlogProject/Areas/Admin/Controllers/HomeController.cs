using ASPNETCORE_BlogProject.Entity.Entities;
using ASPNETCORE_BlogProject.Service.Services.Abstract;
using ASPNETCORE_BlogProject.Service.Services.Concrete;
using ASPNETCORE_BlogProject.Web.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASPNETCORE_BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IDashbordService _dashbordService;

        public HomeController(IArticleService articleService, UserManager<AppUser> userManager,IDashbordService dashbordService)
        {
            _articleService = articleService;
            _userManager = userManager;
            _dashbordService = dashbordService;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllArticlesWithCategoryNonDeletedAsync();

            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> YearlyArticleCounts()
        {
            var count = await _dashbordService.GetYearlyArticleCounts();
            return Json(JsonConvert.SerializeObject(count));
        }
        [HttpGet]
        public async Task<IActionResult> TotalArticleCount()
        {
            var count = await _dashbordService.GetTotalArticleCount();
            return Json(count);
        }
        [HttpGet]
        public async Task<IActionResult> TotalCategoryCount()
        {
            var count = await _dashbordService.GetTotalCategoryCount();
            return Json(count);
        }

        [HttpGet]
        public async Task<IActionResult> TotalUserCounts()
        {
            var count = await _dashbordService.GetTotalUserCount();
            return Json(count);
        }

        [HttpGet]
        public async Task<IActionResult> TotalRoleCounts()
        {
            var count = await _dashbordService.GetTotalRoleCount();
            return Json(count);
        }
    }
}
