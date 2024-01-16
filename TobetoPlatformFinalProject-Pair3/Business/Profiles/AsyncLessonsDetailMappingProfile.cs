using AutoMapper;
using Business.Dtos.AsyncLessonsDetail.Requests;
using Business.Dtos.AsyncLessonsDetail.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class AsyncLessonsDetailMappingProfile : Profile
    {
        public AsyncLessonsDetailMappingProfile()
        {
            CreateMap<AsyncLessonsDetail, CreateAsyncLessonsDetailRequest>().ReverseMap();
            CreateMap<AsyncLessonsDetail, CreatedAsyncLessonsDetailResponse>().ReverseMap();

            CreateMap<AsyncLessonsDetail, UpdateAsyncLessonsDetailRequest>().ReverseMap();
            CreateMap<AsyncLessonsDetail, UpdatedAsyncLessonsDetailResponse>().ReverseMap();

            CreateMap<AsyncLessonsDetail, DeleteAsyncLessonsDetailRequest>().ReverseMap();
            CreateMap<AsyncLessonsDetail, DeletedAsyncLessonsDetailResponse>().ReverseMap();

            CreateMap<AsyncLessonsDetail, GetAsyncLessonsDetailRequest>().ReverseMap();
            CreateMap<AsyncLessonsDetail, GetAsyncLessonsDetailResponse>().ReverseMap();


            CreateMap<AsyncLessonsDetail, GetListedAsyncLessonsDetailResponse>().ForMember(destinationMember: p => p.AsyncLessonsOfContentName,
                            memberOptions: opt => opt.MapFrom(p => p.AsyncLessonsOfContent.Name)).ReverseMap();
            CreateMap<Paginate<AsyncLessonsDetail>, Paginate<GetListedAsyncLessonsDetailResponse>>().ReverseMap();
        }
    }
}
