using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.Announcement.Responses;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AnnouncementManager : IAnnouncementService
{
    private IAnnouncementDal _announcementDal;
    private IMapper _mapper;

    public AnnouncementManager(IAnnouncementDal announcementDal, IMapper mapper)
    {
        _announcementDal = announcementDal;
        _mapper = mapper;
    }

    public async Task<CreatedAnnouncementResponse> AddAsync(CreateAnnouncementRequest createAnnouncementRequest)
    {
        var announcement = _mapper.Map<Announcement>(createAnnouncementRequest);
        var createAnnouncement = await _announcementDal.AddAsync(announcement);
        return _mapper.Map<CreatedAnnouncementResponse>(createAnnouncement);
    }

    public async Task<DeletedAnnouncementResponse> DeleteAsync(DeleteAnnouncementRequest deleteAnnouncementRequest)
    {
        var announcement = await _announcementDal.GetAsync(c => c.Id == deleteAnnouncementRequest.Id);
        var deleteAnnouncement = await _announcementDal.DeleteAsync(announcement);
        return _mapper.Map<DeletedAnnouncementResponse>(deleteAnnouncement);
    }

    public async Task<GetAnnouncementResponse> GetById(GetAnnouncementRequest getAnnouncementRequest)
    {
        var getAnnouncement = await _announcementDal.GetAsync(c => c.Id == getAnnouncementRequest.Id);
        return _mapper.Map<GetAnnouncementResponse>(getAnnouncement);
    }

    public async Task<IPaginate<GetListedAnnouncementResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _announcementDal.GetListAsync(include: p => p.Include(p => p.Project).Include(p => p.AnnouncementsNewsCategory), index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedAnnouncementResponse>>(getList);
    }

    public async Task<UpdatedAnnouncementResponse> UpdateAsync(UpdateAnnouncementRequest updateAnnouncementRequest)
    {
        var announcement = _mapper.Map<Announcement>(updateAnnouncementRequest);
        var updatedAnnouncement = await _announcementDal.UpdateAsync(announcement);
        return _mapper.Map<UpdatedAnnouncementResponse>(updatedAnnouncement);
    }
}