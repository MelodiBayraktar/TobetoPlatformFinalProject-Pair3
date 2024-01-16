using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface ILiveContentDal : IRepository<LiveContent, Guid>, IAsyncRepository<LiveContent, Guid>
{

}

