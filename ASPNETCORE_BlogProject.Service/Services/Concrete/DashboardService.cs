using ASPNETCORE_BlogProject.Data.UnıtOfWorks;
using ASPNETCORE_BlogProject.Entity.Entities;
using ASPNETCORE_BlogProject.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE_BlogProject.Service.Services.Concrete
{
    public class DashboardService : IDashbordService
    {
        private readonly IUnıtOfWork _unıtOfWork;

        public DashboardService(IUnıtOfWork unıtOfWork)
        {
            _unıtOfWork = unıtOfWork;
        }

        public async Task<int> GetTotalArticleCount()
        {
            var articleCount = await _unıtOfWork.GetRepository<Article>().CountAsync();
            return articleCount;
        }
        public async Task<int> GetTotalCategoryCount()
        {
            var categoryCount = await _unıtOfWork.GetRepository<Category>().CountAsync();
            return categoryCount;
        }

        public async Task<int> GetTotalUserCount()
        {
            var userCount = await _unıtOfWork.GetRepository<AppUser>().CountAsync();
            return userCount;
        }
        public async Task<int> GetTotalRoleCount()
        {
            var userCount = await _unıtOfWork.GetRepository<AppRole>().CountAsync();
            return userCount;
        }
        
        public async Task<List<int>> GetYearlyArticleCounts()
        {
            var articles = await _unıtOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted);

            var startDate = DateTime.Now.Date;
            startDate = new DateTime(startDate.Year, 1, 1);

            List<int> datas = new();

            for (int i = 1; i <= 12; i++)
            {
                var startedDate = new DateTime(startDate.Year, i, 1);
                var endedDate = startedDate.AddMonths(1);
                var data = articles.Where(x => x.CreatedDate >= startedDate && x.CreatedDate < endedDate).Count();
                datas.Add(data);
            }

            return datas;

        }
    }
}
