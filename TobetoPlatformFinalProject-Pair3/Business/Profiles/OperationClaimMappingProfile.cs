using AutoMapper;
using Business.Dtos.OperationClaim.Requests;
using Business.Dtos.OperationClaim.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class OperationClaimMappingProfile : Profile
{
    public OperationClaimMappingProfile()
    {
        CreateMap<OperationClaim, CreateOperationClaimRequest>().ReverseMap();
        CreateMap<OperationClaim, CreatedOperationClaimResponse>().ReverseMap();

        CreateMap<OperationClaim, UpdateOperationClaimRequest>().ReverseMap();
        CreateMap<OperationClaim, UpdatedOperationClaimResponse>().ReverseMap();

        CreateMap<OperationClaim, DeleteOperationClaimRequest>().ReverseMap();
        CreateMap<OperationClaim, DeletedOperationClaimResponse>().ReverseMap();

        CreateMap<OperationClaim, GetOperationClaimRequest>().ReverseMap();
        CreateMap<OperationClaim, GetOperationClaimResponse>().ReverseMap();

        CreateMap<OperationClaim, GetListedOperationClaimResponse>().ReverseMap();
        CreateMap<Paginate<OperationClaim>, Paginate<GetListedOperationClaimResponse>>().ReverseMap();
        
    }
}