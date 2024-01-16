using Core.DataAccess.Repositories;
using Entities;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IEducationDal : IRepository<Education, Guid>, IAsyncRepository<Education, Guid>
{

}

