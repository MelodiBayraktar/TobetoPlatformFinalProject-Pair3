using Business.Dtos.AnnouncementsNewsCategory.Requests;
using Business.Dtos.AnnouncementsNewsCategory.Responses;

using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;

namespace Business.Abstracts;

public interface IAnnouncementsNewsCategoryService
{
    Task<IPaginate<GetListedAnnouncementsNewsCategoryResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedAnnouncementsNewsCategoryResponse> AddAsync(CreateAnnouncementsNewsCategoryRequest createAnnouncementsNewsCategoryRequest);
    Task<UpdatedAnnouncementsNewsCategoryResponse> UpdateAsync(UpdateAnnouncementsNewsCategoryRequest updateAnnouncementsNewsCategoryRequest);
    Task<DeletedAnnouncementsNewsCategoryResponse> DeleteAsync(DeleteAnnouncementsNewsCategoryRequest deleteAnnouncementsNewsCategoryRequest);
    Task<GetAnnouncementsNewsCategoryResponse> GetById(GetAnnouncementsNewsCategoryRequest getAnnouncementsNewsCategoryRequest);
}