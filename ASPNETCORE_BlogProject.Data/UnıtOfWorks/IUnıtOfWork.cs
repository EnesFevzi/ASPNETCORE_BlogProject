using ASPNETCORE_BlogProject.Core.Entities;
using ASPNETCORE_BlogProject.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE_BlogProject.Data.UnıtOfWorks
{
	public interface IUnıtOfWork:IAsyncDisposable
	{
		IRepository<T> GetRepository<T>() where T:class,IEntityBase,new();
		Task<int> SaveAsync();
		int Save();
	}
}
