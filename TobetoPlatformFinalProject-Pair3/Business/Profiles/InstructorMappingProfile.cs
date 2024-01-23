using AutoMapper;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Core.DataAccess.Paging;
using Entities;
using Entities.Concretes;

namespace Business.Profiles;

public class InstructorMappingProfile : Profile
{
    public InstructorMappingProfile()
    {
        CreateMap<Instructor, CreateInstructorRequest>().ReverseMap();
        CreateMap<Instructor, CreatedInstructorResponse>().ReverseMap();

        CreateMap<Instructor, UpdateInstructorRequest>().ReverseMap();
        CreateMap<Instructor, UpdatedInstructorResponse>().ReverseMap();

        CreateMap<Instructor, DeleteInstructorRequest>().ReverseMap();
        CreateMap<Instructor, DeletedInstructorResponse>().ReverseMap();

        CreateMap<Instructor, GetInstructorRequest>().ReverseMap();
        CreateMap<Instructor, GetInstructorResponse>().ForMember(destinationMember: p => p.UserName,
            memberOptions: opt => opt.MapFrom(p => p.User.FirstName + " " + p.User.LastName)).ReverseMap();


        CreateMap<Instructor, GetListedInstructorResponse>().ForMember(destinationMember: p => p.UserName,
                        memberOptions: opt => opt.MapFrom(p => p.User.FirstName + " " + p.User.LastName)).ReverseMap();
        CreateMap<Paginate<Instructor>, Paginate<GetListedInstructorResponse>>().ReverseMap();
    }
}
