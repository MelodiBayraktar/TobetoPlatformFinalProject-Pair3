using AutoMapper;
using Business.Abstracts;
using Business.Dtos.OperationClaim.Requests;
using Business.Dtos.OperationClaim.Responses;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;

using Entities.Concretes;

namespace Business.Concretes;

public class UserOperationClaimManager: IUserOperationClaimService
{
    
    IUserOperationClaimDal _userOperationClaimDal;
    IMapper _mapper;

    public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal, IMapper mapper)
    {
        _userOperationClaimDal = userOperationClaimDal;
        _mapper = mapper;
    }

    public async Task<CreatedUserOperationClaimResponse> AddAsync(CreateUserOperationClaimRequest createUserOperationClaimRequest)
    {
        var userOperationClaim = _mapper.Map<UserOperationClaim>(createUserOperationClaimRequest);
        var createUserOperationClaim = await _userOperationClaimDal.AddAsync(userOperationClaim);
        return _mapper.Map<CreatedUserOperationClaimResponse>(createUserOperationClaim);
    }

    public async Task<DeletedUserOperationClaimResponse> DeleteAsync(DeleteUserOperationClaimRequest deleteUserOperationClaimRequest)
    {
        var userOperationClaim = await _userOperationClaimDal.GetAsync(c => c.Id == deleteUserOperationClaimRequest.Id);
        var deleteUserOpertaionClaim = await _userOperationClaimDal.DeleteAsync(userOperationClaim);
        return _mapper.Map<DeletedUserOperationClaimResponse>(deleteUserOpertaionClaim);
    }

    public async Task<GetUserOperationClaimResponse> GetById(GetUserOperationClaimRequest getUserOperationClaimRequest)
    {
        var getUserOperationClaim = await _userOperationClaimDal.GetAsync(c => c.Id == getUserOperationClaimRequest.Id);
        return _mapper.Map<GetUserOperationClaimResponse>(getUserOperationClaim);
    }

    public async Task<IPaginate<GetListedUserOperationClaimResponse>> GetListAsync(PageRequest pageRequest)
    {
        var result = await _userOperationClaimDal.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedUserOperationClaimResponse> response = _mapper.Map<Paginate<GetListedUserOperationClaimResponse>>(result);
        return response;
    }

    public async Task<UpdatedUserOperationClaimResponse> UpdateAsync(UpdateUserOperationClaimRequest updateUserOperationClaimRequest)
    {
        var userOperationClaim = _mapper.Map<UserOperationClaim>(updateUserOperationClaimRequest);
        var updatedUserOperationClaim = await _userOperationClaimDal.UpdateAsync(userOperationClaim);
        return _mapper.Map<UpdatedUserOperationClaimResponse>(updatedUserOperationClaim);
    }
}