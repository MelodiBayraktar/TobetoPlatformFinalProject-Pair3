using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfSettingsDal : EfRepositoryBase<Settings, Guid, TobetoPlatformContext>, ISettingsDal
{
    public EfSettingsDal(TobetoPlatformContext context) : base(context)
    {
    }
}

