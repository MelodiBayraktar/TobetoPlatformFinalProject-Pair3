using AutoMapper;
using Business.Dtos.AsyncCourse.Requests;
using Business.Dtos.AsyncCourse.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class AsyncCourseMappingProfile : Profile
    {
        public AsyncCourseMappingProfile()
        {
            CreateMap<AsyncCourse, CreateAsyncCourseRequest>().ReverseMap();
            CreateMap<AsyncCourse, CreatedAsyncCourseResponse>().ReverseMap();

            CreateMap<AsyncCourse, UpdateAsyncCourseRequest>().ReverseMap();
            CreateMap<AsyncCourse, UpdatedAsyncCourseResponse>().ReverseMap();

            CreateMap<AsyncCourse, DeleteAsyncCourseRequest>().ReverseMap();
            CreateMap<AsyncCourse, DeletedAsyncCourseResponse>().ReverseMap();

            CreateMap<AsyncCourse, GetAsyncCourseRequest>().ReverseMap();
            CreateMap<AsyncCourse, GetAsyncCourseResponse>().ReverseMap();


            CreateMap<AsyncCourse, GetListedAsyncCourseResponse>().ForMember(destinationMember: p => p.CourseDetailName,
                            memberOptions: opt => opt.MapFrom(p => p.CourseDetail.Name)).ReverseMap();
            CreateMap<Paginate<AsyncCourse>, Paginate<GetListedAsyncCourseResponse>>().ReverseMap();
        }
    }
}
