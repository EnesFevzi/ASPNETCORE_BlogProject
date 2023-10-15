using ASPNETCORE_BlogProject.Dto.DTO_s.Users;
using ASPNETCORE_BlogProject.Entity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE_BlogProject.Service.AutoMapper.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserListDto>().ReverseMap();
            //CreateMap<AppUser, UserAddDto>().ReverseMap();
            //CreateMap<AppUser, UserUpdateDto>().ReverseMap();
            //CreateMap<AppUser, UserProfileDto>().ReverseMap();

        }
    }
}
