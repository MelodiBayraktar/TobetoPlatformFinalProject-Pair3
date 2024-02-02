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
            CreateMap<AsyncCourse, GetAsyncCourseResponse>()
                .ForMember(destinationMember: p => p.AsyncCourseName,
                memberOptions: opt => opt.MapFrom(p => p.Course.Title))

                .ForMember(destinationMember: p => p.AsyncCourseStartDate,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.StartDate))

                .ForMember(destinationMember: p => p.AsyncCourseEndDate,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.EndDate))

                .ForMember(destinationMember: p => p.AsyncCourseSpentTime,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.SpentTime))

                .ForMember(destinationMember: p => p.AsyncCourseCategoryName,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.CourseCategory.Name))

                .ForMember(destinationMember: p => p.AsyncCourseContentCount,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.ContentCount))

                .ForMember(destinationMember: p => p.AsyncCourseIsFavorited,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.IsFavorited))

                .ForMember(destinationMember: p => p.AsyncCourseIsLiked,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.IsLiked))
                .ReverseMap();

            
            CreateMap<AsyncCourse, GetListedAsyncCourseResponse>()
                .ForMember(destinationMember: p => p.AsyncCourseName,
                memberOptions: opt => opt.MapFrom(p => p.Course.Title))

                .ForMember(destinationMember: p => p.AsyncCourseStartDate,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.StartDate))

                .ForMember(destinationMember: p => p.AsyncCourseEndDate,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.EndDate))

                .ForMember(destinationMember: p => p.AsyncCourseSpentTime,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.SpentTime))

                .ForMember(destinationMember: p => p.AsyncCourseCategoryName,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.CourseCategory.Name))

                .ForMember(destinationMember: p => p.AsyncCourseContentCount,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.ContentCount))

                .ForMember(destinationMember: p => p.AsyncCourseIsFavorited,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.IsFavorited))

                .ForMember(destinationMember: p => p.AsyncCourseIsLiked,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.IsLiked))
                .ReverseMap();
            
            CreateMap<Paginate<AsyncCourse>, Paginate<GetListedAsyncCourseResponse>>().ReverseMap();
        }
    }
}
