using AutoMapper;
using Business.Dtos.AsyncLessonsOfContent.Requests;
using Business.Dtos.AsyncLessonsOfContent.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class AsyncLessonsOfContentMappingProfile : Profile
{
    public AsyncLessonsOfContentMappingProfile()
    {
        CreateMap<AsyncLessonsOfContent, CreateAsyncLessonsOfContentRequest>().ReverseMap();
        CreateMap<AsyncLessonsOfContent, CreatedAsyncLessonsOfContentResponse>().ReverseMap();

        CreateMap<AsyncLessonsOfContent, UpdateAsyncLessonsOfContentRequest>().ReverseMap();
        CreateMap<AsyncLessonsOfContent, UpdatedAsyncLessonsOfContentResponse>().ReverseMap();

        CreateMap<AsyncLessonsOfContent, DeleteAsyncLessonsOfContentRequest>().ReverseMap();
        CreateMap<AsyncLessonsOfContent, DeletedAsyncLessonsOfContentResponse>().ReverseMap();

        CreateMap<AsyncLessonsOfContent, GetAsyncLessonsOfContentRequest>().ReverseMap();
        CreateMap<AsyncLessonsOfContent, GetAsyncLessonsOfContentResponse>().ReverseMap();

        CreateMap<AsyncLessonsOfContent, GetListedAsyncLessonsOfContentResponse>().ForMember(destinationMember: p => p.AsyncContentName,
                memberOptions: opt => opt.MapFrom(p => p.AsyncContent.Name)).ReverseMap();

        CreateMap<Paginate<AsyncLessonsOfContent>, Paginate<GetListedAsyncLessonsOfContentResponse>>().ReverseMap();
    }
}
