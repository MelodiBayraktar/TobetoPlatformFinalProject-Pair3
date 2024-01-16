using Business.Dtos.OperationClaim.Requests;
using Business.Dtos.OperationClaim.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IOperationClaimService
{
    Task<IPaginate<GetListedOperationClaimResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedOperationClaimResponse> AddAsync(CreateOperationClaimRequest createOperationClaimRequest);
    Task<UpdatedOperationClaimResponse> UpdateAsync(UpdateOperationClaimRequest updateOperationClaimRequest);
    Task<DeletedOperationClaimResponse> DeleteAsync(DeleteOperationClaimRequest deleteOperationClaimRequest);
    Task<GetOperationClaimResponse> GetById(GetOperationClaimRequest getOperationClaimRequest);
    
}