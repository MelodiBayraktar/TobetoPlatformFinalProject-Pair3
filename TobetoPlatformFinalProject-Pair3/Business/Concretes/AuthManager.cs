using AutoMapper;
using Business.Abstracts;
using Business.BusinessRules;
using Business.Constants;
using Business.Dtos.Auth.Requests;
using Business.Dtos.Auth.Responses;
using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities.Abstracts;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concretes;

namespace Business.Concretes;
public class AuthManager : IAuthService
{
    IUserService _userService;
    IMapper _mapper;
    ITokenHelper _tokenHelper;
    AuthRegisterBusinessRules _authRegisterBusinessRules;
    AuthLoginBusinessRules _authLoginBusinessRules;
    

    public AuthManager(IUserService userService, IMapper mapper, ITokenHelper tokenHelper, AuthRegisterBusinessRules authRegisterBusinessRules, AuthLoginBusinessRules authLoginBusinessRules)
    {
        _userService = userService;
        _mapper = mapper;
        _tokenHelper = tokenHelper;
        _authRegisterBusinessRules = authRegisterBusinessRules;
        _authLoginBusinessRules = authLoginBusinessRules;
    }

    //public async Task<IUser> Login(AuthForLoginRequest authForLoginRequest)
    //{
    //    User user = _mapper.Map<User>(authForLoginRequest);
    //    var userLogin = await _userService.GetByMailAsync(user.Email);

    //    await _authLoginBusinessRules.EmailExist(authForLoginRequest.Email);
    //    await _authLoginBusinessRules.UserPasswordMustBeMatched(user, authForLoginRequest.Password);


    //    if (userLogin == null)
    //    {

    //        throw new BusinessException(BusinessMessages.UserNotBeExist);
    //    }

    //    if (!HashingHelper.VerifyPasswordHash(authForLoginRequest.Password, userLogin.PasswordHash, userLogin.PasswordSalt))
    //    {
    //        throw new BusinessException(BusinessMessages.PasswordUncorrect);
    //    }

    //    return user;
    //}
    public async Task<IUser> Login(AuthForLoginRequest authForLoginRequest)
    {
        User user = _mapper.Map<User>(authForLoginRequest);
        var userToCheck = await _userService.GetByMailAsync(authForLoginRequest.Email);
        await _authLoginBusinessRules.EmailExist(authForLoginRequest.Email);
        await _authLoginBusinessRules.UserPasswordMustBeMatched(authForLoginRequest);

        //if (userToCheck == null || !HashingHelper.VerifyPasswordHash(authForLoginRequest.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
        //  throw new BusinessException(BusinessMessages.LoginError);
        //return userToCheck;
        //{

        //    throw new BusinessException(BusinessMessages.UserNotBeExist);
        //}
        return user;
    }

    public async Task<IUser> Register(AuthForRegisterRequest authForRegisterRequest, string password)
    {
        await _authRegisterBusinessRules.EmailExist(authForRegisterRequest.Email);
        User user = _mapper.Map<User>(authForRegisterRequest);

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        CreateUserRequest createUserRequest = _mapper.Map<CreateUserRequest>(user);

        await _userService.AddAsync(createUserRequest);
        return user;
    }


    public async Task UserExists(string email)
    {
        var user = await _userService.GetByMailAsync(email);

        if (user != null)
        {
            throw new BusinessException(BusinessMessages.UserAlreadyExists);
        }
    }

    public AccessToken CreateAccessToken(IUser user)
    {
        var claims = _userService.GetClaims(user);
        var accessToken = _tokenHelper.CreateToken(user, claims);
        return accessToken;
    }
}
