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
            
        }
    }
}