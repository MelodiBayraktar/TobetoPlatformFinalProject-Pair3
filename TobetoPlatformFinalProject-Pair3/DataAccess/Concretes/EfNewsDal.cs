using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfNewsDal : EfRepositoryBase<News, Guid, TobetoPlatformContext>, INewsDal
{
    public EfNewsDal(TobetoPlatformContext context) : base(context)
    {
    }
}

