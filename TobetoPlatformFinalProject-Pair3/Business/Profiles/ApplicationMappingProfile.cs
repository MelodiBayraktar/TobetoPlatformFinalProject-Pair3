using AutoMapper;
using Business.Dtos.Application.Requests;
using Business.Dtos.Application.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<Application, CreateApplicationRequest>().ReverseMap();
        CreateMap<Application, CreatedApplicationResponse>().ReverseMap();

        CreateMap<Application, UpdateApplicationRequest>().ReverseMap();
        CreateMap<Application, UpdatedApplicationResponse>().ReverseMap();

        CreateMap<Application, DeleteApplicationRequest>().ReverseMap();
        CreateMap<Application, DeletedApplicationResponse>().ReverseMap();

        CreateMap<Application, GetApplicationRequest>().ReverseMap();
        CreateMap<Application, GetApplicationResponse>().ReverseMap();


        CreateMap<Application, GetListedApplicationResponse>().ForMember(destinationMember: p => p.ProjectName,
                        memberOptions: opt => opt.MapFrom(p => p.Project.Name)).ReverseMap();
        CreateMap<Paginate<Application>, Paginate<GetListedApplicationResponse>>().ReverseMap();
    }
}
