using ASPNETCORE_BlogProject.Data.UnıtOfWorks;
using ASPNETCORE_BlogProject.Dto.DTO_s.Article;
using ASPNETCORE_BlogProject.Entity.Entities;
using ASPNETCORE_BlogProject.Service.Services.Abstract;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE_BlogProject.Service.Services.Concrete
{
	public class ArticleService : IArticleService
	{
		private readonly IUnıtOfWork _unitofWork;
		private readonly IMapper _mapper;

		public ArticleService(IUnıtOfWork unitofWork, IMapper mapper)
		{
			_unitofWork = unitofWork;
			_mapper = mapper;
		}

		public Task CreateArticleAsync(ArticleAddDto articleAddDto)
		{
			throw new NotImplementedException();
		}

		public async Task<List<ArticleListDto>> GetAllArticlesAsync()
		{
			var result = await _unitofWork.GetRepository<Article>().GetAllAsync();
			var map= _mapper.Map<List<ArticleListDto>>(result);
			return map;
		}

		public Task<List<ArticleListDto>> GetAllArticlesWithCategoryDeletedAsync()
		{
			throw new NotImplementedException();
		}

		public Task<List<ArticleListDto>> GetAllArticlesWithCategoryNonDeletedAsync()
		{
			throw new NotImplementedException();
		}

		public Task<ArticleListDto> GetAllByPagingAsync(int? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
		{
			throw new NotImplementedException();
		}

		public Task<ArticleListDto> GetArticleWithCategoryNonDeletedAsync(int articleID)
		{
			throw new NotImplementedException();
		}

		public Task<string> SafeDeleteArticleAsync(int articleID)
		{
			throw new NotImplementedException();
		}

		public Task<ArticleListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
		{
			throw new NotImplementedException();
		}

		public Task<string> UndoDeleteArticleAsync(int articleID)
		{
			throw new NotImplementedException();
		}

		public Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
		{
			throw new NotImplementedException();
		}
	}
}
