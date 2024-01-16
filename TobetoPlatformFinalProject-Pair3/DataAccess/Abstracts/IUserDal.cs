using Core.DataAccess.Repositories;
using Core.Entities.Abstracts;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IUserDal : IRepository<User, Guid>, IAsyncRepository<User, Guid>
{
    List<IOperationClaim> GetClaims(IUser user);
}

