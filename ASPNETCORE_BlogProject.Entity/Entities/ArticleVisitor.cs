using ASPNETCORE_BlogProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE_BlogProject.Entity.Entities
{
	public class ArticleVisitor:IEntityBase
	{
        public ArticleVisitor() 
        { 
        }

        public ArticleVisitor(int articleId, int visitorId)
        {
            ArticleID = articleId;
            VisitorID = visitorId;
        }


        public int ArticleID { get; set; }
		public Article Article { get; set; }
		public int VisitorID { get; set; }
		public Visitor Visitor { get; set; }
	}
}
