﻿

using ASPNETCORE_BlogProject.Dto.DTO_s.Articles;
using ASPNETCORE_BlogProject.Dto.DTO_s.Categories;
using ASPNETCORE_BlogProject.Entity.Entities;

namespace ASPNETCORE_BlogProject.Service.Services.Abstract
{
    public interface IArticleService
	{
		Task<List<ArticleDto>> GetAllArticlesAsync();
		Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync();
		Task<List<ArticleDto>> GetAllArticlesWithCategoryDeletedAsync();
		Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(int articleID);
		Task CreateArticleAsync(ArticleAddDto articleAddDto);
		Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto);
		Task<string> SafeDeleteArticleAsync(int articleID);
		Task<string> UndoDeleteArticleAsync(int articleID);
		Task<ArticleListDto> GetAllByPagingAsync(int? categoryId, int currentPage = 1, int pageSize = 3,
			bool isAscending = false);

		Task<ArticleListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3,
			bool isAscending = false);

        Task<ArticleDto> GetArticleDetailAsync(int articleId, string ipAddress);

        Task<List<ArticleDto>> GetAllArticlesNonDeletedTake3Async();
    }
}
