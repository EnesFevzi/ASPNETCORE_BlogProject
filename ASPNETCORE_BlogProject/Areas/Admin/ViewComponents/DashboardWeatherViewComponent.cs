using ASPNETCORE_BlogProject.Dto.DTO_s.Users;
using ASPNETCORE_BlogProject.Service.Services.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace ASPNETCORE_BlogProject.Web.Areas.Admin.ViewComponents
{
    public class DashboardWeatherViewComponent: ViewComponent
    {
        private readonly IUserService _userService;

        public DashboardWeatherViewComponent(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var weatherInfo = await _userService.GetWeatherInfo();
            ViewBag.HavaDurumu = weatherInfo.Condition;
            ViewBag.Sicaklik = weatherInfo.Temperature;
            return View();
        }
    }
}
