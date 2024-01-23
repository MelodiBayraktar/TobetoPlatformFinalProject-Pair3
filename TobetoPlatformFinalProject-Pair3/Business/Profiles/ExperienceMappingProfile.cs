using AutoMapper;
using Business.Dtos.Experience.Requests;
using Business.Dtos.Experience.Responses;
using Core.DataAccess.Paging;
using Entities;
using Entities.Concretes;

namespace Business.Profiles;

public class ExperienceMappingProfile : Profile
{
    public ExperienceMappingProfile()
    {
        CreateMap<Experience, CreateExperienceRequest>().ReverseMap();
        CreateMap<Experience, CreatedExperienceResponse>().ReverseMap();

        CreateMap<Experience, UpdateExperienceRequest>().ReverseMap();
        CreateMap<Experience, UpdatedExperienceResponse>().ReverseMap();

        CreateMap<Experience, DeleteExperienceRequest>().ReverseMap();
        CreateMap<Experience, DeletedExperienceResponse>().ReverseMap();

        CreateMap<Experience, GetExperienceRequest>().ReverseMap();
        CreateMap<Experience, GetExperienceResponse>().ForMember(destinationMember: p => p.UserName,
            memberOptions: opt => opt.MapFrom(p => p.User.FirstName + " " + p.User.LastName)).ReverseMap();
        
        CreateMap<Experience, GetListedExperienceResponse>().ForMember(destinationMember: p => p.UserName,
                        memberOptions: opt => opt.MapFrom(p => p.User.FirstName + " " + p.User.LastName)).ReverseMap();
        CreateMap<Paginate<Experience>, Paginate<GetListedExperienceResponse>>().ReverseMap();
    }
}
