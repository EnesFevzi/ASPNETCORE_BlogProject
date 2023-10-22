using ASPNETCORE_BlogProject.Dto.DTO_s.Roles;
using ASPNETCORE_BlogProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE_BlogProject.Service.Services.Abstract
{
    public interface IRoleService
    {
        Task<List<RoleDto>> GetAllRolesAsync();
    }
}
