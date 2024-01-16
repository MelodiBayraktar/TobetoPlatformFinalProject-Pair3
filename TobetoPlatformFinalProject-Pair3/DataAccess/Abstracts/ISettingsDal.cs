using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface ISettingsDal : IRepository<Settings, Guid>, IAsyncRepository<Settings, Guid>
{

}

