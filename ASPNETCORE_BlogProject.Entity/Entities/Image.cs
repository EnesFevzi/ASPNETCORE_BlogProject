﻿using ASPNETCORE_BlogProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE_BlogProject.Entity.Entities
{
	public class Image : EntityBase
	{
        public Image()
        {
            Users = new HashSet<AppUser>();
        }
        public Image(string fileName, string fileType, string createdBy)
        {
            FileName = fileName;
            FileType = fileType;
            CreatedBy = createdBy;
        }
        public Guid ImageID { get; set; }
		public string FileName { get; set; }
		public string FileType { get; set; }

		public ICollection<Article> Articles { get; set; }

		public ICollection<AppUser> Users { get; set; }
	}
}
