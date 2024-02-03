using System.Collections;
using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.BusinessRules;
using Business.Constants;
using Business.Dtos.Auth.Requests;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.DataAccess.Paging;
using Core.Entities.Abstracts;
using Core.Utilities.Business.GetUserId;
using Core.Utilities.Business.Requests;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities;
using Entities.Concretes;

namespace Business.Concretes;

public class UserManager: IUserService
{
    private readonly IUserDal _userDal;
    private readonly IMapper _mapper;
    private readonly IGetUserId _getUserId;

    public UserManager(IUserDal userDal, IMapper mapper, IGetUserId getUserId)
    {
        _userDal = userDal;
        _mapper = mapper;
        _getUserId = getUserId;
    }

    [ValidationAspect(typeof(UserRequestValidator))]
    public async Task<CreatedUserResponse> AddAsync(CreateUserRequest createUserRequest)
    {
        var user = _mapper.Map<User>(createUserRequest);
        var createUser = await _userDal.AddAsync(user);
        CreatedUserResponse response = _mapper.Map<CreatedUserResponse>(createUser);
        return response;
    }

    public async Task<DeletedUserResponse> DeleteAsync(DeleteUserRequest deleteUserRequest)
    {
        var user = await _userDal.GetAsync(c => c.Id == deleteUserRequest.Id);
        var deleteUser = await _userDal.DeleteAsync(user);
        DeletedUserResponse response = _mapper.Map<DeletedUserResponse>(deleteUser);
        return response;
    }



    public async Task<GetUserResponse> GetById(GetUserRequest getUserRequest)
    {
        var getUser = await _userDal.GetAsync(c => c.Id == getUserRequest.Id);
        GetUserResponse response = _mapper.Map<GetUserResponse>(getUser);
        return response;
    }

    public async Task<User> GetByMailAsync(string email)
    {
        var result = await _userDal.GetAsync(u => u.Email == email);
        return result;
    }

    public List<IOperationClaim> GetClaims(IUser user)
    {
        return _userDal.GetClaims(user);
    }

    public async Task<IPaginate<GetListedUserResponse>> GetListAsync(PageRequest request)
    {
        var result = await _userDal.GetListAsync(index: request.Index, size: request.Size);
        Paginate<GetListedUserResponse> response = _mapper.Map<Paginate<GetListedUserResponse>>(result);
        return response;
    }

    public async Task<UpdatedUserResponse> UpdateAsync(UpdateUserRequest updateUserRequest)
    {
        var result = await _userDal.GetAsync(predicate: a => a.Id == updateUserRequest.Id);
        _mapper.Map(updateUserRequest, result);
        await _userDal.UpdateAsync(result);
        UpdatedUserResponse response = _mapper.Map<UpdatedUserResponse>(result);
        return response;
    }

    public async Task<UpdateUserPasswordResponse> UpdatePassword(UpdateUserPasswordRequest updateUserPasswordRequest)
    {
        Guid userId = _getUserId.GetUserIdFromHttpContext();
        var user = await _userDal.GetAsync(a => a.Id == userId);
        if (user == null || !HashingHelper.VerifyPasswordHash(updateUserPasswordRequest.OldPassword, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException(UserMessages.PasswordError);

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(updateUserPasswordRequest.NewPassword, out passwordHash, out passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        await _userDal.UpdateAsync(user);

        UpdateUserPasswordResponse response = _mapper.Map<UpdateUserPasswordResponse>(user);
        response.UserId = userId;

        return response;
    }
}

