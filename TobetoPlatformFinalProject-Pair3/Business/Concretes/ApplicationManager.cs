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
        Application application = _mapper.Map<Application>(createApplicationRequest);
        Expression<Func<Application, object>> includeExpressionForProject = x => x.Project;
        var createApplication = await _applicationDal.AddAsync(application, includeExpressionForProject);
        CreatedApplicationResponse response = _mapper.Map<CreatedApplicationResponse>(createApplication);
        return response;    
    }
    //[SecuredOperation("applications.delete,admin")]
    public async Task<DeletedApplicationResponse> DeleteAsync(DeleteApplicationRequest deleteApplicationRequest)
    {
        Application application = await _applicationDal.GetAsync(c => c.Id == deleteApplicationRequest.Id);
        await _applicationDal.DeleteAsync(application);
        DeletedApplicationResponse response = _mapper.Map<DeletedApplicationResponse>(application);
        return response;
    }

    public async Task<GetApplicationResponse> GetById(GetApplicationRequest getApplicationRequest)
    {
        Application getApplication = await _applicationDal.GetAsync(c => c.Id == getApplicationRequest.Id,
            include: p => p.Include(p => p.Project));
        GetApplicationResponse response =_mapper.Map<GetApplicationResponse>(getApplication);
        return response;
    }

    public async Task<IPaginate<GetListedApplicationResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _applicationDal.GetListAsync(include: p => p.Include(p => p.Project), index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedApplicationResponse> response = _mapper.Map<Paginate<GetListedApplicationResponse>>(getList);
        return response;
    }

    public async Task<UpdatedApplicationResponse> UpdateAsync(UpdateApplicationRequest updateApplicationRequest)
    {
        var result = await _applicationDal.GetAsync(predicate: a => a.Id == updateApplicationRequest.Id);
        _mapper.Map(updateApplicationRequest, result);
        await _applicationDal.UpdateAsync(result);
        UpdatedApplicationResponse response = _mapper.Map<UpdatedApplicationResponse>(result);
        return response;
        
    }
}