using System.Linq.Expressions;
using AutoMapper;
using Azure.Core;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
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
using DataAccess.Concretes;
using Entities;
using Entities.Concretes;

namespace Business.Concretes;

public class OperationClaimManager : IOperationClaimService
{
    
    IOperationClaimDal _operationClaimDal;
    IMapper _mapper;

    public OperationClaimManager(IOperationClaimDal operationClaimDal, IMapper mapper)
    {
        _operationClaimDal = operationClaimDal;
        _mapper = mapper;
    }
    //[SecuredOperation("operationClaims.add,admin")]
    public async Task<CreatedOperationClaimResponse> AddAsync(CreateOperationClaimRequest createOperationClaimRequest)
    {
        OperationClaim operationClaim = _mapper.Map<OperationClaim>(createOperationClaimRequest);
        var createOperationClaim = await _operationClaimDal.AddAsync(operationClaim);
        CreatedOperationClaimResponse response = _mapper.Map<CreatedOperationClaimResponse>(createOperationClaim);
        return response;
    }

    [SecuredOperation("operationClaims.delete,admin")]
    public async Task<DeletedOperationClaimResponse> DeleteAsync(DeleteOperationClaimRequest deleteOperationClaimRequest)
    {
        OperationClaim operationClaim = await _operationClaimDal.GetAsync(c => c.Id == deleteOperationClaimRequest.Id);
        var deleteOperationClaim = await _operationClaimDal.DeleteAsync(operationClaim);
        DeletedOperationClaimResponse response = _mapper.Map<DeletedOperationClaimResponse>(deleteOperationClaim);
        return response;
    }

    public async Task<GetOperationClaimResponse> GetById(GetOperationClaimRequest getOperationClaimRequest)
    {
        OperationClaim getOperationClaim = await _operationClaimDal.GetAsync(c => c.Id == getOperationClaimRequest.Id);
        GetOperationClaimResponse response = _mapper.Map<GetOperationClaimResponse>(getOperationClaim);
        return response;
    }

    public async Task<IPaginate<GetListedOperationClaimResponse>> GetListAsync(PageRequest pageRequest)
    {
        var result = await _operationClaimDal.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedOperationClaimResponse> response = _mapper.Map<Paginate<GetListedOperationClaimResponse>>(result);
        return response;
    }

    [SecuredOperation("operationClaims.update,admin")]
    public async Task<UpdatedOperationClaimResponse> UpdateAsync(UpdateOperationClaimRequest updateOperationClaimRequest)
    {
        var result = await _operationClaimDal.GetAsync(predicate: a => a.Id == updateOperationClaimRequest.Id);
        _mapper.Map(updateOperationClaimRequest, result);
        await _operationClaimDal.UpdateAsync(result);
        UpdatedOperationClaimResponse response = _mapper.Map<UpdatedOperationClaimResponse>(result);
        return response;
    }
}