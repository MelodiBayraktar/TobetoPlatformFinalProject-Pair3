using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.BusinessRules;
using Business.Dtos.Ability.Responses;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.Announcement.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
    private AnnouncementBusinessRules _announcementBusinessRules;

    public AnnouncementManager(IAnnouncementDal announcementDal, IMapper mapper, AnnouncementBusinessRules announcementBusinessRules)
    {
        _announcementDal = announcementDal;
        _mapper = mapper;
        _announcementBusinessRules = announcementBusinessRules;
    }
    
    [SecuredOperation("announcements.add,admin")]
    [ValidationAspect(typeof(AnnouncementRequestValidator))]
    public async Task<CreatedAnnouncementResponse> AddAsync(CreateAnnouncementRequest createAnnouncementRequest)
    {
        // var announcement = _mapper.Map<Announcement>(createAnnouncementRequest);
        // var createAnnouncement = await _announcementDal.AddAsync(announcement);
        // return _mapper.Map<CreatedAnnouncementResponse>(createAnnouncement);
        var announcement = _mapper.Map<Announcement>(createAnnouncementRequest);
        Expression<Func<Announcement, object>> includeExpressionForProject = x => x.Project;
        Expression<Func<Announcement, object>> includeExpressionForAnnouncementsNewsCategory = y => y.AnnouncementsNewsCategory;
        
        var createAnnouncement = await _announcementDal.AddAsync(announcement, includeExpressionForProject,includeExpressionForAnnouncementsNewsCategory);
        return _mapper.Map<CreatedAnnouncementResponse>(createAnnouncement);    
    }
    [SecuredOperation("announcements.delete,admin")]
    public async Task<DeletedAnnouncementResponse> DeleteAsync(DeleteAnnouncementRequest deleteAnnouncementRequest)
    {
        var announcement = await _announcementDal.GetAsync(c => c.Id == deleteAnnouncementRequest.Id);
        var deleteAnnouncement = await _announcementDal.DeleteAsync(announcement);
        return _mapper.Map<DeletedAnnouncementResponse>(deleteAnnouncement);
    }

    public async Task<GetAnnouncementResponse> GetById(GetAnnouncementRequest getAnnouncementRequest)
    {
        var getAnnouncement = await _announcementDal.GetAsync(c => c.Id == getAnnouncementRequest.Id);
        await _announcementBusinessRules.AnnouncementMustExistWhenSelected(getAnnouncement);
        return _mapper.Map<GetAnnouncementResponse>(getAnnouncement);
    }

    public async Task<IPaginate<GetListedAnnouncementResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _announcementDal.GetListAsync(include: p => p.Include(p => p.Project).Include(p => p.AnnouncementsNewsCategory), index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedAnnouncementResponse>>(getList);
    }
    [SecuredOperation("announcements.update,admin")]
    public async Task<UpdatedAnnouncementResponse> UpdateAsync(UpdateAnnouncementRequest updateAnnouncementRequest)
    {
        var announcement = _mapper.Map<Announcement>(updateAnnouncementRequest);
        var updatedAnnouncement = await _announcementDal.UpdateAsync(announcement);
        return _mapper.Map<UpdatedAnnouncementResponse>(updatedAnnouncement);
    }
}