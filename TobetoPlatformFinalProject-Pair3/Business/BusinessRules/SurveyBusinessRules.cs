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
    public class SurveyBusinessRules : BaseBusinessRules
    {
        ISurveyDal _surveyDal;

        public SurveyBusinessRules(ISurveyDal surveyDal)
        {
            _surveyDal = surveyDal;
        }
        public Task SurveyShouldExistWhenSelected(Survey? survey)
        {
            if (survey == null)
                throw new BusinessException(SurveyMessages.SurveyNotExists);
            return Task.CompletedTask;
        }
    }
}
