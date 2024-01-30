using System.Configuration;
using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.BusinessRules;
using Business.Dtos.Ability.Requests;
using Business.Dtos.Ability.Responses;
using Business.Dtos.AnnouncementsNewsCategory.Requests;
using Business.Dtos.AnnouncementsNewsCategory.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.GetUserId;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;


namespace Business.Concretes;

public class AnnouncementsNewsCategoryManager : IAnnouncementsNewsCategoryService
{
    private IAnnouncementsNewsCategoryDal _announcementsNewsCategoryDal;
    private IMapper _mapper;

    public AnnouncementsNewsCategoryManager(IAnnouncementsNewsCategoryDal announcementsNewsCategoryDal, IMapper mapper)
    {
        _announcementsNewsCategoryDal = announcementsNewsCategoryDal;
        _mapper = mapper;
    }

    [SecuredOperation("announcementsNewsCategories.add,admin")]
    [ValidationAspect(typeof(AnnouncementsNewsCategoryRequestValidator))]
    public async Task<CreatedAnnouncementsNewsCategoryResponse> AddAsync(CreateAnnouncementsNewsCategoryRequest createAnnouncementsNewsCategoryRequest)
    {
        AnnouncementsNewsCategory announcementsNewsCategory = _mapper.Map<AnnouncementsNewsCategory>(createAnnouncementsNewsCategoryRequest);
        var createannouncementsNewsCategory = await _announcementsNewsCategoryDal.AddAsync(announcementsNewsCategory);
        CreatedAnnouncementsNewsCategoryResponse response = _mapper.Map<CreatedAnnouncementsNewsCategoryResponse>(createannouncementsNewsCategory);
        return response;
    }

    [SecuredOperation("announcementsNewsCategories.delete,admin")]
    public async Task<DeletedAnnouncementsNewsCategoryResponse> DeleteAsync(DeleteAnnouncementsNewsCategoryRequest deleteAnnouncementsNewsCategoryRequest)
    {
        AnnouncementsNewsCategory announcementsNewsCategory = await _announcementsNewsCategoryDal.GetAsync(
            predicate: c => c.Id == deleteAnnouncementsNewsCategoryRequest.Id);
        await _announcementsNewsCategoryDal.DeleteAsync(announcementsNewsCategory);
        DeletedAnnouncementsNewsCategoryResponse response = _mapper.Map<DeletedAnnouncementsNewsCategoryResponse>(announcementsNewsCategory);
        return response;
    }

    public async Task<GetAnnouncementsNewsCategoryResponse> GetById(GetAnnouncementsNewsCategoryRequest getAnnouncementsNewsCategoryRequest)
    {
        AnnouncementsNewsCategory getAnnouncementsNewsCategory = 
            await _announcementsNewsCategoryDal.GetAsync(predicate: c => c.Id == getAnnouncementsNewsCategoryRequest.Id);
        GetAnnouncementsNewsCategoryResponse response = _mapper.Map<GetAnnouncementsNewsCategoryResponse>(getAnnouncementsNewsCategory);
        return response;
    }

    public async Task<IPaginate<GetListedAnnouncementsNewsCategoryResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _announcementsNewsCategoryDal.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedAnnouncementsNewsCategoryResponse> response =
            _mapper.Map<Paginate<GetListedAnnouncementsNewsCategoryResponse>>(getList);
        return response;
    }

    [SecuredOperation("announcementsNewsCategories.update,admin")]
    public async Task<UpdatedAnnouncementsNewsCategoryResponse> UpdateAsync(UpdateAnnouncementsNewsCategoryRequest updateAnnouncementsNewsCategoryRequest)
    {
        var result = await _announcementsNewsCategoryDal.GetAsync(predicate: a => a.Id == updateAnnouncementsNewsCategoryRequest.Id);
        _mapper.Map(updateAnnouncementsNewsCategoryRequest, result);
        await _announcementsNewsCategoryDal.UpdateAsync(result);
        UpdatedAnnouncementsNewsCategoryResponse response = _mapper.Map<UpdatedAnnouncementsNewsCategoryResponse>(result);
        return response;
    }
}