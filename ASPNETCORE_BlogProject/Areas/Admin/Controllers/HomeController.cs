using ASPNETCORE_BlogProject.Entity.Entities;
using ASPNETCORE_BlogProject.Service.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCORE_BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;


        public HomeController(IArticleService articleService, UserManager<AppUser> userManager)
        {
            _articleService = articleService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllArticlesWithCategoryDeletedAsync();
            var loggedInUser= await _userManager.GetUserAsync(HttpContext.User);
            return View(articles);
        }
    }
}
