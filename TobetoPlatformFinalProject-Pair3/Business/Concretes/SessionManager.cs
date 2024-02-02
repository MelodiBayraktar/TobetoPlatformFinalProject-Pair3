using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Business.Dtos.LiveCourse.Responses;
using Business.Dtos.Session.Requests;
using Business.Dtos.Session.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
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

public class SessionManager : ISessionService
{
    private ISessionDal _sessionDal;
    private IMapper _mapper;

    public SessionManager(ISessionDal sessionDal, IMapper mapper)
    {
        _sessionDal = sessionDal;
        _mapper = mapper;
    }

    [SecuredOperation("sessions.add,admin")]
    [ValidationAspect(typeof(SessionRequestValidator))]
    [CacheRemoveAspect("ISessionService.Get")]
    public async Task<CreatedSessionResponse> AddAsync(CreateSessionRequest createSessionRequest)
    {
        Session session = _mapper.Map<Session>(createSessionRequest);
        Expression<Func<Session, object>> includeExpressionForLiveContent = x => x.LiveContent;
        Expression<Func<Session, object>> includeExpressionForInstructor = y => y.Instructor;
        var createSession = await _sessionDal.AddAsync(session, includeExpressionForLiveContent,includeExpressionForInstructor);
        CreatedSessionResponse response = _mapper.Map<CreatedSessionResponse>(createSession);
        return response;
    }

    [SecuredOperation("sessions.delete,admin")]
    [CacheRemoveAspect("ISessionService.Get")]
    public async Task<DeletedSessionResponse> DeleteAsync(DeleteSessionRequest deleteSessionRequest)
    {
        Session session = await _sessionDal.GetAsync(c => c.Id == deleteSessionRequest.Id);
        var deleteSession = await _sessionDal.DeleteAsync(session);
        DeletedSessionResponse response = _mapper.Map<DeletedSessionResponse>(deleteSession);
        return response;
    }

    [CacheAspect(duration: 10)]
    public async Task<GetSessionResponse> GetById(GetSessionRequest getSessionRequest)
    {
        Session getSession = await _sessionDal.GetAsync(c => c.Id == getSessionRequest.Id,
            include: p => p.Include(p => p.LiveContent).Include(p => p.Instructor));
        GetSessionResponse response = _mapper.Map<GetSessionResponse>(getSession);
        return response;
    }

    [CacheAspect(duration: 10)]
    public async Task<IPaginate<GetListedSessionResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _sessionDal.GetListAsync(include: p => p.Include(p => p.LiveContent).Include(p => p.Instructor),index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedSessionResponse> response = _mapper.Map<Paginate<GetListedSessionResponse>>(getList);
        return response;
    }

    [SecuredOperation("sessions.update,admin")]
    [CacheRemoveAspect("ISessionService.Get")]
    public async Task<UpdatedSessionResponse> UpdateAsync(UpdateSessionRequest updateSessionRequest)
    {
        var result = await _sessionDal.GetAsync(predicate: a => a.Id == updateSessionRequest.Id);
        _mapper.Map(updateSessionRequest, result);
        await _sessionDal.UpdateAsync(result);
        UpdatedSessionResponse response = _mapper.Map<UpdatedSessionResponse>(result);
        return response;
    }
}