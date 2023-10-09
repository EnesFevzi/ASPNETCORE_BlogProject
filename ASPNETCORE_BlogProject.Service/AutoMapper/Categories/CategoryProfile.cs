﻿using ASPNETCORE_BlogProject.Dto.DTO_s.Category;
using ASPNETCORE_BlogProject.Entity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE_BlogProject.Service.AutoMapper.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
           // CreateMap<CategoryAddDto, Category>().ReverseMap();
            //CreateMap<CategoryUpdateDto, Category>().ReverseMap();
        }
    }
}
