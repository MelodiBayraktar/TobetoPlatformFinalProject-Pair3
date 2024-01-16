using Business.Dtos.PasswordReset.Requests;
using Business.Dtos.PasswordReset.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IPasswordResetService
{
    Task<UpdatedPasswordResetResponse> UpdateAsync(UpdatePasswordResetRequest updatePasswordResetRequest);
}