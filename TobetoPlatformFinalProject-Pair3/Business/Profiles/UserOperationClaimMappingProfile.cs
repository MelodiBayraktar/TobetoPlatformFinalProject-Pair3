using AutoMapper;
using Business.Dtos.OperationClaim.Requests;
using Business.Dtos.OperationClaim.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class UserOperationClaimMappingProfile : Profile
{
    public UserOperationClaimMappingProfile()
    {
        CreateMap<UserOperationClaim, CreateUserOperationClaimRequest>().ReverseMap();
        CreateMap<UserOperationClaim, CreatedUserOperationClaimResponse>().ReverseMap();

        CreateMap<UserOperationClaim, UpdateUserOperationClaimRequest>().ReverseMap();
        CreateMap<UserOperationClaim, UpdatedUserOperationClaimResponse>().ReverseMap();

        CreateMap<UserOperationClaim, DeleteUserOperationClaimRequest>().ReverseMap();
        CreateMap<UserOperationClaim, DeletedUserOperationClaimResponse>().ReverseMap();

        CreateMap<UserOperationClaim, GetUserOperationClaimRequest>().ReverseMap();
        CreateMap<UserOperationClaim, GetUserOperationClaimResponse>().ReverseMap();

        CreateMap<UserOperationClaim, GetListedUserOperationClaimResponse>().ReverseMap();
        CreateMap<Paginate<UserOperationClaim>, Paginate<GetListedUserOperationClaimResponse>>().ReverseMap();
        
    }
}