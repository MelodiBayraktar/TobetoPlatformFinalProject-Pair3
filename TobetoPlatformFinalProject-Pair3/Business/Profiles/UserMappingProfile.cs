using AutoMapper;
using Business.Dtos.Auth.Requests;
using Business.Dtos.Auth.Responses;
using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, CreateUserRequest>().ReverseMap();
        CreateMap<User, CreatedUserResponse>().ReverseMap();

        CreateMap<User, UpdateUserRequest>().ReverseMap();
        CreateMap<User, UpdatedUserResponse>().ReverseMap();

        CreateMap<User, DeleteUserRequest>().ReverseMap();
        CreateMap<User, DeletedUserResponse>().ReverseMap();

        CreateMap<User, GetUserRequest>().ReverseMap();
        CreateMap<User, GetUserResponse>().ReverseMap();

        CreateMap<User, GetListedUserResponse>().ReverseMap();
        CreateMap<Paginate<User>, Paginate<GetListedUserResponse>>().ReverseMap();

        CreateMap<User, AuthForRegisterRequest>().ReverseMap();
        CreateMap<User, AuthForRegisterResponse>().ReverseMap();

        CreateMap<User, AuthForLoginRequest>().ReverseMap();
        CreateMap<User, AuthForLoginResponse>().ReverseMap();

        CreateMap<GetUserResponse, AuthForRegisterResponse>().ReverseMap();
        CreateMap<GetUserResponse, AuthForLoginResponse>().ReverseMap();

        //CreateMap<User, UpdateUserPasswordRequest>().ReverseMap();

        CreateMap<UpdateUserPasswordRequest, User>()
    .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
    .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());
        CreateMap<User, UpdateUserPasswordResponse>().ReverseMap();

        //CreateMap<AuthForLoginRequest, UpdateUserPasswordRequest>().ReverseMap();
        //CreateMap<AuthForLoginResponse, UpdateUserPasswordResponse>().ReverseMap();
    }
}
