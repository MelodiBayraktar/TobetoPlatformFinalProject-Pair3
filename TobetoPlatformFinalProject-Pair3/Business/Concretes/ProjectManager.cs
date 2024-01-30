using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.BusinessRules;
using Business.Dtos.Ability.Requests;
using Business.Dtos.Ability.Responses;
using Business.Dtos.Project.Requests;
using Business.Dtos.Project.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.GetUserId;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;

namespace Business.Concretes;

public class ProjectManager : IProjectService
{
    private IProjectDal _projectDal;
    private IMapper _mapper;

    public ProjectManager(IProjectDal projectDal, IMapper mapper)
    {
        _projectDal = projectDal;
        _mapper = mapper;
    }

    //[SecuredOperation("projects.add,admin")]
    [ValidationAspect(typeof(ProjectRequestValidator))]
    public async Task<CreatedProjectResponse> AddAsync(CreateProjectRequest createProjectRequest)
    {
        Project project = _mapper.Map<Project>(createProjectRequest);
        var createProject = await _projectDal.AddAsync(project);
        CreatedProjectResponse response = _mapper.Map<CreatedProjectResponse>(createProject);
        return response;
    }

    //[SecuredOperation("projects.delete,admin")]
    public async Task<DeletedProjectResponse> DeleteAsync(DeleteProjectRequest deleteProjectRequest)
    {
        Project project = await _projectDal.GetAsync(predicate: c => c.Id == deleteProjectRequest.Id);
        await _projectDal.DeleteAsync(project);
        DeletedProjectResponse response = _mapper.Map<DeletedProjectResponse>(project);
        return response;
    }

    public async Task<GetProjectResponse> GetById(GetProjectRequest getProjectRequest)
    {
        Project getProject = await _projectDal.GetAsync(predicate: c => c.Id == getProjectRequest.Id);
        GetProjectResponse response = _mapper.Map<GetProjectResponse>(getProject);
        return response;
    }

    public async Task<IPaginate<GetListedProjectResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _projectDal.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedProjectResponse> response = _mapper.Map<Paginate<GetListedProjectResponse>>(getList);
        return response;
    }

    //[SecuredOperation("projects.update,admin")]
    public async Task<UpdatedProjectResponse> UpdateAsync(UpdateProjectRequest updateProjectRequest)
    {
        var result = await _projectDal.GetAsync(predicate: a => a.Id == updateProjectRequest.Id);
        _mapper.Map(updateProjectRequest, result);
        await _projectDal.UpdateAsync(result);
        UpdatedProjectResponse response = _mapper.Map<UpdatedProjectResponse>(result);
        return response;
    }
}