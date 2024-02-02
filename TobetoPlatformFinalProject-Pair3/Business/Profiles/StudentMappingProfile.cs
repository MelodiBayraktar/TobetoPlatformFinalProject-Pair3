using AutoMapper;
using Business.Dtos.Student.Requests;
using Business.Dtos.Student.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class StudentMappingProfile : Profile
{
    public StudentMappingProfile()
    {
        CreateMap<Student, CreateStudentRequest>().ReverseMap();
        CreateMap<Student, CreatedStudentResponse>().ReverseMap();

        CreateMap<Student, UpdateStudentRequest>().ReverseMap();
        CreateMap<Student, UpdatedStudentResponse>().ReverseMap();

        CreateMap<Student, DeleteStudentRequest>().ReverseMap();
        CreateMap<Student, DeletedStudentResponse>().ReverseMap();

        CreateMap<Student, GetStudentRequest>().ReverseMap();
        CreateMap<Student, GetStudentResponse>()
            .ForMember(destinationMember: p => p.UserName,
            memberOptions: opt => opt.MapFrom(p => p.User.FirstName + " " + p.User.LastName))
            .ReverseMap();
        
        CreateMap<Student, GetListedStudentResponse>()
            .ForMember(destinationMember: p => p.UserName,
            memberOptions: opt => opt.MapFrom(p => p.User.FirstName + " " + p.User.LastName))
            .ReverseMap();

        CreateMap<Paginate<Student>, Paginate<GetListedStudentResponse>>().ReverseMap();
    }
}
