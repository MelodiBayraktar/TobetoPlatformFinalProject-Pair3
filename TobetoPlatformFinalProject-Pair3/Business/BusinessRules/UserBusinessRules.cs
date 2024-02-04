using Business.Constants;
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
    public class UserBusinessRules : BaseBusinessRules
    {
        IUserDal _userDal;

        public UserBusinessRules(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public Task CheckIfUserNotExist(User? user)
        {
            if (user == null) throw new BusinessException(UserMessages.UserNotExist);
            return Task.CompletedTask;

        }

        public Task CheckIfEmailExist(User? user)
        {
            if (user == null) throw new BusinessException(UserMessages.EmailNotExist);
            return Task.CompletedTask;
        }
    }

}
