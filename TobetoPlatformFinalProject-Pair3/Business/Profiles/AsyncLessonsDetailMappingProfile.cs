﻿using AutoMapper;
using Business.Dtos.AsyncLessonsDetail.Requests;
using Business.Dtos.AsyncLessonsDetail.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class AsyncLessonsDetailMappingProfile : Profile
    {
        public AsyncLessonsDetailMappingProfile()
        {
            CreateMap<AsyncLessonsDetail, CreateAsyncLessonsDetailRequest>().ReverseMap();
            CreateMap<AsyncLessonsDetail, CreatedAsyncLessonsDetailResponse>().ReverseMap();

            CreateMap<AsyncLessonsDetail, UpdateAsyncLessonsDetailRequest>().ReverseMap();
            CreateMap<AsyncLessonsDetail, UpdatedAsyncLessonsDetailResponse>().ReverseMap();

            CreateMap<AsyncLessonsDetail, DeleteAsyncLessonsDetailRequest>().ReverseMap();
            CreateMap<AsyncLessonsDetail, DeletedAsyncLessonsDetailResponse>().ReverseMap();

            CreateMap<AsyncLessonsDetail, GetAsyncLessonsDetailRequest>().ReverseMap();
            CreateMap<AsyncLessonsDetail, GetAsyncLessonsDetailResponse>()
                .ForMember(destinationMember: p => p.AsyncLessonsOfContentName,
                memberOptions: opt => opt.MapFrom(p => p.AsyncLessonsOfContent.Name))

                .ForMember(destinationMember: p => p.AsyncLessonsOfContentDuration,
                memberOptions: opt => opt.MapFrom(p => p.AsyncLessonsOfContent.Duration))
                .ReverseMap();
            
            CreateMap<AsyncLessonsDetail, GetListedAsyncLessonsDetailResponse>()
                .ForMember(destinationMember: p => p.AsyncLessonsOfContentName,
                memberOptions: opt => opt.MapFrom(p => p.AsyncLessonsOfContent.Name))

                .ForMember(destinationMember: p => p.AsyncLessonsOfContentDuration,
                memberOptions: opt => opt.MapFrom(p => p.AsyncLessonsOfContent.Duration))
                .ReverseMap();
            
            CreateMap<Paginate<AsyncLessonsDetail>, Paginate<GetListedAsyncLessonsDetailResponse>>().ReverseMap();
        }
    }
}
