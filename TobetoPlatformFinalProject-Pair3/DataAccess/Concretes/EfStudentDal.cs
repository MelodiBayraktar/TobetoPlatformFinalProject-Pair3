﻿using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfStudentDal : EfRepositoryBase<Student, Guid, TobetoPlatformContext>, IStudentDal
{
    public EfStudentDal(TobetoPlatformContext context) : base(context)
    {
    }
}

