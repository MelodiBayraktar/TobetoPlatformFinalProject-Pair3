using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IProjectDal : IRepository<Project, Guid>, IAsyncRepository<Project, Guid>
{
}

