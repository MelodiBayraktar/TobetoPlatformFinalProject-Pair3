using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.CourseCategory.Requests;
using Business.Dtos.CourseCategory.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class CourseCategoryMappingProfile : Profile
    {
        public CourseCategoryMappingProfile()
        {
            CreateMap<CourseCategory, CreateCourseCategoryRequest>().ReverseMap();
            CreateMap<CourseCategory, CreatedCourseCategoryResponse>().ReverseMap();

            CreateMap<CourseCategory, UpdateCourseCategoryRequest>().ReverseMap();
            CreateMap<CourseCategory, UpdatedCourseCategoryResponse>().ReverseMap();

            CreateMap<CourseCategory, DeleteCourseCategoryRequest>().ReverseMap();
            CreateMap<CourseCategory, DeletedCourseCategoryResponse>().ReverseMap();

            CreateMap<CourseCategory, GetCourseCategoryRequest>().ReverseMap();
            CreateMap<CourseCategory, GetCourseCategoryResponse>().ReverseMap();


            CreateMap<CourseCategory, GetListedCourseCategoryResponse>().ReverseMap();
            CreateMap<Paginate<CourseCategory>, Paginate<GetListedCourseCategoryResponse>>().ReverseMap();
        }
    }
}
