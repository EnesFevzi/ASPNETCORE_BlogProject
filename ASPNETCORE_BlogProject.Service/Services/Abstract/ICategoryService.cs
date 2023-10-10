using ASPNETCORE_BlogProject.Dto.DTO_s.Category;
using ASPNETCORE_BlogProject.Entity.Entities;

namespace ASPNETCORE_BlogProject.Service.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesNonDeleted();
        Task<List<CategoryDto>> GetAllCategoriesNonDeletedTake24();
        Task<List<CategoryDto>> GetAllCategoriesDeleted();
        //Task CreateCategoryAsync(CategoryAddDto categoryAddDto);
        //Task<Category> GetCategoryByGuid(Guid id);
        //Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto);
        //Task<string> SafeDeleteCategoryAsync(Guid categoryId);
        //Task<string> UndoDeleteCategoryAsync(Guid categoryId);
    }
}
