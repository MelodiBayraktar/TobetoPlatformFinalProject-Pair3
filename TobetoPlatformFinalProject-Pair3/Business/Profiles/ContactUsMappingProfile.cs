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
            CreateMap<ContactUs, CreateContactUsRequest>().ReverseMap();
            CreateMap<ContactUs, CreatedContactUsResponse>().ReverseMap();

            CreateMap<ContactUs, UpdateContactUsRequest>().ReverseMap();
            CreateMap<ContactUs, UpdatedContactUsResponse>().ReverseMap();

            CreateMap<ContactUs, DeleteContactUsRequest>().ReverseMap();
            CreateMap<ContactUs, DeletedContactUsResponse>().ReverseMap();

            CreateMap<ContactUs, GetContactUsRequest>().ReverseMap();
            CreateMap<ContactUs, GetContactUsResponse>().ReverseMap();

            CreateMap<ContactUs, GetListedContactUsResponse>().ReverseMap();
            CreateMap<Paginate<ContactUs>, Paginate<GetListedContactUsResponse>>().ReverseMap();
            
        }
    }
}