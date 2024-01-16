using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfCourseDetailDal : EfRepositoryBase<CourseDetail, Guid, TobetoPlatformContext>, ICourseDetailDal
{
    public EfCourseDetailDal(TobetoPlatformContext context) : base(context)
    {
    }
}

