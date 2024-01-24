using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.LiveCourse.Responses;
using Business.Dtos.Session.Requests;
using Business.Dtos.Session.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
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
    public async Task<CreatedSessionResponse> AddAsync(CreateSessionRequest createSessionRequest)
    {
        // var session = _mapper.Map<Session>(createSessionRequest);
        // var createSession = await _sessionDal.AddAsync(session);
        // return _mapper.Map<CreatedSessionResponse>(createSession);
        var session = _mapper.Map<Session>(createSessionRequest);
        Expression<Func<Session, object>> includeExpressionForLiveContent = x => x.LiveContent;
        Expression<Func<Session, object>> includeExpressionForInstructor = y => y.Instructor;
        
        var createSession = await _sessionDal.AddAsync(session, includeExpressionForLiveContent,includeExpressionForInstructor);
        return _mapper.Map<CreatedSessionResponse>(createSession);
    }
    [SecuredOperation("sessions.delete,admin")]
    public async Task<DeletedSessionResponse> DeleteAsync(DeleteSessionRequest deleteSessionRequest)
    {
        var session = await _sessionDal.GetAsync(c => c.Id == deleteSessionRequest.Id);
        var deleteSession = await _sessionDal.DeleteAsync(session);
        return _mapper.Map<DeletedSessionResponse>(deleteSession);
    }

    public async Task<GetSessionResponse> GetById(GetSessionRequest getSessionRequest)
    {
        var getSession = await _sessionDal.GetAsync(c => c.Id == getSessionRequest.Id);
        return _mapper.Map<GetSessionResponse>(getSession);
    }

    public async Task<IPaginate<GetListedSessionResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _sessionDal.GetListAsync(include: p => p.Include(p => p.LiveContent).Include(p => p.Instructor),index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedSessionResponse>>(getList);
    }
    [SecuredOperation("sessions.update,admin")]
    public async Task<UpdatedSessionResponse> UpdateAsync(UpdateSessionRequest updateSessionRequest)
    {
        var session = _mapper.Map<Session>(updateSessionRequest);
        var updatedSession = await _sessionDal.UpdateAsync(session);
        return _mapper.Map<UpdatedSessionResponse>(updatedSession);
    }
}