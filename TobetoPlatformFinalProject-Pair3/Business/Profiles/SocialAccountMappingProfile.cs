using AutoMapper;
using Business.Dtos.SocialAccount.Requests;
using Business.Dtos.SocialAccount.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class SocialAccountMappingProfile : Profile
{
    public SocialAccountMappingProfile()
    {
        CreateMap<SocialAccount, CreateSocialAccountRequest>().ReverseMap();
        CreateMap<SocialAccount, CreatedSocialAccountResponse>().ReverseMap();

        CreateMap<SocialAccount, UpdateSocialAccountRequest>().ReverseMap();
        CreateMap<SocialAccount, UpdatedSocialAccountResponse>().ReverseMap();

        CreateMap<SocialAccount, DeleteSocialAccountRequest>().ReverseMap();
        CreateMap<SocialAccount, DeletedSocialAccountResponse>().ReverseMap();

        CreateMap<SocialAccount, GetSocialAccountRequest>().ReverseMap();
        CreateMap<SocialAccount, GetSocialAccountResponse>()
            .ForMember(destinationMember: p => p.UserName,
            memberOptions: opt => opt.MapFrom(p => p.User.FirstName + " " + p.User.LastName))
            .ReverseMap();
        
        CreateMap<SocialAccount, GetListedSocialAccountResponse>()
            .ForMember(destinationMember: p => p.UserName,
                        memberOptions: opt => opt.MapFrom(p => p.User.FirstName + " " + p.User.LastName))
            .ReverseMap();

        CreateMap<Paginate<SocialAccount>, Paginate<GetListedSocialAccountResponse>>().ReverseMap();
    }
}
