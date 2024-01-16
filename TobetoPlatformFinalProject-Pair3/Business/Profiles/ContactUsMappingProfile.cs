using AutoMapper;
using Core.DataAccess.Paging;
using Entities.Concretes;

using Business.Dtos.Ability.Responses;
using Business.Dtos.ContactUs.Responses;
using Business.Dtos.ContactUs.Requests;

namespace Business.Profiles
{
    public class ContactUsMappingProfile : Profile
    {
        public ContactUsMappingProfile()
        {
            CreateMap<CreateContactUsRequest, ContactUs>().ReverseMap();
            CreateMap<ContactUs, CreatedContactUsResponse>().ReverseMap();

            CreateMap<UpdateContactUsRequest, ContactUs>().ReverseMap();
            CreateMap<ContactUs, UpdatedContactUsResponse>().ReverseMap();

            CreateMap<DeleteContactUsRequest, ContactUs>().ReverseMap();
            CreateMap<ContactUs, DeletedContactUsResponse>().ReverseMap();

            CreateMap<ContactUs, GetContactUsResponse>().ReverseMap();

            CreateMap<ContactUs, GetListedContactUsResponse>().ReverseMap();
            CreateMap<Paginate<ContactUs>, Paginate<GetListedContactUsResponse>>().ReverseMap();


            //CreateMap<ContactUs, GetListedContactUsResponse>()
            //    .ForMember(destinationMember: p => p.CategoryId,
            //    memberOptions: opt => opt.MapFrom(p => p.Category.Id)).ReverseMap();

            //CreateMap<ContactUs, GetListedContactUsResponse>()
            //    .ForMember(destinationMember: p => p.CategoryName,
            //    memberOptions: opt => opt.MapFrom(p => p.Category.Name)).ReverseMap();

            //CreateMap<ContactUs, GetListedContactUsResponse>()
            //    .ForMember(destinationMember: p => p.InstructorId,
            //    memberOptions: opt => opt.MapFrom(p => p.Instructor.Id)).ReverseMap();

            //CreateMap<ContactUs, GetListedContactUsResponse>()
            //    .ForMember(destinationMember: p => p.InstructorName,
            //    memberOptions: opt => opt.MapFrom(p => p.Instructor.Name)).ReverseMap();
        }
    }
}