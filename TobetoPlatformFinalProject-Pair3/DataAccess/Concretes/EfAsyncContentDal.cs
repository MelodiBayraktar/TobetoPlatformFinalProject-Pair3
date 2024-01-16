using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfAsyncContentDal : EfRepositoryBase<AsyncContent, Guid, TobetoPlatformContext>, IAsyncContentDal
{
    public EfAsyncContentDal(TobetoPlatformContext context) : base(context)
    {
    }
}

