using AutoMapper;
using Business.Abstracts;
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

    public AuthManager(IUserService userService, IMapper mapper, ITokenHelper tokenHelper)
    {
        _userService = userService;
        _mapper = mapper;
        _tokenHelper = tokenHelper;
    }
    public async Task<IUser> Login(AuthForLoginRequest authForLoginRequest)
    {
        User user = _mapper.Map<User>(authForLoginRequest);
        var userLogin = await _userService.GetByMailAsync(user.Email);

        if (userLogin == null)
        {

            throw new BusinessException(BusinessMessages.UserNotBeExist);
        }

        if (!HashingHelper.VerifyPasswordHash(authForLoginRequest.Password, userLogin.PasswordHash, userLogin.PasswordSalt))
        {
            throw new BusinessException(BusinessMessages.PasswordUncorrect);
        }

        return user;
    }

    public async Task<IUser> Register(AuthForRegisterRequest authForRegisterRequest, string password)
    {
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
