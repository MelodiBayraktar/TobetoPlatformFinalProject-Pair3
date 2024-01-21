using AutoMapper;
using Business.Dtos.Application.Responses;
using Business.Dtos.AsyncContent.Requests;
using Business.Dtos.AsyncContent.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class AsyncContentMappingProfile : Profile
{
    public AsyncContentMappingProfile()
    {
        CreateMap<AsyncContent, CreateAsyncContentRequest>().ReverseMap();
        //CreateMap<AsyncContent, CreatedAsyncContentResponse>().ReverseMap();

        CreateMap<AsyncContent, CreatedAsyncContentResponse>().ForMember(destinationMember: p => p.AsyncCourseId,
                memberOptions: opt => opt.MapFrom(p => p.AsyncCourse.Id)).ReverseMap();

        CreateMap<AsyncContent, UpdateAsyncContentRequest>().ReverseMap();
        CreateMap<AsyncContent, UpdatedAsyncContentResponse>().ReverseMap();

        CreateMap<AsyncContent, DeleteAsyncContentRequest>().ReverseMap();
        CreateMap<AsyncContent, DeletedAsyncContentResponse>().ReverseMap();

        CreateMap<AsyncContent, GetAsyncContentRequest>().ReverseMap();
        CreateMap<AsyncContent, GetAsyncContentResponse>().ReverseMap();



        CreateMap<AsyncContent, GetListedAsyncContentResponse>().ReverseMap();
        CreateMap<Paginate<AsyncContent>, Paginate<GetListedAsyncContentResponse>>().ReverseMap();
    }
}
