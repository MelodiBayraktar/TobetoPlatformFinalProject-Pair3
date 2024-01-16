using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class EfAsyncLessonsDetailDal : EfRepositoryBase<AsyncLessonsDetail, Guid, TobetoPlatformContext>, IAsyncLessonsDetailDal
    {
        public EfAsyncLessonsDetailDal(TobetoPlatformContext context) : base(context)
        {
        }
    }
}
