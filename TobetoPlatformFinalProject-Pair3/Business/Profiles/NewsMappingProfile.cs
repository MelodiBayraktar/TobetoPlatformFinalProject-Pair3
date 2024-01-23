using AutoMapper;
using Business.Dtos.News.Requests;
using Business.Dtos.News.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class NewsMappingProfile : Profile
{
    public NewsMappingProfile()
    {
        CreateMap<News, CreateNewsRequest>().ReverseMap();
        CreateMap<News, CreatedNewsResponse>().ReverseMap();

        CreateMap<News, UpdateNewsRequest>().ReverseMap();
        CreateMap<News, UpdatedNewsResponse>().ReverseMap();

        CreateMap<News, DeleteNewsRequest>().ReverseMap();
        CreateMap<News, DeletedNewsResponse>().ReverseMap();

        CreateMap<News, GetNewsRequest>().ReverseMap();
        CreateMap<News, GetNewsResponse>().ForMember(destinationMember: p => p.AnnouncementsNewsCategoryName,
            memberOptions: opt => opt.MapFrom(p => p.AnnouncementsNewsCategory.Name)).ReverseMap();
        CreateMap<News, GetNewsResponse>().ForMember(destinationMember: p => p.ProjectName,
            memberOptions: opt => opt.MapFrom(p => p.Project.Name)).ReverseMap();

        CreateMap<News, GetListedNewsResponse>().ForMember(destinationMember: p => p.AnnouncementsNewsCategoryName,
            memberOptions: opt => opt.MapFrom(p => p.AnnouncementsNewsCategory.Name)).ReverseMap();
        CreateMap<News, GetListedNewsResponse>().ForMember(destinationMember: p => p.ProjectName,
                        memberOptions: opt => opt.MapFrom(p => p.Project.Name)).ReverseMap();
        CreateMap<Paginate<News>, Paginate<GetListedNewsResponse>>().ReverseMap();
    }
}
