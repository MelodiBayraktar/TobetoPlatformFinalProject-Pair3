using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Application.Requests;
using Business.Dtos.Application.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ApplicationManager : IApplicationService
{
    private IApplicationDal _applicationDal;
    private IMapper _mapper;

    public ApplicationManager(IApplicationDal applicationDal, IMapper mapper)
    {
        _applicationDal = applicationDal;
        _mapper = mapper;
    }

    [ValidationAspect(typeof(ApplicationRequestValidator))]
    public async Task<CreatedApplicationResponse> AddAsync(CreateApplicationRequest createApplicationRequest)
    {
        // var application = _mapper.Map<Application>(createApplicationRequest);
        // var createApplication = await _applicationDal.AddAsync(application);
        // return _mapper.Map<CreatedApplicationResponse>(createApplication);
        var application = _mapper.Map<Application>(createApplicationRequest);
        Expression<Func<Application, object>> includeExpressionForProject = x => x.Project;
        
        var createApplication = await _applicationDal.AddAsync(application, includeExpressionForProject);
        return _mapper.Map<CreatedApplicationResponse>(createApplication);    
    }
    [SecuredOperation("applications.delete,admin")]
    public async Task<DeletedApplicationResponse> DeleteAsync(DeleteApplicationRequest deleteApplicationRequest)
    {
        var application = await _applicationDal.GetAsync(c => c.Id == deleteApplicationRequest.Id);
        var deleteApplication = await _applicationDal.DeleteAsync(application);
        return _mapper.Map<DeletedApplicationResponse>(deleteApplication);
    }

    public async Task<GetApplicationResponse> GetById(GetApplicationRequest getApplicationRequest)
    {
        var getApplication = await _applicationDal.GetAsync(c => c.Id == getApplicationRequest.Id,
            include: p => p.Include(p => p.Project));
        return _mapper.Map<GetApplicationResponse>(getApplication);
    }

    public async Task<IPaginate<GetListedApplicationResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _applicationDal.GetListAsync(include: p => p.Include(p => p.Project), index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedApplicationResponse>>(getList);
    }

    public async Task<UpdatedApplicationResponse> UpdateAsync(UpdateApplicationRequest updateApplicationRequest)
    {
        var application = _mapper.Map<Application>(updateApplicationRequest);
        var updatedApplication = await _applicationDal.UpdateAsync(application);
        return _mapper.Map<UpdatedApplicationResponse>(updatedApplication);
    }
}