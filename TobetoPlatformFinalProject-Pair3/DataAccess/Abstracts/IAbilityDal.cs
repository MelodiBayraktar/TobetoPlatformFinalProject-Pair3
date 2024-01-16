using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IAbilityDal : IRepository<Ability, Guid>, IAsyncRepository<Ability, Guid>
{

}