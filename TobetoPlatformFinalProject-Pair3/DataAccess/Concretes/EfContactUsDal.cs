using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfContactUsDal : EfRepositoryBase<ContactUs, Guid, TobetoPlatformContext>, IContactUsDal
{
    public EfContactUsDal(TobetoPlatformContext context) : base(context)
    {
    }
}

