using AutoMapper;
using Business.Abstracts;
using Business.Dtos.AnnouncementsNewsCategory.Requests;
using Business.Dtos.AnnouncementsNewsCategory.Responses;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
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

    public async Task<CreatedAnnouncementsNewsCategoryResponse> AddAsync(CreateAnnouncementsNewsCategoryRequest createAnnouncementsNewsCategoryRequest)
    {
        var announcementsNewsCategory = _mapper.Map<AnnouncementsNewsCategory>(createAnnouncementsNewsCategoryRequest);
        var createAnnouncementsNewsCategory = await _announcementsNewsCategoryDal.AddAsync(announcementsNewsCategory);
        return _mapper.Map<CreatedAnnouncementsNewsCategoryResponse>(createAnnouncementsNewsCategory);
    }

    public async Task<DeletedAnnouncementsNewsCategoryResponse> DeleteAsync(DeleteAnnouncementsNewsCategoryRequest deleteAnnouncementsNewsCategoryRequest)
    {
        var announcementsNewsCategory = await _announcementsNewsCategoryDal.GetAsync(c => c.Id == deleteAnnouncementsNewsCategoryRequest.Id);
        var deleteAnnouncementsNewsCategory = await _announcementsNewsCategoryDal.DeleteAsync(announcementsNewsCategory);
        return _mapper.Map<DeletedAnnouncementsNewsCategoryResponse>(deleteAnnouncementsNewsCategory);
    }

    public async Task<GetAnnouncementsNewsCategoryResponse> GetById(GetAnnouncementsNewsCategoryRequest getAnnouncementsNewsCategoryRequest)
    {
        var getAnnouncementsNewsCategory = await _announcementsNewsCategoryDal.GetAsync(c => c.Id == getAnnouncementsNewsCategoryRequest.Id);
        return _mapper.Map<GetAnnouncementsNewsCategoryResponse>(getAnnouncementsNewsCategory);
    }

    public async Task<IPaginate<GetListedAnnouncementsNewsCategoryResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _announcementsNewsCategoryDal.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedAnnouncementsNewsCategoryResponse>>(getList);
    }

    public async Task<UpdatedAnnouncementsNewsCategoryResponse> UpdateAsync(UpdateAnnouncementsNewsCategoryRequest updateAnnouncementsNewsCategoryRequest)
    {
        var announcementsNewsCategory = _mapper.Map<AnnouncementsNewsCategory>(updateAnnouncementsNewsCategoryRequest);
        var updatedAnnouncementsNewsCategory = await _announcementsNewsCategoryDal.UpdateAsync(announcementsNewsCategory);
        return _mapper.Map<UpdatedAnnouncementsNewsCategoryResponse>(updatedAnnouncementsNewsCategory);
    }
}