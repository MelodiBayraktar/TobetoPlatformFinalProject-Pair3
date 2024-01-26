using AutoMapper;
using Business.Dtos.Ability.Requests;
using Business.Dtos.Ability.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class AbilityMappingProfile : Profile
    {
        public AbilityMappingProfile()
        {
            CreateMap<Ability, CreateAbilityRequest>().ReverseMap();
            // CreateMap<Ability, CreateAbilityRequest>().ForMember(destinationMember: p => p.UserId,
            //     memberOptions: o => o.MapFrom(p => p.User.Id)).ReverseMap();

            CreateMap<Ability, CreatedAbilityResponse>().ForMember(destinationMember: p => p.FirstName,
                memberOptions: opt => opt.MapFrom(p => p.User.FirstName)).ReverseMap();

            //CreateMap<Ability, CreatedAbilityResponse>().ForMember(destinationMember: p => p.UserId,
            //     memberOptions: o => o.MapFrom(p => p.User.Id)).ReverseMap();

            CreateMap<Ability, UpdateAbilityRequest>().ReverseMap();
            CreateMap<Ability, UpdatedAbilityResponse>().ReverseMap();

            CreateMap<Ability, DeleteAbilityRequest>().ReverseMap();
            CreateMap<Ability, DeletedAbilityResponse>().ReverseMap();

            CreateMap<Ability, GetAbilityRequest>().ReverseMap();
            CreateMap<Ability, GetAbilityResponse>().ForMember(destinationMember: p => p.UserName,
                memberOptions: opt => opt.MapFrom(p => p.User.FirstName + " " + p.User.LastName)).ReverseMap();
            
            CreateMap<Ability, GetListedAbilityResponse>().ForMember(destinationMember: p => p.UserName,
                            memberOptions: opt => opt.MapFrom(p => p.User.FirstName + " " + p.User.LastName)).ReverseMap();
            CreateMap<Paginate<Ability>, Paginate<GetListedAbilityResponse>>().ReverseMap();
        }
    }
}
