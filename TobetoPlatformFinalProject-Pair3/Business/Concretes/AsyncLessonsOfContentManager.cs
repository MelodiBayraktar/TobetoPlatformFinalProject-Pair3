using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Announcement.Responses;
using Business.Dtos.AsyncLessonsOfContent.Requests;
using Business.Dtos.AsyncLessonsOfContent.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AsyncLessonsOfContentManager : IAsyncLessonsOfContentService
{
    private IAsyncLessonsOfContentDal _asyncLessonsOfContentDal;
    private IMapper _mapper;

    public AsyncLessonsOfContentManager(IAsyncLessonsOfContentDal asyncLessonsOfContentDal, IMapper mapper)
    {
        _asyncLessonsOfContentDal = asyncLessonsOfContentDal;
        _mapper = mapper;
    }
    [SecuredOperation("asyncLessonsOfContents.add,admin")]
    [ValidationAspect(typeof(AsyncLessonsOfContentRequestValidator))]
    public async Task<CreatedAsyncLessonsOfContentResponse> AddAsync(CreateAsyncLessonsOfContentRequest createAsyncLessonsOfContentRequest)
    {
        AsyncLessonsOfContent asyncLessonsOfContent = _mapper.Map<AsyncLessonsOfContent>(createAsyncLessonsOfContentRequest);
        Expression<Func<AsyncLessonsOfContent, object>> includeExpressionForAsyncContent= x => x.AsyncContent;
        var createAsyncLessonsOfContent = await _asyncLessonsOfContentDal.AddAsync(asyncLessonsOfContent, includeExpressionForAsyncContent);
        CreatedAsyncLessonsOfContentResponse response =  _mapper.Map<CreatedAsyncLessonsOfContentResponse>(createAsyncLessonsOfContent);  
        return response;
    }
    [SecuredOperation("asyncLessonsOfContents.delete,admin")]
    public async Task<DeletedAsyncLessonsOfContentResponse> DeleteAsync(DeleteAsyncLessonsOfContentRequest deleteAsyncLessonsOfContentRequest)
    {
        AsyncLessonsOfContent asyncLessonsOfContent = await _asyncLessonsOfContentDal.GetAsync(c => c.Id == deleteAsyncLessonsOfContentRequest.Id);
        await _asyncLessonsOfContentDal.DeleteAsync(asyncLessonsOfContent);
        DeletedAsyncLessonsOfContentResponse response =  _mapper.Map<DeletedAsyncLessonsOfContentResponse>(asyncLessonsOfContent);
        return response;
    }

    public async Task<GetAsyncLessonsOfContentResponse> GetById(GetAsyncLessonsOfContentRequest getAsyncLessonsOfContentRequest)
    {
        AsyncLessonsOfContent getAsyncLessonsOfContent = await _asyncLessonsOfContentDal.GetAsync(c => c.AsyncCourseId == getAsyncLessonsOfContentRequest.AsyncCourseId,
            include: p => p.Include(p => p.AsyncContent));
        GetAsyncLessonsOfContentResponse response =  _mapper.Map<GetAsyncLessonsOfContentResponse>(getAsyncLessonsOfContent);
        return response;
    }

    public async Task<IPaginate<GetListedAsyncLessonsOfContentResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _asyncLessonsOfContentDal.GetListAsync(include: p => p.Include(p => p.AsyncContent), index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedAsyncLessonsOfContentResponse> response = _mapper.Map<Paginate<GetListedAsyncLessonsOfContentResponse>>(getList);
        return response;
    }
    [SecuredOperation("asyncLessonsOfContents.update,admin")]
    public async Task<UpdatedAsyncLessonsOfContentResponse> UpdateAsync(UpdateAsyncLessonsOfContentRequest updateAsyncLessonsOfContentRequest)
    {
        var result = await _asyncLessonsOfContentDal.GetAsync(predicate: a => a.Id == updateAsyncLessonsOfContentRequest.Id);
        _mapper.Map(updateAsyncLessonsOfContentRequest, result);
        await _asyncLessonsOfContentDal.UpdateAsync(result);
        UpdatedAsyncLessonsOfContentResponse response = _mapper.Map<UpdatedAsyncLessonsOfContentResponse>(result);
        return response;
    }
}