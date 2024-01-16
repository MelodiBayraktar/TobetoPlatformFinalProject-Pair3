using Core.DataAccess.Repositories;
using Entities;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface ICourseExamDal : IRepository<CourseExam, Guid>, IAsyncRepository<CourseExam, Guid>
{

}

