using Core.DataAccess.Repositories;
using Entities;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface ICourseDetailDal : IRepository<CourseDetail, Guid>, IAsyncRepository<CourseDetail, Guid>
{

}

