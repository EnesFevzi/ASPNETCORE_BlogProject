using ASPNETCORE_BlogProject.Data.UnıtOfWorks;
using ASPNETCORE_BlogProject.Entity.Entities;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASPNETCORE_BlogProject.Web.Filter.ArticleVisitors
{
    public class ArticleVisitorFilter : IAsyncActionFilter
    {
        private readonly IUnıtOfWork _unitOfWork;

        public ArticleVisitorFilter(IUnıtOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public bool Disable { get;set; }

        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            List<Visitor> visitors = _unitOfWork.GetRepository<Visitor>().GetAllAsync().Result;


            string getIp = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            string getUserAgent = context.HttpContext.Request.Headers["User-Agent"];

            Visitor visitor = new(getIp, getUserAgent);



            if (visitors.Any(x => x.IpAddress == visitor.IpAddress))
                return next();
            else
            {
                _unitOfWork.GetRepository<Visitor>().AddAsync(visitor);
                _unitOfWork.Save();
            }
            return next();


        }
    }
}
