using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.Certificate.Requests;
using Business.Dtos.Certificate.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class CertificateMappingProfile : Profile
    {
        public CertificateMappingProfile()
        {
            CreateMap<Certificate, CreateCertificateRequest>().ReverseMap();
            CreateMap<Certificate, CreatedCertificateResponse>().ReverseMap();

            CreateMap<Certificate, UpdateCertificateRequest>().ReverseMap();
            CreateMap<Certificate, UpdatedCertificateResponse>().ReverseMap();

            CreateMap<Certificate, DeleteCertificateRequest>().ReverseMap();
            CreateMap<Certificate, DeletedCertificateResponse>().ReverseMap();

            CreateMap<Certificate, GetCertificateRequest>().ReverseMap();
            CreateMap<Certificate, GetCertificateResponse>().ForMember(destinationMember: p => p.UserName,
                memberOptions: opt => opt.MapFrom(p => p.User.FirstName + " " + p.User.LastName)).ReverseMap();


            CreateMap<Certificate, GetListedCertificateResponse>().ForMember(destinationMember: p => p.UserName,
                            memberOptions: opt => opt.MapFrom(p => p.User.FirstName + " " + p.User.LastName)).ReverseMap();
            CreateMap<Paginate<Certificate>, Paginate<GetListedCertificateResponse>>().ReverseMap();
        }
    }
}
