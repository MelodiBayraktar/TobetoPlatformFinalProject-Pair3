using Business.Dtos.Project.Requests;
using Business.Dtos.Project.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IProjectService
{
    Task<IPaginate<GetListedProjectResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedProjectResponse> AddAsync(CreateProjectRequest createProjectRequest);
    Task<UpdatedProjectResponse> UpdateAsync(UpdateProjectRequest updateProjectRequest);
    Task<DeletedProjectResponse> DeleteAsync(DeleteProjectRequest deleteProjectRequest);
    Task<GetProjectResponse> GetById(GetProjectRequest getProjectRequest);
}