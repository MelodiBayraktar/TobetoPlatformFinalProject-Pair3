using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfLiveContentDal : EfRepositoryBase<LiveContent, Guid, TobetoPlatformContext>, ILiveContentDal
{
    public EfLiveContentDal(TobetoPlatformContext context) : base(context)
    {
    }
}

