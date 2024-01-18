using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.PasswordReset.Requests;
using Business.Dtos.PasswordReset.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class PasswordResetMappingProfile : Profile
    {
        public PasswordResetMappingProfile()
        {
            CreateMap<PasswordReset, CreatePasswordResetRequest>().ReverseMap();
            CreateMap<PasswordReset, CreatedPasswordResetResponse>().ReverseMap();

            CreateMap<PasswordReset, UpdatePasswordResetRequest>().ReverseMap();
            CreateMap<PasswordReset, UpdatedPasswordResetResponse>().ReverseMap();
            
        }
    }
}
