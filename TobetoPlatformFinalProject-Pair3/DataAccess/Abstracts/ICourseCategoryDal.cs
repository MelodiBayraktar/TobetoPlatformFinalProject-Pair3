using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface ICourseCategoryDal : IRepository<CourseCategory, Guid>, IAsyncRepository<CourseCategory, Guid>
{

}

