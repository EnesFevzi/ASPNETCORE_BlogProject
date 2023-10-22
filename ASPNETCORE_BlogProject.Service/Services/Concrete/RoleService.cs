using ASPNETCORE_BlogProject.Data.UnıtOfWorks;
using ASPNETCORE_BlogProject.Dto.DTO_s.Articles;
using ASPNETCORE_BlogProject.Dto.DTO_s.Roles;
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
    public class RoleService : IRoleService
    {
        private readonly IUnıtOfWork _unıtOfWork;
        private readonly IMapper _mapper;

        public RoleService(IUnıtOfWork unıtOfWork, IMapper mapper)
        {
            _unıtOfWork = unıtOfWork;
            _mapper = mapper;
        }

        public async Task<List<RoleDto>> GetAllRolesAsync()
        {
            var result = await _unıtOfWork.GetRepository<AppRole>().GetAllAsync();
            var map = _mapper.Map<List<RoleDto>>(result);
            
            return map;
        }
    }
}
