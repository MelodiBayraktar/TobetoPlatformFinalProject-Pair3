using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IInstructorService
{
    Task<IPaginate<GetListedInstructorResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedInstructorResponse> AddAsync(CreateInstructorRequest createInstructorRequest);
    Task<UpdatedInstructorResponse> UpdateAsync(UpdateInstructorRequest updateInstructorRequest);
    Task<DeletedInstructorResponse> DeleteAsync(DeleteInstructorRequest deleteInstructorRequest);
    Task<GetInstructorResponse> GetById(GetInstructorRequest getInstructorRequest);
}