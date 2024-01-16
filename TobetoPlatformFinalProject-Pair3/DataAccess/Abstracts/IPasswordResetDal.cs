using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IPasswordResetDal : IRepository<PasswordReset, Guid>, IAsyncRepository<PasswordReset, Guid>
{

}

