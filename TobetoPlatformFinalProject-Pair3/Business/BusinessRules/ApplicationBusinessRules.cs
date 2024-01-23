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
    public class ApplicationBusinessRules : BaseBusinessRules
    {
        IApplicationDal _applicationDal;

        public ApplicationBusinessRules(IApplicationDal applicationDal)
        {
            _applicationDal = applicationDal;
        }


        public Task ApplicationShouldExistWhenSelected(Application? application)
        {
            if (application == null)
                throw new BusinessException(ApplicationMessages.ApplicationNotExists);
            return Task.CompletedTask;
        }
    }
}
