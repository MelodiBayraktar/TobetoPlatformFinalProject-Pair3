using AutoMapper;
using Business.Dtos.Education.Requests;
using Business.Dtos.Education.Responses;
using Core.DataAccess.Paging;
using Entities;
using Entities.Concretes;

namespace Business.Profiles;

public class EducationMappingProfile : Profile
{
    public EducationMappingProfile()
    {
        CreateMap<Education, CreateEducationRequest>().ReverseMap();
        CreateMap<Education, CreatedEducationResponse>().ReverseMap();

        CreateMap<Education, UpdateEducationRequest>().ReverseMap();
        CreateMap<Education, UpdatedEducationResponse>().ReverseMap();

        CreateMap<Education, DeleteEducationRequest>().ReverseMap();
        CreateMap<Education, DeletedEducationResponse>().ReverseMap();

        CreateMap<Education, GetEducationRequest>().ReverseMap();
        CreateMap<Education, GetEducationResponse>().ForMember(destinationMember: p => p.UserName,
            memberOptions: opt => opt.MapFrom(p => p.User.FirstName + " " + p.User.LastName)).ReverseMap();


        CreateMap<Education, GetListedEducationResponse>().ForMember(destinationMember: p => p.UserName,
                        memberOptions: opt => opt.MapFrom(p => p.User.FirstName + " " + p.User.LastName)).ReverseMap();
        CreateMap<Paginate<Education>, Paginate<GetListedEducationResponse>>().ReverseMap();
    }
}
