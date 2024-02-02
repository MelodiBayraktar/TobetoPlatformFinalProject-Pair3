using AutoMapper;
using Business.Dtos.CourseDetail.Requests;
using Business.Dtos.CourseDetail.Responses;
using Core.DataAccess.Paging;
using Entities;
using Entities.Concretes;

namespace Business.Profiles;

public class CourseDetailMappingProfile : Profile
{
    public CourseDetailMappingProfile()
    {
        CreateMap<CourseDetail, CreateCourseDetailRequest>().ReverseMap();
        CreateMap<CourseDetail, CreatedCourseDetailResponse>().ReverseMap();

        CreateMap<CourseDetail, UpdateCourseDetailRequest>().ReverseMap();
        CreateMap<CourseDetail, UpdatedCourseDetailResponse>().ReverseMap();

        CreateMap<CourseDetail, DeleteCourseDetailRequest>().ReverseMap();
        CreateMap<CourseDetail, DeletedCourseDetailResponse>().ReverseMap();

        CreateMap<CourseDetail, GetCourseDetailRequest>().ReverseMap();
        CreateMap<CourseDetail, GetCourseDetailResponse>()
            .ForMember(destinationMember: p => p.CourseCategoryName,
            memberOptions: opt => opt.MapFrom(p => p.CourseCategory.Name))
            .ReverseMap();

        CreateMap<CourseDetail, GetListedCourseDetailResponse>()
            .ForMember(destinationMember: p => p.CourseCategoryName,
            memberOptions: opt => opt.MapFrom(p => p.CourseCategory.Name))
            .ReverseMap();
        CreateMap<Paginate<CourseDetail>, Paginate<GetListedCourseDetailResponse>>().ReverseMap();
    }
}
