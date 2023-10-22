using ASPNETCORE_BlogProject.Data.UnıtOfWorks;
using ASPNETCORE_BlogProject.Entity.Entities;
using ASPNETCORE_BlogProject.Service.Services.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCORE_BlogProject.Web.Areas.Admin.ViewComponents
{
    public class DashboardHeaderViewComponent : ViewComponent
    {

        private readonly IUserService userService;


        public DashboardHeaderViewComponent( IUserService userService)
        {

            this.userService = userService;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await userService.GetUserProfileAsyncWitRoleAsync();
            return View(user);
        }
    }
}
