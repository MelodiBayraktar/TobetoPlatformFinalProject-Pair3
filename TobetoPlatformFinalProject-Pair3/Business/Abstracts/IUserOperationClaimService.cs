using Business.Dtos.OperationClaim.Requests;
using Business.Dtos.OperationClaim.Responses;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;

namespace Business.Abstracts;

public interface IUserOperationClaimService
{
    //kontrol edilecek 
    Task<IPaginate<GetListedUserOperationClaimResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedUserOperationClaimResponse> AddAsync(CreateUserOperationClaimRequest createUserOperationClaimRequest);
    Task<UpdatedUserOperationClaimResponse> UpdateAsync(UpdateUserOperationClaimRequest updateUserOperationClaimRequest);
    Task<DeletedUserOperationClaimResponse> DeleteAsync(DeleteUserOperationClaimRequest deleteUserOperationClaimRequest);
    Task<GetUserOperationClaimResponse> GetById(GetUserOperationClaimRequest getUserOperationClaimRequest);
}