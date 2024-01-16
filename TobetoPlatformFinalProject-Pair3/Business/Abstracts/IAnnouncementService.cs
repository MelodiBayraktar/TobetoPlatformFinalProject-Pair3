using Business.Dtos.Announcement.Requests;
using Business.Dtos.Announcement.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAnnouncementService
{
    Task<IPaginate<GetListedAnnouncementResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedAnnouncementResponse> AddAsync(CreateAnnouncementRequest createAnnouncementRequest);
    Task<UpdatedAnnouncementResponse> UpdateAsync(UpdateAnnouncementRequest updateAnnouncementRequest);
    Task<DeletedAnnouncementResponse> DeleteAsync(DeleteAnnouncementRequest deleteAnnouncementRequest);
    Task<GetAnnouncementResponse> GetById(GetAnnouncementRequest getAnnouncementRequest);
}