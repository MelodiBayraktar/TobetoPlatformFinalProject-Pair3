using Business.Abstracts;
using Business.Constants;
using Business.Dtos.Auth.Requests;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities.Abstracts;
using Core.Utilities.Business.Rules;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstracts;



namespace Business.BusinessRules;

public class AuthLoginBusinessRules : BaseBusinessRules
{
    private readonly IUserService _userService;
    private readonly IUserDal _userDal;

    public AuthLoginBusinessRules(IUserService userService,IUserDal userDal)
    {

        _userService = userService;
        _userDal = userDal;
    }

    public async Task EmailExist(string email)
    {
        bool doesExists = await _userDal.AnyAsync(predicate: u => u.Email == email, enableTracking: false);
        if (!doesExists)
            throw new BusinessException(UserMessages.UserMailNotExists);
    }
    public async Task<IUser> UserPasswordMustBeMatched(AuthForLoginRequest authForLoginRequest)
    {
        //if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        //    throw new BusinessException(UserMessages.PasswordDontMatch);
        //return Task.CompletedTask;
        var user = await _userService.GetByMailAsync(authForLoginRequest.Email);
        if (user == null || !HashingHelper.VerifyPasswordHash(authForLoginRequest.Password, user.PasswordHash, user.PasswordSalt))
        throw new BusinessException(UserMessages.PasswordError);
        return user;  
    }
}
