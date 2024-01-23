using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.BusinessRules
{
    public class AnnouncementBusinessRules : BaseBusinessRules
    {

        IAnnouncementDal _announcementDal;

        public AnnouncementBusinessRules(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public Task AnnouncementMustExistWhenSelected(Announcement announcement)
        {
            if (announcement == null)
                throw new BusinessException(AnnouncementMessages.AnnouncementNotExists);
            return Task.CompletedTask;
        }

    }
}
