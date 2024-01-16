using Core.Entities.Abstracts;

namespace Core.Utilities.Security.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(IUser user, List<IOperationClaim> operationClaims);
}