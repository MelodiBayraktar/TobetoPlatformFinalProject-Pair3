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
        ICourseExamDal _courseexamDal;

        public CourseExamBusinessRules(ICourseExamDal courseexamDal)
        {
            _courseexamDal = courseexamDal;
        }

        public Task CheckIfExamNotExist(CourseExam courseexam)
        {
            if (courseexam == null) throw new BusinessException(CourseExamMessages.NotExist);
            return Task.CompletedTask;

        }
    }
}
