using AutoMapper;
using Business.Dtos.Session.Requests;
using Business.Dtos.Session.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class SessionMappingProfile : Profile
{
    public SessionMappingProfile()
    {
        CreateMap<Session, CreateSessionRequest>().ReverseMap();
        CreateMap<Session, CreatedSessionResponse>().ReverseMap();

        CreateMap<Session, UpdateSessionRequest>().ReverseMap();
        CreateMap<Session, UpdatedSessionResponse>().ReverseMap();

        CreateMap<Session, DeleteSessionRequest>().ReverseMap();
        CreateMap<Session, DeletedSessionResponse>().ReverseMap();

        CreateMap<Session, GetSessionRequest>().ReverseMap();
        CreateMap<Session, GetSessionResponse>().ReverseMap();


        CreateMap<Session, GetListedSessionResponse>().ReverseMap();
        CreateMap<Paginate<Session>, Paginate<GetListedSessionResponse>>().ReverseMap();
    }
}
