using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Announcement.Responses;
using Business.Dtos.AsyncContent.Requests;
using Business.Dtos.AsyncContent.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AsyncContentManager : IAsyncContentService
{
    private IAsyncContentDal _asyncContentDal;
    private IMapper _mapper;

    public AsyncContentManager(IAsyncContentDal asyncContentDal, IMapper mapper)
    {
        _asyncContentDal = asyncContentDal;
        _mapper = mapper;
    }

    [SecuredOperation("asyncContents.add,admin")]
    [ValidationAspect(typeof(AsyncContentRequestValidator))]
    [CacheRemoveAspect("IAsyncContentService.Get")]
    public async Task<CreatedAsyncContentResponse> AddAsync(CreateAsyncContentRequest createAsyncContentRequest)
    {
        AsyncContent asyncContent = _mapper.Map<AsyncContent>(createAsyncContentRequest);
        Expression<Func<AsyncContent, object>> includeExpressionForAsyncCourse = x => x.AsyncCourse;
        var createAsyncContent = await _asyncContentDal.AddAsync(asyncContent, includeExpressionForAsyncCourse);
        CreatedAsyncContentResponse response = _mapper.Map<CreatedAsyncContentResponse>(createAsyncContent);
        return response;
    }

    [SecuredOperation("asyncContents.delete,admin")]
    [CacheRemoveAspect("IAsyncContentService.Get")]
    public async Task<DeletedAsyncContentResponse> DeleteAsync(DeleteAsyncContentRequest deleteAsyncContentRequest)
    {
        AsyncContent asyncContent = await _asyncContentDal.GetAsync(c => c.Id == deleteAsyncContentRequest.Id);
        await _asyncContentDal.DeleteAsync(asyncContent);
        DeletedAsyncContentResponse response =  _mapper.Map<DeletedAsyncContentResponse>(asyncContent);
        return response;
    }

    [CacheAspect(duration: 10)]
    public async Task<GetAsyncContentResponse> GetById(GetAsyncContentRequest getAsyncContentRequest)
    {
        AsyncContent getAsyncContent = await _asyncContentDal.GetAsync(c => c.Id == getAsyncContentRequest.Id);
        GetAsyncContentResponse response = _mapper.Map<GetAsyncContentResponse>(getAsyncContent);
        return response;
    }

    [CacheAspect(duration: 10)]
    public async Task<IPaginate<GetListedAsyncContentResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _asyncContentDal.GetListAsync(include: p => p.Include(p => p.AsyncCourse),index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedAsyncContentResponse> response = _mapper.Map<Paginate<GetListedAsyncContentResponse>>(getList);
        return response;
    }

    [SecuredOperation("asyncContents.update,admin")]
    [CacheRemoveAspect("IAsyncContentService.Get")]
    public async Task<UpdatedAsyncContentResponse> UpdateAsync(UpdateAsyncContentRequest updateAsyncContentRequest)
    {
        var result = await _asyncContentDal.GetAsync(predicate: a => a.Id == updateAsyncContentRequest.Id);
        _mapper.Map(updateAsyncContentRequest, result);
        await _asyncContentDal.UpdateAsync(result);
        UpdatedAsyncContentResponse response = _mapper.Map<UpdatedAsyncContentResponse>(result);
        return response;
    }
}