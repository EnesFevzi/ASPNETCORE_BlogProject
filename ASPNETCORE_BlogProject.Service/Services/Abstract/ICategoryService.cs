using ASPNETCORE_BlogProject.Dto.DTO_s.Categories;
using ASPNETCORE_BlogProject.Entity.Entities;

namespace ASPNETCORE_BlogProject.Service.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesNonDeleted();
        Task<List<CategoryDto>> GetAllCategoriesNonDeletedTake24();
        Task<List<CategoryDto>> GetAllCategoriesDeleted();
        Task CreateCategoryAsync(CategoryAddDto categoryAddDto);
        Task<CategoryDto> GetCategoryByID(int id);
        Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto);
        Task<string> SafeDeleteCategoryAsync(int categoryId);
        Task<string> UndoDeleteCategoryAsync(int categoryId);
    }
}
