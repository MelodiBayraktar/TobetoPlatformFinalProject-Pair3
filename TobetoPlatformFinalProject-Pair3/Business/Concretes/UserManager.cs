using AutoMapper;
using Business.Abstracts;
using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using Core.Entities.Abstracts;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class UserManager: IUserService
{
    IUserDal _userDal;
    IMapper _mapper;

    public UserManager(IUserDal userDal, IMapper mapper)
    {
        _userDal = userDal;
        _mapper = mapper;
    }

    public async Task<CreatedUserResponse> AddAsync(CreateUserRequest createUserRequest)
    {
        var user = _mapper.Map<User>(createUserRequest);
        var createUser = await _userDal.AddAsync(user);
        return _mapper.Map<CreatedUserResponse>(createUser);
    }

    public async Task<DeletedUserResponse> DeleteAsync(DeleteUserRequest deleteUserRequest)
    {
        var user = await _userDal.GetAsync(c => c.Id == deleteUserRequest.Id);
        var deleteUser = await _userDal.DeleteAsync(user);
        return _mapper.Map<DeletedUserResponse>(deleteUser);
    }

    public async Task<GetUserResponse> GetById(GetUserRequest getUserRequest)
    {
        var getUser = await _userDal.GetAsync(c => c.Id == getUserRequest.Id);
        return _mapper.Map<GetUserResponse>(getUser);
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
        var user = _mapper.Map<User>(updateUserRequest);
        var updatedUser = await _userDal.UpdateAsync(user);
        return _mapper.Map<UpdatedUserResponse>(updatedUser);
    }
}