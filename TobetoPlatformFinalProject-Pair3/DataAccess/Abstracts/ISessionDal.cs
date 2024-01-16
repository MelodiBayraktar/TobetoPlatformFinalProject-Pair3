using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface ISessionDal : IRepository<Session, Guid>, IAsyncRepository<Session, Guid>
{

}

