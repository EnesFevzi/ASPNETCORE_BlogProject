using ASPNETCORE_BlogProject.Dto.DTO_s.Roles;
using ASPNETCORE_BlogProject.Entity.Entities;
using AutoMapper;

namespace ASPNETCORE_BlogProject.Service.AutoMapper.Roles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<AppRole, RoleDto>().ReverseMap();
           
        }
    }
}
