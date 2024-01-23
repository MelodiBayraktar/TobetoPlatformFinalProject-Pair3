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
    public class ExperienceBusinessRules : BaseBusinessRules
    {
        IExperienceDal _experienceDal;

        public ExperienceBusinessRules(IExperienceDal experienceDal)
        {
            _experienceDal = experienceDal;
        }

        public Task CheckIfExperienceNotExist(Experience? experience)
        {
            if (experience == null) 
                throw new BusinessException(ExperienceMessages.NotExist);
            return Task.CompletedTask;

        }
    }
}