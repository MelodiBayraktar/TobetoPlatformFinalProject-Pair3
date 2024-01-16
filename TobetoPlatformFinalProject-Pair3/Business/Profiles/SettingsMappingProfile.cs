using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.Settings.Requests;
using Business.Dtos.Settings.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class SettingsMappingProfile : Profile
    {
        public SettingsMappingProfile()
        {
            CreateMap<Settings, UpdateSettingsRequest>().ReverseMap();
            CreateMap<Settings, UpdatedSettingsResponse>().ReverseMap();

            CreateMap<Settings, DeleteSettingsRequest>().ReverseMap();
            CreateMap<Settings, DeletedSettingsResponse>().ReverseMap();
        }
    }
}
