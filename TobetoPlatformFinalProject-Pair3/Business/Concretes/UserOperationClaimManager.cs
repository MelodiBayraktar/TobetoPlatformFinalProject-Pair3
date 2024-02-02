using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Announcement.Responses;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Business.Dtos.OperationClaim.Requests;
using Business.Dtos.OperationClaim.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.GetUserId;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;

using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

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

    //[SecuredOperation("userOperationClaims.add,admin")]
    public async Task<CreatedUserOperationClaimResponse> AddAsync(CreateUserOperationClaimRequest createUserOperationClaimRequest)
    {
        var userOperationClaim = _mapper.Map<UserOperationClaim>(createUserOperationClaimRequest);
        Expression<Func<UserOperationClaim, object>> includeExpressionForUser = x => x.User;
        Expression<Func<UserOperationClaim, object>> includeExpressionForOperationClaim = y => y.OperationClaim;
        var createUserOperationClaim = await _userOperationClaimDal.AddAsync(userOperationClaim, includeExpressionForUser,includeExpressionForOperationClaim);
        return _mapper.Map<CreatedUserOperationClaimResponse>(createUserOperationClaim);    
    }

    //[SecuredOperation("userOperationClaims.delete,admin")]
    public async Task<DeletedUserOperationClaimResponse> DeleteAsync(DeleteUserOperationClaimRequest deleteUserOperationClaimRequest)
    {
        var userOperationClaim = await _userOperationClaimDal.GetAsync(c => c.Id == deleteUserOperationClaimRequest.Id);
        var deleteUserOpertaionClaim = await _userOperationClaimDal.DeleteAsync(userOperationClaim);
        DeletedUserOperationClaimResponse response = _mapper.Map<DeletedUserOperationClaimResponse>(deleteUserOpertaionClaim);
        return response;
    }

    public async Task<GetUserOperationClaimResponse> GetById(GetUserOperationClaimRequest getUserOperationClaimRequest)
    {
        var getUserOperationClaim = await _userOperationClaimDal.GetAsync(c => c.Id == getUserOperationClaimRequest.Id,
            include: p => p.Include(p => p.User).Include(p => p.OperationClaim));
        GetUserOperationClaimResponse response = _mapper.Map<GetUserOperationClaimResponse>(getUserOperationClaim);
        return response;
    }

    public async Task<IPaginate<GetListedUserOperationClaimResponse>> GetListAsync(PageRequest pageRequest)
    {
        var result = await _userOperationClaimDal.GetListAsync(include: p => p.Include(p => p.User).Include(p => p.OperationClaim),index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedUserOperationClaimResponse> response = _mapper.Map<Paginate<GetListedUserOperationClaimResponse>>(result);
        return response;
    }

    [SecuredOperation("userOperationClaims.update,admin")]
    public async Task<UpdatedUserOperationClaimResponse> UpdateAsync(UpdateUserOperationClaimRequest updateUserOperationClaimRequest)
    {
        var result = await _userOperationClaimDal.GetAsync(predicate: a => a.Id == updateUserOperationClaimRequest.Id);
        _mapper.Map(updateUserOperationClaimRequest, result);
        await _userOperationClaimDal.UpdateAsync(result);
        UpdatedUserOperationClaimResponse response = _mapper.Map<UpdatedUserOperationClaimResponse>(result);
        return response;
    }
}