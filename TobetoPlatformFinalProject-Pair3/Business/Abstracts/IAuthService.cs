using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Auth.Requests;
using Core.Entities.Abstracts;
using Core.Utilities.Security.JWT;

namespace Business.Abstracts
{
    public interface IAuthService
    {
        Task<IUser> Register(AuthForRegisterRequest authForRegisterRequest, string password);
        Task<IUser> Login(AuthForLoginRequest authForLoginRequest);
        Task UserExists(string email);
        AccessToken CreateAccessToken(IUser user);
    }
}
