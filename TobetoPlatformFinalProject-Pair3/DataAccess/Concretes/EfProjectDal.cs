using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfProjectDal : EfRepositoryBase<Project, Guid, TobetoPlatformContext>, IProjectDal
{
    public EfProjectDal(TobetoPlatformContext context) : base(context)
    {
    }
}

