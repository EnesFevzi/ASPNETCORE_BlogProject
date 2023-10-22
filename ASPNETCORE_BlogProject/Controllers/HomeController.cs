using ASPNETCORE_BlogProject.Data.UnıtOfWorks;
using ASPNETCORE_BlogProject.Dto.DTO_s.Articles;
using ASPNETCORE_BlogProject.Entity.Entities;
using ASPNETCORE_BlogProject.Models;
using ASPNETCORE_BlogProject.Service.Services.Abstract;
using ASPNETCORE_BlogProject.Service.Services.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPNETCORE_BlogProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnıtOfWork _unıtOfWork;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService, IMapper mapper, IHttpContextAccessor httpContextAccessor, IUnıtOfWork unıtOfWork)
        {
            _logger = logger;
            _articleService = articleService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _unıtOfWork = unıtOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            var articles = await _articleService.GetAllByPagingAsync(categoryId, currentPage, pageSize, isAscending);
            return View(articles);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            var articles = await _articleService.SearchAsync(keyword, currentPage, pageSize, isAscending);
            return View(articles);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Detail(int id)
        {
            var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

            var articleDetail = await _articleService.GetArticleDetailAsync(id, ipAddress);

            if (articleDetail == null)
            {
                return NotFound();
            }

            return View(articleDetail);
        }
    }
}