using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Business.Dtos.LiveContent.Requests;
using Business.Dtos.LiveContent.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.GetUserId;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class LiveContentManager : ILiveContentService
{
    private ILiveContentDal _liveContentDal;
    private IMapper _mapper;

    public LiveContentManager(ILiveContentDal liveContentDal, IMapper mapper)
    {
        _liveContentDal = liveContentDal;
        _mapper = mapper;
    }
    [SecuredOperation("liveContents.add,admin")]
    [ValidationAspect(typeof(LiveContentRequestValidator))]
    public async Task<CreatedLiveContentResponse> AddAsync(CreateLiveContentRequest createLiveContentRequest)
    {
        LiveContent liveContent = _mapper.Map<LiveContent>(createLiveContentRequest);
        Expression<Func<LiveContent, object>> includeExpressionForLiveCourse = x => x.LiveCourse;
        var createLiveContent = await _liveContentDal.AddAsync(liveContent, includeExpressionForLiveCourse);
        CreatedLiveContentResponse response = _mapper.Map<CreatedLiveContentResponse>(createLiveContent);
        return response;
    }

    [SecuredOperation("liveContents.delete,admin")]
    public async Task<DeletedLiveContentResponse> DeleteAsync(DeleteLiveContentRequest deleteLiveContentRequest)
    {
        LiveContent liveContent = await _liveContentDal.GetAsync(c => c.Id == deleteLiveContentRequest.Id);
        var deleteLiveContent = await _liveContentDal.DeleteAsync(liveContent);
        DeletedLiveContentResponse response = _mapper.Map<DeletedLiveContentResponse>(deleteLiveContent);
        return response;
    }

    public async Task<GetLiveContentResponse> GetById(GetLiveContentRequest getLiveContentRequest)
    {
        LiveContent getLiveContent = await _liveContentDal.GetAsync(c => c.Id == getLiveContentRequest.Id,
            include: p => p.Include(p => p.LiveCourse));
        GetLiveContentResponse response = _mapper.Map<GetLiveContentResponse>(getLiveContent);
        return response;
    }

    public async Task<IPaginate<GetListedLiveContentResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _liveContentDal.GetListAsync(include: p => p.Include(p => p.LiveCourse),index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedLiveContentResponse> response = _mapper.Map<Paginate<GetListedLiveContentResponse>>(getList);
        return response;
    }

    [SecuredOperation("liveContents.update,admin")]
    public async Task<UpdatedLiveContentResponse> UpdateAsync(UpdateLiveContentRequest updateLiveContentRequest)
    {
        var result = await _liveContentDal.GetAsync(predicate: a => a.Id == updateLiveContentRequest.Id);
        _mapper.Map(updateLiveContentRequest, result);
        await _liveContentDal.UpdateAsync(result);
        UpdatedLiveContentResponse response = _mapper.Map<UpdatedLiveContentResponse>(result);
        return response;
    }
}