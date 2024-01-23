using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class PersonalInfoBusinessRules : BaseBusinessRules
    {
        IPersonalInfoDal _personalInfoDal;

        public PersonalInfoBusinessRules(IPersonalInfoDal personalInfoDal)
        {
            _personalInfoDal = personalInfoDal;
        }

        public Task PersonalInformationShouldExistWhenSelected(PersonalInfo personalInfo)
        {
            if (personalInfo == null)
                throw new BusinessException(PersonalInfoMessages.PersonalInfoNotExists);
            return Task.CompletedTask;
        }
    }
}
