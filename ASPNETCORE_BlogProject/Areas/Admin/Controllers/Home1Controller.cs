using ASPNETCORE_BlogProject.Service.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCORE_BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class Home1Controller : Controller
    {
        private readonly IArticleService _articleService;

        public Home1Controller(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task< IActionResult> Index()
        {
            var articles = await _articleService.GetAllArticlesAsync();
            return View(articles);
        }
    }
}
