using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Project.Requests;
using Business.Dtos.Project.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
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

    public async Task<CreatedProjectResponse> AddAsync(CreateProjectRequest createProjectRequest)
    {
        var project = _mapper.Map<Project>(createProjectRequest);
        var createProject = await _projectDal.AddAsync(project);
        return _mapper.Map<CreatedProjectResponse>(createProject);
    }

    public async Task<DeletedProjectResponse> DeleteAsync(DeleteProjectRequest deleteProjectRequest)
    {
        var project = await _projectDal.GetAsync(c => c.Id == deleteProjectRequest.Id);
        var deleteProject = await _projectDal.DeleteAsync(project);
        return _mapper.Map<DeletedProjectResponse>(deleteProject);
    }

    public async Task<GetProjectResponse> GetById(GetProjectRequest getProjectRequest)
    {
        var getProject = await _projectDal.GetAsync(c => c.Id == getProjectRequest.Id);
        return _mapper.Map<GetProjectResponse>(getProject);
    }

    public async Task<IPaginate<GetListedProjectResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _projectDal.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedProjectResponse>>(getList);
    }

    public async Task<UpdatedProjectResponse> UpdateAsync(UpdateProjectRequest updateProjectRequest)
    {
        var project = _mapper.Map<Project>(updateProjectRequest);
        var updatedProject = await _projectDal.UpdateAsync(project);
        return _mapper.Map<UpdatedProjectResponse>(updatedProject);
    }
}