using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IAsyncLessonsOfContentDal : IRepository<AsyncLessonsOfContent, Guid>, IAsyncRepository<AsyncLessonsOfContent, Guid>
{

}

