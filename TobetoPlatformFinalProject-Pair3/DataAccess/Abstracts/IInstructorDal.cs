using Core.DataAccess.Repositories;
using Entities;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IInstructorDal : IRepository<Instructor, Guid>, IAsyncRepository<Instructor, Guid>
{

}

