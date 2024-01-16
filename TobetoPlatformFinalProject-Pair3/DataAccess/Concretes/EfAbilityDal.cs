using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfAbilityDal : EfRepositoryBase<Ability, Guid, TobetoPlatformContext>, IAbilityDal
{
    public EfAbilityDal(TobetoPlatformContext context) : base(context)
    {
    }
}

