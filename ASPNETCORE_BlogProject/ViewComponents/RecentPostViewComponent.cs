using ASPNETCORE_BlogProject.Service.Services.Abstract;
using ASPNETCORE_BlogProject.Service.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCORE_BlogProject.Web.ViewComponents
{
    public class RecentPostViewComponent : ViewComponent
    {
        private readonly IArticleService _articleService;

        public RecentPostViewComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var articles = await _articleService.GetAllArticlesNonDeletedTake3Async();
            return View(articles);
        }
    }
}
