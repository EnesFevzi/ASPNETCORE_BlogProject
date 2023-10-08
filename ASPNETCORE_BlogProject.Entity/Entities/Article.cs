using ASPNETCORE_BlogProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ASPNETCORE_BlogProject.Entity.Entities
{
	public class Article: EntityBase
	{
		public int ArticleID { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public int ViewCount { get; set; } = 0;

		public int CategoryID { get; set; }
		public Category Category { get; set; }

		public Guid? ImageID { get; set; }
		public Image Image { get; set; }

		public int UserID { get; set; }
		public AppUser User { get; set; }

		public ICollection<ArticleVisitor> ArticleVisitors { get; set; }

	}
}
