using AutoMapper;
using Business.Dtos.ForeignLanguage.Requests;
using Business.Dtos.ForeignLanguage.Responses;
using Core.DataAccess.Paging;
using Entities;
using Entities.Concretes;

namespace Business.Profiles;

public class ForeignLanguageMappingProfile : Profile
{
    public ForeignLanguageMappingProfile()
    {
        CreateMap<ForeignLanguage, CreateForeignLanguageRequest>().ReverseMap();
        CreateMap<ForeignLanguage, CreatedForeignLanguageResponse>().ReverseMap();

        CreateMap<ForeignLanguage, UpdateForeignLanguageRequest>().ReverseMap();
        CreateMap<ForeignLanguage, UpdatedForeignLanguageResponse>().ReverseMap();

        CreateMap<ForeignLanguage, DeleteForeignLanguageRequest>().ReverseMap();
        CreateMap<ForeignLanguage, DeletedForeignLanguageResponse>().ReverseMap();

        CreateMap<ForeignLanguage, GetForeignLanguageRequest>().ReverseMap();
        CreateMap<ForeignLanguage, GetForeignLanguageResponse>()
            .ForMember(destinationMember: p => p.UserName,
            memberOptions: opt => opt.MapFrom(p => p.User.FirstName + " " + p.User.LastName))
            .ReverseMap();

        CreateMap<ForeignLanguage, GetListedForeignLanguageResponse>()
            .ForMember(destinationMember: p => p.UserName,
            memberOptions: opt => opt.MapFrom(p => p.User.FirstName + " " + p.User.LastName))
            .ReverseMap();
        CreateMap<Paginate<ForeignLanguage>, Paginate<GetListedForeignLanguageResponse>>().ReverseMap();
    }
}
