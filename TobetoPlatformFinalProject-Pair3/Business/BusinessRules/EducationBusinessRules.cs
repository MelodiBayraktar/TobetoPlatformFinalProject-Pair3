using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Business.Rules;
using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class EducationBusinessRules : BaseBusinessRules
    {
        IEducationDal _educationDal;

        public EducationBusinessRules(IEducationDal educationDal)
        {
            _educationDal = educationDal;
        }

        public Task CheckIfEducationNotExist(Education? education)
        {
            if (education == null) 
                throw new BusinessException(EducationMessages.NotExist);
            return Task.CompletedTask;

        }
    }
}
