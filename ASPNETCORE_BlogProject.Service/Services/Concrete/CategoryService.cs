using ASPNETCORE_BlogProject.Data.UnıtOfWorks;
using ASPNETCORE_BlogProject.Dto.DTO_s.Category;
using ASPNETCORE_BlogProject.Entity.Entities;
using ASPNETCORE_BlogProject.Service.Services.Abstract;
using AutoMapper;

namespace ASPNETCORE_BlogProject.Service.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnıtOfWork  _unıtOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnıtOfWork unıtOfWork, IMapper mapper)
        {
            _unıtOfWork = unıtOfWork;
            _mapper = mapper;
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

        public Task<List<CategoryDto>> GetAllCategoriesNonDeletedTake24()
        {
            throw new NotImplementedException();
        }
    }
}
