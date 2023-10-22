using ASPNETCORE_BlogProject.Data.UnıtOfWorks;
using ASPNETCORE_BlogProject.Dto.DTO_s.Articles;
using ASPNETCORE_BlogProject.Dto.DTO_s.Categories;
using ASPNETCORE_BlogProject.Entity.Entities;
using ASPNETCORE_BlogProject.Service.Extensions;
using ASPNETCORE_BlogProject.Service.Services.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ASPNETCORE_BlogProject.Service.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnıtOfWork _unıtOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly ClaimsPrincipal _user;

        public CategoryService(IUnıtOfWork unıtOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unıtOfWork = unıtOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _user = _httpContextAccessor.HttpContext.User;
        }


        public async Task CreateCategoryAsync(CategoryAddDto categoryAddDto)
        {
            var userEmail = _user.GetLoggedInEmail();

            Category category = new(categoryAddDto.Name, userEmail);
            await _unıtOfWork.GetRepository<Category>().AddAsync(category);
            await _unıtOfWork.SaveAsync();
        }

        public async Task<List<CategoryDto>> GetAllCategoriesDeleted()
        {
            var categories = await _unıtOfWork.GetRepository<Category>().GetAllAsync(x => x.IsDeleted);
            var map = _mapper.Map<List<CategoryDto>>(categories);

            return map;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesNonDeleted()
        {
            var categories = await _unıtOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = _mapper.Map<List<CategoryDto>>(categories);

            return map;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesNonDeletedTake24()
        {
            var categories = await _unıtOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = _mapper.Map<List<CategoryDto>>(categories);
            return map.Take(24).ToList();
        }

        public async Task<CategoryDto> GetCategoryByID(int id)
        {
            var categories = await _unıtOfWork.GetRepository<Category>().GetAsync(x => x.CategoryID == id);
            var map = _mapper.Map<CategoryDto>(categories);
            return map;
        }

        public async Task<string> SafeDeleteCategoryAsync(int categoryId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var category = await _unıtOfWork.GetRepository<Category>().GetByIDAsync(categoryId);
            category.IsDeleted = true;
            category.DeletedDate = DateTime.Now;
            category.DeletedBy = userEmail;
            await _unıtOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unıtOfWork.SaveAsync();

            return category.Name;
        }

        public async Task<string> UndoDeleteCategoryAsync(int categoryId)
        {
            var category = await _unıtOfWork.GetRepository<Category>().GetByIDAsync(categoryId);
            category.IsDeleted = false;
            category.DeletedDate = null;
            category.DeletedBy = null;
            await _unıtOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unıtOfWork.SaveAsync();

            return category.Name;
        }

        public async Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var category = await _unıtOfWork.GetRepository<Category>().GetAsync(x => !x.IsDeleted && x.CategoryID == categoryUpdateDto.CategoryID);

            category.Name = categoryUpdateDto.Name;
            category.ModifiedBy = userEmail;
            category.ModifiedDate = DateTime.Now;

            await _unıtOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unıtOfWork.SaveAsync();

            return category.Name;
        }
    }
}
