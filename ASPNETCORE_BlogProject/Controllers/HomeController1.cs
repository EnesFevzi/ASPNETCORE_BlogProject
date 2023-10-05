using ASPNETCORE_BlogProject.Controllers;
using ASPNETCORE_BlogProject.Dto.DTO_s.Article;
using ASPNETCORE_BlogProject.Service.Services.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCORE_BlogProject.Web.Controllers
{
    public class HomeController1 : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public HomeController1(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllArticlesAsync();
            return View(articles);
        }
    }
}
