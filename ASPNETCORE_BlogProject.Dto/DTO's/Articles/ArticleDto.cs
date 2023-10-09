using ASPNETCORE_BlogProject.Dto.DTO_s.Category;
using ASPNETCORE_BlogProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE_BlogProject.Dto.DTO_s.Articles
{
    public class ArticleDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public CategoryDto Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public Image Image { get; set; }
        public AppUser User { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public int ViewCount { get; set; }
    }
}
