using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.AnnouncementsNewsCategory.Requests;
using Business.Dtos.AnnouncementsNewsCategory.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class AnnouncementsNewsCategoryMappingProfile : Profile
    {
        public AnnouncementsNewsCategoryMappingProfile()
        {
            CreateMap<AnnouncementsNewsCategory, CreateAnnouncementsNewsCategoryRequest>().ReverseMap();
            CreateMap<AnnouncementsNewsCategory, CreatedAnnouncementsNewsCategoryResponse>().ReverseMap();

            CreateMap<AnnouncementsNewsCategory, UpdateAnnouncementsNewsCategoryRequest>().ReverseMap();
            CreateMap<AnnouncementsNewsCategory, UpdatedAnnouncementsNewsCategoryResponse>().ReverseMap();

            CreateMap<AnnouncementsNewsCategory, DeleteAnnouncementsNewsCategoryRequest>().ReverseMap();
            CreateMap<AnnouncementsNewsCategory, DeletedAnnouncementsNewsCategoryResponse>().ReverseMap();

            CreateMap<AnnouncementsNewsCategory, GetAnnouncementsNewsCategoryRequest>().ReverseMap();
            CreateMap<AnnouncementsNewsCategory, GetAnnouncementsNewsCategoryResponse>().ReverseMap();

            CreateMap<AnnouncementsNewsCategory, GetListedAnnouncementsNewsCategoryResponse>().ReverseMap();
            CreateMap<Paginate<AnnouncementsNewsCategory>, Paginate<GetListedAnnouncementsNewsCategoryResponse>>().ReverseMap();
        }
    }
}
