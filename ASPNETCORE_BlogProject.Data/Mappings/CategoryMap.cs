using ASPNETCORE_BlogProject.Entity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE_BlogProject.Data.Mappings
{
	public class CategoryMap : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasData(new Category
			{
				CategoryID = 1,
				Name = "ASP.NET Core",
				CreatedBy = "Admin Test",
				CreatedDate = DateTime.Now,
				IsDeleted = false
			},
			new Category
			{
				CategoryID = 2,
				Name = "Visual Studio 2022",
				CreatedBy = "Admin Test",
				CreatedDate = DateTime.Now,
				IsDeleted = false

			});

		}
	}
}
