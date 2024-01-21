using Business.Constants;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Business.Rules;
using DataAccess.Abstracts;

namespace Business.BusinessRules;

public class AuthRegisterBusinessRules : BaseBusinessRules
{
    private readonly IUserDal _userDal;

    public AuthRegisterBusinessRules(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public async Task EmailExist(string email)
    {
        bool doesExists = await _userDal.AnyAsync(predicate: u => u.Email == email, enableTracking: false);
        if (doesExists)
            throw new BusinessException(UserMessages.UserMailNotExists);
    }
}
    
