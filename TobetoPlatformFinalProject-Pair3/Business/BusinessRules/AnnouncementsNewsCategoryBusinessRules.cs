using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class AnnouncementsNewsCategoryBusinessRules
    {
        IAnnouncementsNewsCategoryDal _announcementsNewsCategoryDal;
        public AnnouncementsNewsCategoryBusinessRules(IAnnouncementsNewsCategoryDal announcementsNewsCategoryDal)
        {
            _announcementsNewsCategoryDal = announcementsNewsCategoryDal;
        }

        public Task AnnouncementsNewsCategoryMustExistWhenSelected(AnnouncementsNewsCategory announcementsNewsCategory)
        {
            if (announcementsNewsCategory == null)
                throw new BusinessException(AnnouncementsNewsCategoryMessages.AnnouncementsNewsCategoryNotExists);
            return Task.CompletedTask;
        }
    }
}
