using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfAsyncCourseDal : EfRepositoryBase<AsyncCourse, Guid, TobetoPlatformContext>, IAsyncCourseDal
{
    public EfAsyncCourseDal(TobetoPlatformContext context) : base(context)
    {
    }
}

