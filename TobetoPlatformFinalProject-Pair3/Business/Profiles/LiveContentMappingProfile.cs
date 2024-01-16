using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.LiveContent.Requests;
using Business.Dtos.LiveContent.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class LiveContentMappingProfile : Profile
    {
        public LiveContentMappingProfile()
        {
            CreateMap<LiveContent, CreateLiveContentRequest>().ReverseMap();
            CreateMap<LiveContent, CreatedLiveContentResponse>().ReverseMap();

            CreateMap<LiveContent, UpdateLiveContentRequest>().ReverseMap();
            CreateMap<LiveContent, UpdatedLiveContentResponse>().ReverseMap();

            CreateMap<LiveContent, DeleteLiveContentRequest>().ReverseMap();
            CreateMap<LiveContent, DeletedLiveContentResponse>().ReverseMap();

            CreateMap<LiveContent, GetLiveContentRequest>().ReverseMap();
            CreateMap<LiveContent, GetLiveContentResponse>().ReverseMap();


            CreateMap<LiveContent, GetListedLiveContentResponse>().ReverseMap();
            CreateMap<Paginate<LiveContent>, Paginate<GetListedLiveContentResponse>>().ReverseMap();
        }
    }
}
