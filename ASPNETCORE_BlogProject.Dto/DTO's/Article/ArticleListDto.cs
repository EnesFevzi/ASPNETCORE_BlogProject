using ASPNETCORE_BlogProject.Entity.Entities;


namespace ASPNETCORE_BlogProject.Dto.DTO_s.Article
{
    public class ArticleListDto
	{
        public int ArticleID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; } = 0;

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public Guid? ImageID { get; set; }
        public Image Image { get; set; }

        //public Guid UserID { get; set; }
        //public AppUser User { get; set; }

        public ICollection<ArticleVisitor> ArticleVisitors { get; set; }
    }
}
