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
            //CreateMap<AsyncCourse, CreatedAsyncCourseResponse>().ReverseMap();

            CreateMap<AsyncCourse, CreatedAsyncCourseResponse>().ForMember(destinationMember: p => p.CourseDetailId,
                           memberOptions: opt => opt.MapFrom(p => p.CourseDetail.Id)).ReverseMap();

            CreateMap<AsyncCourse, CreatedAsyncCourseResponse>().ForMember(destinationMember: p => p.CourseId,
               memberOptions: opt => opt.MapFrom(p => p.Course.Id)).ReverseMap();

            CreateMap<AsyncCourse, UpdateAsyncCourseRequest>().ReverseMap();
            CreateMap<AsyncCourse, UpdatedAsyncCourseResponse>().ReverseMap();

            CreateMap<AsyncCourse, DeleteAsyncCourseRequest>().ReverseMap();
            CreateMap<AsyncCourse, DeletedAsyncCourseResponse>().ReverseMap();

            CreateMap<AsyncCourse, GetAsyncCourseRequest>().ReverseMap();
            
            CreateMap<AsyncCourse, GetAsyncCourseResponse>().ForMember(destinationMember: p => p.AsyncCourseName,
                memberOptions: opt => opt.MapFrom(p => p.Course.Title)).ReverseMap();
            
            CreateMap<AsyncCourse, GetAsyncCourseResponse>().ForMember(destinationMember: p => p.AsyncCourseStartDate,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.StartDate )).ReverseMap();
            
            CreateMap<AsyncCourse, GetAsyncCourseResponse>().ForMember(destinationMember: p => p.AsyncCourseEndDate,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.EndDate )).ReverseMap();
            
            CreateMap<AsyncCourse, GetAsyncCourseResponse>().ForMember(destinationMember: p => p.AsyncCourseSpentTime,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.SpentTime )).ReverseMap();
            
            CreateMap<AsyncCourse, GetAsyncCourseResponse>().ForMember(destinationMember: p => p.AsyncCourseCategoryName,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.CourseCategory.Name)).ReverseMap();
            
            CreateMap<AsyncCourse, GetAsyncCourseResponse>().ForMember(destinationMember: p => p.AsyncCourseContentCount,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.ContentCount)).ReverseMap();
            
            CreateMap<AsyncCourse, GetAsyncCourseResponse>().ForMember(destinationMember: p => p.AsyncCourseIsFavorited,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.IsFavorited)).ReverseMap();
            
            CreateMap<AsyncCourse, GetAsyncCourseResponse>().ForMember(destinationMember: p => p.AsyncCourseIsLiked,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.IsLiked)).ReverseMap();

            
            CreateMap<AsyncCourse, GetListedAsyncCourseResponse>().ForMember(destinationMember: p => p.AsyncCourseName,
                memberOptions: opt => opt.MapFrom(p => p.Course.Title)).ReverseMap();
            
            CreateMap<AsyncCourse, GetListedAsyncCourseResponse>().ForMember(destinationMember: p => p.AsyncCourseStartDate,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.StartDate )).ReverseMap();
            
            CreateMap<AsyncCourse, GetListedAsyncCourseResponse>().ForMember(destinationMember: p => p.AsyncCourseEndDate,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.EndDate )).ReverseMap();
            
            CreateMap<AsyncCourse, GetListedAsyncCourseResponse>().ForMember(destinationMember: p => p.AsyncCourseSpentTime,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.SpentTime )).ReverseMap();
            
            CreateMap<AsyncCourse, GetListedAsyncCourseResponse>().ForMember(destinationMember: p => p.AsyncCourseCategoryName,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.CourseCategory.Name)).ReverseMap();
            
            CreateMap<AsyncCourse, GetListedAsyncCourseResponse>().ForMember(destinationMember: p => p.AsyncCourseContentCount,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.ContentCount)).ReverseMap();
            
            CreateMap<AsyncCourse, GetListedAsyncCourseResponse>().ForMember(destinationMember: p => p.AsyncCourseIsFavorited,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.IsFavorited)).ReverseMap();
            
            CreateMap<AsyncCourse, GetListedAsyncCourseResponse>().ForMember(destinationMember: p => p.AsyncCourseIsLiked,
                memberOptions: opt => opt.MapFrom(p => p.CourseDetail.IsLiked)).ReverseMap();
            
            CreateMap<Paginate<AsyncCourse>, Paginate<GetListedAsyncCourseResponse>>().ReverseMap();
        }
    }
}
