using AutoMapper;
using Business.Dtos.Course.Requests;
using Business.Dtos.Course.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class CourseMappingProfile : Profile
{
    public CourseMappingProfile()
    {
        CreateMap<Course, CreateCourseRequest>().ReverseMap();
        CreateMap<Course, CreatedCourseResponse>().ReverseMap();

        CreateMap<Course, UpdateCourseRequest>().ReverseMap();
        CreateMap<Course, UpdatedCourseResponse>().ReverseMap();

        CreateMap<Course, DeleteCourseRequest>().ReverseMap();
        CreateMap<Course, DeletedCourseResponse>().ReverseMap();

        CreateMap<Course, GetCourseRequest>().ReverseMap();
        CreateMap<Course, GetCourseResponse>().ForMember(destinationMember: p => p.UserName,
            memberOptions: opt => opt.MapFrom(p => p.User.FirstName + " " + p.User.LastName)).ReverseMap();


        CreateMap<Course, GetListedCourseResponse>().ForMember(destinationMember: p => p.UserName,
                        memberOptions: opt => opt.MapFrom(p => p.User.FirstName + " " + p.User.LastName)).ReverseMap();
        CreateMap<Paginate<Course>, Paginate<GetListedCourseResponse>>().ReverseMap();
    }
}
