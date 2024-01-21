using Business.Constants;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Business.Rules;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstracts;
using Entities.Concretes;


namespace Business.BusinessRules;

public class AuthLoginBusinessRules : BaseBusinessRules
{
    private readonly IUserDal _userDal;

    public AuthLoginBusinessRules(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public async Task EmailExist(string email)
    {
        bool doesExists = await _userDal.AnyAsync(predicate: u => u.Email == email, enableTracking: false);
        if (!doesExists)
            throw new BusinessException(UserMessages.UserMailAlreadyExists);
    }
    public  Task UserPasswordMustBeMatched(User user, string password)
    {
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException(UserMessages.PasswordDontMatch);
        return Task.CompletedTask;
    }
}
