using ASPNETCORE_BlogProject.Data.Context;
using ASPNETCORE_BlogProject.Data.Repositories.Abstract;
using ASPNETCORE_BlogProject.Data.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE_BlogProject.Data.UnıtOfWorks
{
	public class UnitOfWork : IUnıtOfWork
	{
		private readonly AppDbContext _dbContext;

		public UnitOfWork(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async ValueTask DisposeAsync()
		{
			await _dbContext.DisposeAsync();
		}

		public int Save()
		{
			return _dbContext.SaveChanges();
		}

		public async Task<int> SaveAsync()
		{
			return await _dbContext.SaveChangesAsync();
		}


		IRepository<T> IUnıtOfWork.GetRepository<T>()
		{
			return new Repository<T>(_dbContext);
		}
	}
}
