using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface INewsDal : IRepository<News, Guid>, IAsyncRepository<News, Guid>
{

}

