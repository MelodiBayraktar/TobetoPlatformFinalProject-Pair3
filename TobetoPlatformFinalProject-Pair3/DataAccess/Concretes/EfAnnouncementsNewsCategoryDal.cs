﻿using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfAnnouncementsNewsCategoryDal : EfRepositoryBase<AnnouncementsNewsCategory, Guid, TobetoPlatformContext>, IAnnouncementsNewsCategoryDal
{
    public EfAnnouncementsNewsCategoryDal(TobetoPlatformContext context) : base(context)
    {
    }
}

