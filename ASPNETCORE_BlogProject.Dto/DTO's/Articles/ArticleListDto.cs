using ASPNETCORE_BlogProject.Entity.Entities;

namespace ASPNETCORE_BlogProject.Dto.DTO_s.Articles
{
    public class ArticleListDto
    {
        public ICollection<Article> Articles { get; set; }
        public int? CategoryID { get; set; }
        public virtual int CurrentPage { get; set; } = 1;
        public virtual int PageSize { get; set; } = 3;
        public virtual int TotalCount { get; set; }
        public virtual int TotalPages => (int)Math.Ceiling(decimal.Divide(TotalCount, PageSize));
        public virtual bool ShowPrevious => CurrentPage > 1;
        public virtual bool ShowNext => CurrentPage < TotalPages;
        public virtual bool IsAscending { get; set; } = false;
    }
}
