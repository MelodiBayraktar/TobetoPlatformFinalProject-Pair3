using Core.DataAccess.Paging;
using Business.Dtos.ContactUs.Responses;
using Business.Dtos.ContactUs.Requests;
using Core.Utilities.Business.Requests;


namespace Business.Abstracts;

public interface IContactUsService
{
    Task<IPaginate<GetListedContactUsResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedContactUsResponse> AddAsync(CreateContactUsRequest createContactUsRequest);
    Task<UpdatedContactUsResponse> UpdateAsync(UpdateContactUsRequest updateContactUsRequest);
    Task<DeletedContactUsResponse> DeleteAsync(DeleteContactUsRequest deleteContactUsRequest);
    Task<GetContactUsResponse> GetById(GetContactUsRequest getContactUsRequest);
}
