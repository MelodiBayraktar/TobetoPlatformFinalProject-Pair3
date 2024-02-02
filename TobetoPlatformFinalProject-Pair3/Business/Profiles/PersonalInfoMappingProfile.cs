using AutoMapper;
using Business.Dtos.PersonalInfo.Requests;
using Business.Dtos.PersonalInfo.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class PersonalInfoMappingProfile : Profile
{
    public PersonalInfoMappingProfile()
    {
        CreateMap<PersonalInfo, CreatePersonalInfoRequest>().ReverseMap();
        CreateMap<PersonalInfo, CreatedPersonalInfoResponse>()
            .ForMember(destinationMember: p => p.FirstName,
            memberOptions: opt => opt.MapFrom(p => p.User.FirstName))

            .ForMember(destinationMember: p => p.LastName,
            memberOptions: opt => opt.MapFrom(p => p.User.LastName))

            .ForMember(destinationMember: p => p.Email,
            memberOptions: opt => opt.MapFrom(p => p.User.Email))
            .ReverseMap();

        CreateMap<PersonalInfo, UpdatePersonalInfoRequest>().ReverseMap();
        CreateMap<PersonalInfo, UpdatedPersonalInfoResponse>().ReverseMap();

        CreateMap<PersonalInfo, DeletePersonalInfoRequest>().ReverseMap();
        CreateMap<PersonalInfo, DeletedPersonalInfoResponse>().ReverseMap();

        CreateMap<PersonalInfo, GetPersonalInfoRequest>().ReverseMap();
        CreateMap<PersonalInfo, GetPersonalInfoResponse>()
            .ForMember(destinationMember: p => p.FirstName,
            memberOptions: opt => opt.MapFrom(p => p.User.FirstName))

            .ForMember(destinationMember: p => p.LastName,
            memberOptions: opt => opt.MapFrom(p => p.User.LastName))

            .ForMember(destinationMember: p => p.Email,
            memberOptions: opt => opt.MapFrom(p => p.User.Email))
            .ReverseMap();


        CreateMap<PersonalInfo, GetListedPersonalInfoResponse>()
            .ForMember(destinationMember: p => p.FirstName,
            memberOptions: opt => opt.MapFrom(p => p.User.FirstName))

            .ForMember(destinationMember: p => p.LastName,
            memberOptions: opt => opt.MapFrom(p => p.User.LastName))

            .ForMember(destinationMember: p => p.Email,
            memberOptions: opt => opt.MapFrom(p => p.User.Email))
            .ReverseMap();

        CreateMap<Paginate<PersonalInfo>, Paginate<GetListedPersonalInfoResponse>>().ReverseMap();
    }
}
