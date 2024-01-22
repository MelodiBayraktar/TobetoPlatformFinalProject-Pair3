using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.CourseExam.Requests;
using Business.Dtos.CourseExam.Responses;
using Core.DataAccess.Paging;
using Entities;
using Entities.Concretes;

namespace Business.Profiles
{
    public class CourseExamMappingProfile : Profile
    {
        public CourseExamMappingProfile()
        {
            CreateMap<CourseExam, CreateCourseExamRequest>().ReverseMap();
            CreateMap<CourseExam, CreatedCourseExamResponse>().ReverseMap();

            CreateMap<CourseExam, UpdateCourseExamRequest>().ReverseMap();
            CreateMap<CourseExam, UpdatedCourseExamResponse>().ReverseMap();

            CreateMap<CourseExam, DeleteCourseExamRequest>().ReverseMap();
            CreateMap<CourseExam, DeletedCourseExamResponse>().ReverseMap();

            CreateMap<CourseExam, GetCourseExamRequest>().ReverseMap();
            CreateMap<CourseExam, GetCourseExamResponse>().ReverseMap();

            CreateMap<CourseExam, GetListedCourseExamResponse>().ForMember(destinationMember: p => p.CourseExamDetailName,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.Name)).ReverseMap();

            CreateMap<Paginate<CourseExam>, Paginate<GetListedCourseExamResponse>>().ReverseMap();
        }
    }
}
