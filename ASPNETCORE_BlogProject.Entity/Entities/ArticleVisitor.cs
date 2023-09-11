using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE_BlogProject.Entity.Entities
{
	public class ArticleVisitor
	{


		public int ArticleVisitorID { get; set; }
		public Article Article { get; set; }
		public int VisitorID { get; set; }
		public Visitor Visitor { get; set; }
	}
}
