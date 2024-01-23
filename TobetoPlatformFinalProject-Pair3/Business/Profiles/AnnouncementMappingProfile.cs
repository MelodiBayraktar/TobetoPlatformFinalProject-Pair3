using AutoMapper;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.Announcement.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class AnnouncementMappingProfile : Profile
{
    public AnnouncementMappingProfile()
    {
        CreateMap<Announcement, CreateAnnouncementRequest>().ReverseMap();
        //CreateMap<Announcement, CreatedAnnouncementResponse>().ForMember(destinationMember: p => p.AnnouncementsNewsCategoryId,
        //                memberOptions: opt => opt.MapFrom(p => p.AnnouncementsNewsCategory.Id)).ReverseMap();

        //CreateMap<Announcement, CreatedAnnouncementResponse>().ForMember(destinationMember: p => p.ProjectId,
        //                memberOptions: opt => opt.MapFrom(p => p.Project.Id)).ReverseMap();
        CreateMap<Announcement, CreatedAnnouncementResponse>().ForMember(destinationMember: p => p.AnnouncementsNewsCategoryName,
                        memberOptions: opt => opt.MapFrom(p => p.AnnouncementsNewsCategory.Name)).ReverseMap();

        CreateMap<Announcement, CreatedAnnouncementResponse>().ForMember(destinationMember: p => p.ProjectName,
                        memberOptions: opt => opt.MapFrom(p => p.Project.Name)).ReverseMap();

        CreateMap<Announcement, UpdateAnnouncementRequest>().ReverseMap();
        CreateMap<Announcement, UpdatedAnnouncementResponse>().ReverseMap();

        CreateMap<Announcement, DeleteAnnouncementRequest>().ReverseMap();
        CreateMap<Announcement, DeletedAnnouncementResponse>().ReverseMap();

        CreateMap<Announcement, GetAnnouncementRequest>().ReverseMap();
        CreateMap<Announcement, GetAnnouncementResponse>().ReverseMap();
        
        CreateMap<Announcement, GetAnnouncementResponse>().ForMember(destinationMember: p => p.AnnouncementsNewsCategoryName,
            memberOptions: opt => opt.MapFrom(p => p.AnnouncementsNewsCategory.Name)).ReverseMap();
        
        CreateMap<Announcement, GetAnnouncementResponse>().ForMember(destinationMember: p => p.ProjectName,
            memberOptions: opt => opt.MapFrom(p =>  p.Project.Name)).ReverseMap();


        CreateMap<Announcement, GetListedAnnouncementResponse>().ForMember(destinationMember: p => p.AnnouncementsNewsCategoryName,
                        memberOptions: opt => opt.MapFrom(p => p.AnnouncementsNewsCategory.Name)).ReverseMap();

        CreateMap<Announcement, GetListedAnnouncementResponse>().ForMember(destinationMember: p => p.ProjectName,
                        memberOptions: opt => opt.MapFrom(p => p.Project.Name)).ReverseMap();

        CreateMap<Paginate<Announcement>, Paginate<GetListedAnnouncementResponse>>().ReverseMap();
    }
}
