using AutoMapper;
using Azure.Core;
using Business.Abstracts;
using Business.Dtos.OperationClaim.Requests;
using Business.Dtos.OperationClaim.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using DataAccess.Concretes;
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

    public async Task<CreatedOperationClaimResponse> AddAsync(CreateOperationClaimRequest createOperationClaimRequest)
    {
        var operationClaim = _mapper.Map<OperationClaim>(createOperationClaimRequest);
        var createOperationClaim = await _operationClaimDal.AddAsync(operationClaim);
        return _mapper.Map<CreatedOperationClaimResponse>(createOperationClaim);
    }

    public async Task<DeletedOperationClaimResponse> DeleteAsync(DeleteOperationClaimRequest deleteOperationClaimRequest)
    {
        var operationClaim = await _operationClaimDal.GetAsync(c => c.Id == deleteOperationClaimRequest.Id);
        var deleteOperationClaim = await _operationClaimDal.DeleteAsync(operationClaim);
        return _mapper.Map<DeletedOperationClaimResponse>(deleteOperationClaim);
    }

    public async Task<GetOperationClaimResponse> GetById(GetOperationClaimRequest getOperationClaimRequest)
    {
        var getOperationClaim = await _operationClaimDal.GetAsync(c => c.Id == getOperationClaimRequest.Id);
        return _mapper.Map<GetOperationClaimResponse>(getOperationClaim);
    }

    public async Task<IPaginate<GetListedOperationClaimResponse>> GetListAsync(PageRequest pageRequest)
    {
        var result = await _operationClaimDal.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedOperationClaimResponse> response = _mapper.Map<Paginate<GetListedOperationClaimResponse>>(result);
        return response;
    }

    public async Task<UpdatedOperationClaimResponse> UpdateAsync(UpdateOperationClaimRequest updateOperationClaimRequest)
    {
        var operationClaim = _mapper.Map<OperationClaim>(updateOperationClaimRequest);
        var updatedOperationClaim = await _operationClaimDal.UpdateAsync(operationClaim);
        return _mapper.Map<UpdatedOperationClaimResponse>(updatedOperationClaim);
    }
}