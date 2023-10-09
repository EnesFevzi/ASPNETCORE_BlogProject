using ASPNETCORE_BlogProject.Service.Services.Abstract;
using ASPNETCORE_BlogProject.Service.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCORE_BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            return View(articles);
        }
    }
}
