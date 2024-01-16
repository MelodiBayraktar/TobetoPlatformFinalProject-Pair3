using Business.Dtos.Student.Requests;
using Business.Dtos.Student.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IStudentService
{
    Task<IPaginate<GetListedStudentResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedStudentResponse> AddAsync(CreateStudentRequest createStudentRequest);
    Task<UpdatedStudentResponse> UpdateAsync(UpdateStudentRequest updateStudentRequest);
    Task<DeletedStudentResponse> DeleteAsync(DeleteStudentRequest deleteStudentRequest);
    Task<GetStudentResponse> GetById(GetStudentRequest getStudentRequest);
}