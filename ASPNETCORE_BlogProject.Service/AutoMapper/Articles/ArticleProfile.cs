using ASPNETCORE_BlogProject.Dto.DTO_s.Article;
using ASPNETCORE_BlogProject.Entity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE_BlogProject.Service.AutoMapper.Articles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleDto, Article>().ReverseMap();
            CreateMap<ArticleUpdateDto, Article>().ReverseMap();
            CreateMap<ArticleUpdateDto, ArticleDto>().ReverseMap();
            CreateMap<ArticleAddDto, Article>().ReverseMap();
        }
    }
}
