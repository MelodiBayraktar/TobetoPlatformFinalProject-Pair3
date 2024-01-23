using Business.Abstracts;
using Business.Dtos.Project.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateProjectRequest createProjectRequest)
        {
            var result = await _projectService.AddAsync(createProjectRequest); return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateProjectRequest updateProjectRequest)
        {
            var result = await _projectService.UpdateAsync(updateProjectRequest); return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteProjectRequest deleteProjectRequest)
        {
            var result = await _projectService.DeleteAsync(deleteProjectRequest); return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _projectService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetProjectRequest getProjectRequest)
        {
            var result = await _projectService.GetById(getProjectRequest);
            return Ok(result);
        }
    }
}
