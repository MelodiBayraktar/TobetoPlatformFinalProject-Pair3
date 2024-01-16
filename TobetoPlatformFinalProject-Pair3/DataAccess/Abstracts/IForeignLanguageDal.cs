using Core.DataAccess.Repositories;
using Entities;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IForeignLanguageDal : IRepository<ForeignLanguage, Guid>, IAsyncRepository<ForeignLanguage, Guid>
{

}

