using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
using Core.DataAccess.Paging;
using Core.Entities.Abstracts;
using Core.Utilities.Business.Requests;
using Entities.Concretes;

namespace Business.Abstracts;

public interface IUserService
{
    Task<IPaginate<GetListedUserResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedUserResponse> AddAsync(CreateUserRequest createUserRequest);
    Task<UpdatedUserResponse> UpdateAsync(UpdateUserRequest updateUserRequest);
    Task<DeletedUserResponse> DeleteAsync(DeleteUserRequest deleteUserRequest);
    Task<GetUserResponse> GetById(GetUserRequest getUserRequest);
    Task<User> GetByMailAsync(string email);
    List<IOperationClaim> GetClaims(IUser user);

    Task<UpdateUserPasswordResponse> UpdatePassword(UpdateUserPasswordRequest updateUserPasswordRequest);
    Task<PasswordResetEmailResponse> ForgotPassword(PasswordResetEmailRequest passwordResetEmailRequest);
    Task<ResetPasswordResponse> ResetPassword(ResetPasswordRequest resetPasswordRequest);

    //Task<ResetPasswordResponse> SendEmail(string body);
}

