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
        CreateMap<LiveCourse, GetLiveCourseResponse>().ReverseMap();


        CreateMap<LiveCourse, GetListedLiveCourseResponse>().ForMember(destinationMember: p => p.CourseDetailName,
                        memberOptions: opt => opt.MapFrom(p => p.CourseDetail.Name)).ReverseMap();
        CreateMap<Paginate<LiveCourse>, Paginate<GetListedLiveCourseResponse>>().ReverseMap();
    }
}
