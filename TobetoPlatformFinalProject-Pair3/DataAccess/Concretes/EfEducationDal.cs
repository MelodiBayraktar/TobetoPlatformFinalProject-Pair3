using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfEducationDal : EfRepositoryBase<Education, Guid, TobetoPlatformContext>, IEducationDal
{
    public EfEducationDal(TobetoPlatformContext context) : base(context)
    {
    }
}

