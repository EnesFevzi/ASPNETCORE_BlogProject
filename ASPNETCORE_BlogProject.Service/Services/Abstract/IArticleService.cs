

using ASPNETCORE_BlogProject.Dto.DTO_s.Article;
using ASPNETCORE_BlogProject.Entity.Entities;

namespace ASPNETCORE_BlogProject.Service.Services.Abstract
{
    public interface IArticleService
	{
		Task<List<ArticleListDto>> GetAllArticlesAsync();
		Task<List<ArticleListDto>> GetAllArticlesWithCategoryNonDeletedAsync();
		Task<List<ArticleListDto>> GetAllArticlesWithCategoryDeletedAsync();
		Task<ArticleListDto> GetArticleWithCategoryNonDeletedAsync(int articleID);
		Task CreateArticleAsync(ArticleAddDto articleAddDto);
		Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto);
		Task<string> SafeDeleteArticleAsync(int articleID);
		Task<string> UndoDeleteArticleAsync(int articleID);
		Task<ArticleListDto> GetAllByPagingAsync(int? categoryId, int currentPage = 1, int pageSize = 3,
			bool isAscending = false);

		Task<ArticleListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3,
			bool isAscending = false);
	}
}
