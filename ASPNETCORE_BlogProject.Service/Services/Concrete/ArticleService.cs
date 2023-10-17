using ASPNETCORE_BlogProject.Data.UnıtOfWorks;
using ASPNETCORE_BlogProject.Dto.DTO_s.Articles;
using ASPNETCORE_BlogProject.Entity.Entities;
using ASPNETCORE_BlogProject.Entity.Enums;
using ASPNETCORE_BlogProject.Service.Extensions;
using ASPNETCORE_BlogProject.Service.Helpers.Images;
using ASPNETCORE_BlogProject.Service.Services.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE_BlogProject.Service.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnıtOfWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IImageHelper _imageHelper;
        private readonly ClaimsPrincipal _user;

        public ArticleService(IUnıtOfWork unitofWork, IMapper mapper, IHttpContextAccessor contextAccessor, IImageHelper imageHelper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _imageHelper = imageHelper;
            _user = _contextAccessor.HttpContext.User;
        }

        public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
        {
            var userID =_user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();
            var imageUpload = await _imageHelper.Upload(articleAddDto.Title, articleAddDto.Photo, ImageType.Post);
            Image image = new(imageUpload.FullName, articleAddDto.Photo.ContentType, userEmail);
            await _unitofWork.GetRepository<Image>().AddAsync(image);



            var article = new Article(articleAddDto.Title, articleAddDto.Content, userID, userEmail, articleAddDto.CategoryId, image.ImageID);

            await _unitofWork.GetRepository<Article>().AddAsync(article);
            await _unitofWork.SaveAsync();
        }

        public async Task<List<ArticleDto>> GetAllArticlesAsync()
        {
            var result = await _unitofWork.GetRepository<Article>().GetAllAsync();
            var map = _mapper.Map<List<ArticleDto>>(result);
            return map;
        }

        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryDeletedAsync()
        {
            var articles = await _unitofWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted, x => x.Category);
            var map = _mapper.Map<List<ArticleDto>>(articles);
            return map;
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
            var articles = await _unitofWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.ArticleID == articleID, x => x.Category,x=>x.Image);
            var map = _mapper.Map<ArticleDto>(articles);
            return map;
        }

        

        public Task<ArticleDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UndoDeleteArticleAsync(int articleID)
        {
            var article = await _unitofWork.GetRepository<Article>().GetByIDAsync(articleID);
            article.IsDeleted = false;
            article.DeletedDate = null;
            article.DeletedBy = null;
            await _unitofWork.GetRepository<Article>().UpdateAsync(article);
            await _unitofWork.SaveAsync();

            return article.Title;
        }

        public async Task<string>UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await _unitofWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.ArticleID == articleUpdateDto.ArticleID, x => x.Category,x=>x.Image);

            if (articleUpdateDto.Photo != null)
            {
                _imageHelper.Delete(article.Image.FileName);

                var imageUpload = await _imageHelper.Upload(articleUpdateDto.Title, articleUpdateDto.Photo, ImageType.Post);
                Image image = new(imageUpload.FullName, articleUpdateDto.Photo.ContentType, userEmail);
                await _unitofWork.GetRepository<Image>().AddAsync(image);

                article.ImageID = image.ImageID;

            }

            _mapper.Map(articleUpdateDto, article);
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userEmail;

            await _unitofWork.GetRepository<Article>().UpdateAsync(article);
            await _unitofWork.SaveAsync();

            return article.Title;

        }
        public async Task<string> SafeDeleteArticleAsync(int articleID)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await _unitofWork.GetRepository<Article>().GetByIDAsync(articleID);
            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;
            article.DeletedBy=userEmail;
            await _unitofWork.GetRepository<Article>().UpdateAsync(article);
            await _unitofWork.SaveAsync();

            return article.Title;
        }
    }
}
