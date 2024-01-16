using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IAsyncLessonsDetailDal : IRepository<AsyncLessonsDetail, Guid>, IAsyncRepository<AsyncLessonsDetail, Guid>
    {
    }
}
