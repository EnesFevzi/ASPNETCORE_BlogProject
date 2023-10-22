using ASPNETCORE_BlogProject.Data.Context;
using ASPNETCORE_BlogProject.Data.Extensions;
using ASPNETCORE_BlogProject.Entity.Entities;
using ASPNETCORE_BlogProject.Service.Describers;
using ASPNETCORE_BlogProject.Service.Extensions;
using ASPNETCORE_BlogProject.Web.Filter.ArticleVisitors;
using ASPNETCORE_BlogProject.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.Reflection;

namespace ASPNETCORE_BlogProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddHttpClient();
            builder.Services.AddAuthorization();

            builder.Services.LoadDataLayerExtension(builder.Configuration);
            builder.Services.LoadServiceLayerExtension();
            builder.Services.AddSession();
            builder.Services.AddControllersWithViews(opt =>
            {
                opt.Filters.Add<ArticleVisitorFilter>();
            })
                  .AddNToastNotifyToastr(new ToastrOptions()
                  {
                      PositionClass = ToastPositions.TopRight,
                      TimeOut = 3000,
                  })
             .AddRazorRuntimeCompilation();

            builder.Services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
            })
             .AddRoleManager<RoleManager<AppRole>>()
             .AddErrorDescriber<CustomIdentityErrorDescriber>()
             .AddEntityFrameworkStores<AppDbContext>()
             .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = new PathString("/Admin/Auth/Login");
                config.LogoutPath = new PathString("/Admin/Auth/Logout");
                config.Cookie = new CookieBuilder
                {
                    Name = "ASPNETCORE_BlogProject",
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest //Always 
                };
                config.SlidingExpiration = true;
                config.ExpireTimeSpan = TimeSpan.FromDays(7);
                config.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseNToastNotify();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                name: "Admin",
                areaName: "Admin",
                pattern: "{area:exists}/{controller=Home1}/{action=Index}/{id?}"
                );
                //endpoints.MapControllerRoute(
                //   name: "default",
                //   pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapDefaultControllerRoute();
            });
            app.Run();
        }
    }
}