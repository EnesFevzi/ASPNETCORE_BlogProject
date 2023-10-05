using ASPNETCORE_BlogProject.Data.UnıtOfWorks;
using ASPNETCORE_BlogProject.Service.Services.Abstract;
using ASPNETCORE_BlogProject.Service.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE_BlogProject.Service.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddAutoMapper(assembly);

            return services;


        }
    }
}
