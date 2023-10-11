using ASPNETCORE_BlogProject.Data.UnıtOfWorks;
using ASPNETCORE_BlogProject.Dto.DTO_s.Articles;
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

        public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
        {
            var userID = 1;
            var article = new Article()
            {
                Title = articleAddDto.Title,
                Content = articleAddDto.Content,
                CategoryID = articleAddDto.CategoryId,
                UserID = userID,
            };
            await _unitofWork.GetRepository<Article>().AddAsync(article);
            await _unitofWork.SaveAsync();
        }

        public async Task<List<ArticleDto>> GetAllArticlesAsync()
        {
            var result = await _unitofWork.GetRepository<Article>().GetAllAsync();
            var map = _mapper.Map<List<ArticleDto>>(result);
            return map;
        }

        public Task<List<ArticleDto>> GetAllArticlesWithCategoryDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
        {
            var articles = await _unitofWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category);
            var map = _mapper.Map<List<ArticleDto>>(articles);
            return map;
        }

        public Task<ArticleDto> GetAllByPagingAsync(int? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            throw new NotImplementedException();
        }

        public async Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(int articleID)
        {
            var articles = await _unitofWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.ArticleID == articleID, x => x.Category);
            var map = _mapper.Map<ArticleDto>(articles);
            return map;
        }

        public Task<string> SafeDeleteArticleAsync(int articleID)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            throw new NotImplementedException();
        }

        public Task<string> UndoDeleteArticleAsync(int articleID)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        {
            var article = await _unitofWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.ArticleID == articleUpdateDto.ArticleID, x => x.Category);

            article.Title= articleUpdateDto.Title;
            article.Content= articleUpdateDto.Content;
            article.CategoryID = articleUpdateDto.CategoryId;

            await _unitofWork.GetRepository<Article>().UpdateAsync(article);
            await _unitofWork.SaveAsync();

        }   
    }
}
