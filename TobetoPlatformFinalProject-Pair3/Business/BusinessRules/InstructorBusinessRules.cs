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
    public class InstructorBusinessRules : BaseBusinessRules
    {
        IInstructorDal _instructorDal;

        public InstructorBusinessRules(IInstructorDal instructorDal)
        {
            _instructorDal = instructorDal;
        }


        public Task InstructorShouldExistWhenSelected(Instructor? instructor)
        {
            if (instructor == null)
                throw new BusinessException(InstructorMessages.InstructorNotExists);
            return Task.CompletedTask;
        }
    }
}
