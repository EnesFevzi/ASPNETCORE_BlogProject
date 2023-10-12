﻿using ASPNETCORE_BlogProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE_BlogProject.Entity.Entities
{
	public class Visitor :IEntityBase
	{
        public Visitor() 
        { 

        }

        public Visitor(string ipAddress, string userAgent)
        {
            IpAddress = ipAddress;
            UserAgent = userAgent;
        }
        public int VisitorID { get; set; }
		public string IpAddress { get; set; }
		public string UserAgent { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public ICollection<ArticleVisitor> ArticleVisitors { get; set; }
	}
}
