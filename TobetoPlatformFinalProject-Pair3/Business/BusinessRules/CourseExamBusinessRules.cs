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
    public class CourseExamBusinessRules : BaseBusinessRules
    {
        ICourseExamDal _courseExamDal;

        public CourseExamBusinessRules(ICourseExamDal courseExamDal)
        {
            _courseExamDal = courseExamDal;
        }

        public Task CheckIfExamNotExist(CourseExam courseExam)
        {
            if (courseExam == null) 
                throw new BusinessException(CourseExamMessages.NotExist);
            return Task.CompletedTask;

        }
    }
}
