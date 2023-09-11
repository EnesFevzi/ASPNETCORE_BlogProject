using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE_BlogProject.Entity.Entities
{
	public class Visitor 
	{
		public int VisitorID { get; set; }
		public string IpAddress { get; set; }
		public string UserAgent { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public ICollection<ArticleVisitor> ArticleVisitors { get; set; }
	}
}
