using ASPNETCORE_BlogProject.Dto.DTO_s.Category;
using ASPNETCORE_BlogProject.Entity.Entities;
using Microsoft.AspNetCore.Http;

namespace ASPNETCORE_BlogProject.Dto.DTO_s.Articles
{
    public class ArticleUpdateDto
    {
        public int ArticleID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }

        public Image Image { get; set; }
        public IFormFile? Photo { get; set; }

        public IList<CategoryDto> Categories { get; set; }
    }
}
