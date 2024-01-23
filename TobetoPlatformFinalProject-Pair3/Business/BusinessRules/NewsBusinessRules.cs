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
    public class NewsBusinessRules : BaseBusinessRules
    {

        INewsDal _newsDal;

        public NewsBusinessRules (INewsDal newsDal)
        {
            _newsDal = newsDal;
        }

        public Task NewsMustExistWhenSelected(News news)
        {
            if (news == null)
                throw new BusinessException(NewsMessages.NewsNotExists);
            return Task.CompletedTask;
        }
    }
}
