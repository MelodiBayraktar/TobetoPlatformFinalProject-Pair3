using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.Project.Requests;
using Business.Dtos.Project.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<Project, CreateProjectRequest>().ReverseMap();
            CreateMap<Project, CreatedProjectResponse>().ReverseMap();

            CreateMap<Project, UpdateProjectRequest>().ReverseMap();
            CreateMap<Project, UpdatedProjectResponse>().ReverseMap();

            CreateMap<Project, DeleteProjectRequest>().ReverseMap();
            CreateMap<Project, DeletedProjectResponse>().ReverseMap();

            CreateMap<Project, GetProjectRequest>().ReverseMap();
            CreateMap<Project, GetProjectResponse>().ReverseMap();


            CreateMap<Project, GetListedProjectResponse>().ReverseMap();
            CreateMap<Paginate<Project>, Paginate<GetListedProjectResponse>>().ReverseMap();
        }
    }
}
