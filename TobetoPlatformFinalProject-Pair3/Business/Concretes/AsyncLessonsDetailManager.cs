using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Announcement.Responses;
using Business.Dtos.AsyncLessonsDetail.Requests;
using Business.Dtos.AsyncLessonsDetail.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AsyncLessonsDetailManager : IAsyncLessonsDetailService
{
    private IAsyncLessonsDetailDal _asyncLessonsDetailDal;
    private IMapper _mapper;

    public AsyncLessonsDetailManager(IAsyncLessonsDetailDal asyncLessonsDetailDal, IMapper mapper)
    {
        _asyncLessonsDetailDal = asyncLessonsDetailDal;
        _mapper = mapper;
    }
    [SecuredOperation("asyncLessonsDetails.add,admin")]
    [ValidationAspect(typeof(AsyncLessonsDetailRequestValidator))]
    public async Task<CreatedAsyncLessonsDetailResponse> AddAsync(CreateAsyncLessonsDetailRequest createAsyncLessonsDetailRequest)
    {
        AsyncLessonsDetail asyncLessonsDetail = _mapper.Map<AsyncLessonsDetail>(createAsyncLessonsDetailRequest);
        Expression<Func<AsyncLessonsDetail, object>> includeExpressionForAsyncLessonsOfContent = x => x.AsyncLessonsOfContent;
        var createAsyncLessonsDetail = await _asyncLessonsDetailDal.AddAsync(asyncLessonsDetail, includeExpressionForAsyncLessonsOfContent);
        CreatedAsyncLessonsDetailResponse response =  _mapper.Map<CreatedAsyncLessonsDetailResponse>(createAsyncLessonsDetail);    
        return response;
    }
    [SecuredOperation("asyncLessonsDetails.delete,admin")]
    public async Task<DeletedAsyncLessonsDetailResponse> DeleteAsync(DeleteAsyncLessonsDetailRequest deleteAsyncLessonsDetailRequest)
    {
        AsyncLessonsDetail asyncLessonsDetail = await _asyncLessonsDetailDal.GetAsync(c => c.Id == deleteAsyncLessonsDetailRequest.Id);
        await _asyncLessonsDetailDal.DeleteAsync(asyncLessonsDetail);
        DeletedAsyncLessonsDetailResponse response = _mapper.Map<DeletedAsyncLessonsDetailResponse>(asyncLessonsDetail);
        return response;
    }

    public async Task<GetAsyncLessonsDetailResponse> GetById(GetAsyncLessonsDetailRequest getAsyncLessonsDetailRequest)
    {
        AsyncLessonsDetail getAsyncLessonsDetail = await _asyncLessonsDetailDal.GetAsync(c => c.Id == getAsyncLessonsDetailRequest.Id,
            include: p => p.Include(p => p.AsyncLessonsOfContent));
        GetAsyncLessonsDetailResponse response =  _mapper.Map<GetAsyncLessonsDetailResponse>(getAsyncLessonsDetail);
        return response;
    }

    public async Task<IPaginate<GetListedAsyncLessonsDetailResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _asyncLessonsDetailDal.GetListAsync(include: p => p.Include(p => p.AsyncLessonsOfContent), 
            index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedAsyncLessonsDetailResponse> response = _mapper.Map<Paginate<GetListedAsyncLessonsDetailResponse>>(getList);
        return response;
    }
    [SecuredOperation("asyncLessonsDetails.update,admin")]
    public async Task<UpdatedAsyncLessonsDetailResponse> UpdateAsync(UpdateAsyncLessonsDetailRequest updateAsyncLessonsDetailRequest)
    {
        var result = await _asyncLessonsDetailDal.GetAsync(predicate: a => a.Id == updateAsyncLessonsDetailRequest.Id);
        _mapper.Map(updateAsyncLessonsDetailRequest, result);
        await _asyncLessonsDetailDal.UpdateAsync(result);
        UpdatedAsyncLessonsDetailResponse response = _mapper.Map<UpdatedAsyncLessonsDetailResponse>(result);
        return response;
    }
}