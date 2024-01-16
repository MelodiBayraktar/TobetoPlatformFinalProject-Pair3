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
        CreateMap<PersonalInfo, CreatedPersonalInfoResponse>().ReverseMap();

        CreateMap<PersonalInfo, UpdatePersonalInfoRequest>().ReverseMap();
        CreateMap<PersonalInfo, UpdatedPersonalInfoResponse>().ReverseMap();

        CreateMap<PersonalInfo, DeletePersonalInfoRequest>().ReverseMap();
        CreateMap<PersonalInfo, DeletedPersonalInfoResponse>().ReverseMap();

        CreateMap<PersonalInfo, GetPersonalInfoRequest>().ReverseMap();
        CreateMap<PersonalInfo, GetPersonalInfoResponse>().ReverseMap();


        CreateMap<PersonalInfo, GetListedPersonalInfoResponse>().ForMember(destinationMember: p => p.UserName,
                        memberOptions: opt => opt.MapFrom(p => p.User.FirstName + " " + p.User.LastName)).ReverseMap();
        CreateMap<Paginate<PersonalInfo>, Paginate<GetListedPersonalInfoResponse>>().ReverseMap();
    }
}
