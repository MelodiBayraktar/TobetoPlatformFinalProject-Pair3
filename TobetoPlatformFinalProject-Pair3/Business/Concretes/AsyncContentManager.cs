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
        // var asyncContent = _mapper.Map<AsyncContent>(createAsyncContentRequest);
        // var createAsyncContent = await _asyncContentDal.AddAsync(asyncContent);
        // return _mapper.Map<CreatedAsyncContentResponse>(createAsyncContent);
        var asyncContent = _mapper.Map<AsyncContent>(createAsyncContentRequest);
        Expression<Func<AsyncContent, object>> includeExpressionForAsyncCourse = x => x.AsyncCourse;
        
        var createAsyncContent = await _asyncContentDal.AddAsync(asyncContent, includeExpressionForAsyncCourse);
        return _mapper.Map<CreatedAsyncContentResponse>(createAsyncContent);    
    }

    [SecuredOperation("asyncContents.delete,admin")]
    [CacheRemoveAspect("IAsyncContentService.Get")]
    public async Task<DeletedAsyncContentResponse> DeleteAsync(DeleteAsyncContentRequest deleteAsyncContentRequest)
    {
        var asyncContent = await _asyncContentDal.GetAsync(c => c.Id == deleteAsyncContentRequest.Id);
        var deleteAsyncContent = await _asyncContentDal.DeleteAsync(asyncContent);
        return _mapper.Map<DeletedAsyncContentResponse>(deleteAsyncContent);
    }

    [CacheAspect(duration: 10)]
    public async Task<GetAsyncContentResponse> GetById(GetAsyncContentRequest getAsyncContentRequest)
    {
        var getAsyncContent = await _asyncContentDal.GetAsync(c => c.Id == getAsyncContentRequest.Id);
        return _mapper.Map<GetAsyncContentResponse>(getAsyncContent);
    }

    [CacheAspect(duration: 10)]
    public async Task<IPaginate<GetListedAsyncContentResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _asyncContentDal.GetListAsync(include: p => p.Include(p => p.AsyncCourse),index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedAsyncContentResponse>>(getList);
    }

    [SecuredOperation("asyncContents.update,admin")]
    [CacheRemoveAspect("IAsyncContentService.Get")]
    public async Task<UpdatedAsyncContentResponse> UpdateAsync(UpdateAsyncContentRequest updateAsyncContentRequest)
    {
        var asyncContent = _mapper.Map<AsyncContent>(updateAsyncContentRequest);
        var updatedAsyncContent = await _asyncContentDal.UpdateAsync(asyncContent);
        return _mapper.Map<UpdatedAsyncContentResponse>(updatedAsyncContent);
    }
}