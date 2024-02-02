using AutoMapper;
using Business.Dtos.LiveCourse.Requests;
using Business.Dtos.LiveCourse.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class LiveCourseMappingProfile : Profile
{
    public LiveCourseMappingProfile()
    {
        CreateMap<LiveCourse, CreateLiveCourseRequest>().ReverseMap();
        CreateMap<LiveCourse, CreatedLiveCourseResponse>().ReverseMap();

        CreateMap<LiveCourse, UpdateLiveCourseRequest>().ReverseMap();
        CreateMap<LiveCourse, UpdatedLiveCourseResponse>().ReverseMap();

        CreateMap<LiveCourse, DeleteLiveCourseRequest>().ReverseMap();
        CreateMap<LiveCourse, DeletedLiveCourseResponse>().ReverseMap();

        CreateMap<LiveCourse, GetLiveCourseRequest>().ReverseMap();
        CreateMap<LiveCourse, GetLiveCourseResponse>()
            .ForMember(destinationMember: p => p.LiveCourseTitle,
            memberOptions: opt => opt.MapFrom(p => p.Course.Title))
       
            .ForMember(destinationMember: p => p.LiveCourseStartDate,
            memberOptions: opt => opt.MapFrom(p => p.CourseDetail.StartDate))

            .ForMember(destinationMember: p => p.LiveCourseEndDate,
            memberOptions: opt => opt.MapFrom(p => p.CourseDetail.EndDate))

            .ForMember(destinationMember: p => p.LiveCourseSpentTime,
            memberOptions: opt => opt.MapFrom(p => p.CourseDetail.SpentTime))

            .ForMember(destinationMember: p => p.LiveCourseCategoryName,
            memberOptions: opt => opt.MapFrom(p => p.CourseDetail.CourseCategory.Name))

            .ForMember(destinationMember: p => p.LiveCourseContentCount,
            memberOptions: opt => opt.MapFrom(p => p.CourseDetail.ContentCount))

            .ForMember(destinationMember: p => p.LiveCourseIsFavorited,
            memberOptions: opt => opt.MapFrom(p => p.CourseDetail.IsFavorited))

            .ForMember(destinationMember: p => p.LiveCourseIsLiked,
            memberOptions: opt => opt.MapFrom(p => p.CourseDetail.IsLiked))
            .ReverseMap();

        
        CreateMap<LiveCourse, GetListedLiveCourseResponse>()
            .ForMember(destinationMember: p => p.LiveCourseTitle,
            memberOptions: opt => opt.MapFrom(p => p.Course.Title))

            .ForMember(destinationMember: p => p.LiveCourseStartDate,
            memberOptions: opt => opt.MapFrom(p => p.CourseDetail.StartDate))

            .ForMember(destinationMember: p => p.LiveCourseEndDate,
            memberOptions: opt => opt.MapFrom(p => p.CourseDetail.EndDate))

            .ForMember(destinationMember: p => p.LiveCourseSpentTime,
            memberOptions: opt => opt.MapFrom(p => p.CourseDetail.SpentTime))

            .ForMember(destinationMember: p => p.LiveCourseCategoryName,
            memberOptions: opt => opt.MapFrom(p => p.CourseDetail.CourseCategory.Name))

            .ForMember(destinationMember: p => p.LiveCourseContentCount,
            memberOptions: opt => opt.MapFrom(p => p.CourseDetail.ContentCount))

            .ForMember(destinationMember: p => p.LiveCourseIsFavorited,
            memberOptions: opt => opt.MapFrom(p => p.CourseDetail.IsFavorited))

            .ForMember(destinationMember: p => p.LiveCourseIsLiked,
            memberOptions: opt => opt.MapFrom(p => p.CourseDetail.IsLiked))
            .ReverseMap();
        
        CreateMap<Paginate<LiveCourse>, Paginate<GetListedLiveCourseResponse>>().ReverseMap();
    }
}
