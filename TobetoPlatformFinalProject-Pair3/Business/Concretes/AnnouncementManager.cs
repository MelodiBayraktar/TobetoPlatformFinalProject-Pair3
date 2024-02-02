using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.BusinessRules;
using Business.Dtos.Ability.Requests;
using Business.Dtos.Ability.Responses;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.Announcement.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.GetUserId;
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
    
    //[SecuredOperation("announcements.add,admin")]
    [ValidationAspect(typeof(AnnouncementRequestValidator))]
    public async Task<CreatedAnnouncementResponse> AddAsync(CreateAnnouncementRequest createAnnouncementRequest)
    {
        Announcement announcement = _mapper.Map<Announcement>(createAnnouncementRequest);
        Expression<Func<Announcement, object>> includeExpressionForProject = x => x.Project;
        Expression<Func<Announcement, object>> includeExpressionForAnnouncementsNewsCategory = y => y.AnnouncementsNewsCategory;
        var createAnnouncement = await _announcementDal.AddAsync(announcement, includeExpressionForProject,includeExpressionForAnnouncementsNewsCategory);
        CreatedAnnouncementResponse response = _mapper.Map<CreatedAnnouncementResponse>(createAnnouncement);
        return response;
    }

    //[SecuredOperation("announcements.delete,admin")]
    public async Task<DeletedAnnouncementResponse> DeleteAsync(DeleteAnnouncementRequest deleteAnnouncementRequest)
    {
        Announcement announcement = await _announcementDal.GetAsync(predicate: c => c.Id == deleteAnnouncementRequest.Id);
        await _announcementDal.DeleteAsync(announcement);
        DeletedAnnouncementResponse response = _mapper.Map<DeletedAnnouncementResponse>(announcement);
        return response;
    }

    public async Task<GetAnnouncementResponse> GetById(GetAnnouncementRequest getAnnouncementRequest)
    {
        Announcement getAnnouncement = await _announcementDal.GetAsync(predicate: c => c.Id == getAnnouncementRequest.Id,
            include: p => p.Include(p => p.Project).Include(p => p.AnnouncementsNewsCategory));
        await _announcementBusinessRules.AnnouncementMustExistWhenSelected(getAnnouncement);
        GetAnnouncementResponse response = _mapper.Map<GetAnnouncementResponse>(getAnnouncement);
        return response;
    }

    public async Task<IPaginate<GetListedAnnouncementResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _announcementDal.GetListAsync(include: p => p.Include(p => p.Project).Include(p => p.AnnouncementsNewsCategory), index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedAnnouncementResponse> response = _mapper.Map<Paginate<GetListedAnnouncementResponse>>(getList);
        return response;
    }

    //[SecuredOperation("announcements.update,admin")]
    public async Task<UpdatedAnnouncementResponse> UpdateAsync(UpdateAnnouncementRequest updateAnnouncementRequest)
    {
        var result = await _announcementDal.GetAsync(predicate: a => a.Id == updateAnnouncementRequest.Id);
        _mapper.Map(updateAnnouncementRequest, result);
        await _announcementDal.UpdateAsync(result);
        UpdatedAnnouncementResponse response = _mapper.Map<UpdatedAnnouncementResponse>(result);
        return response;
    }
}