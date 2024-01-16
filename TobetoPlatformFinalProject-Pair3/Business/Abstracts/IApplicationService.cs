using Business.Dtos.Application.Requests;
using Business.Dtos.Application.Responses;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;

namespace Business.Abstracts;

public interface IApplicationService
{
    Task<IPaginate<GetListedApplicationResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedApplicationResponse> AddAsync(CreateApplicationRequest createApplicationRequest);
    Task<UpdatedApplicationResponse> UpdateAsync(UpdateApplicationRequest updateApplicationRequest);
    Task<DeletedApplicationResponse> DeleteAsync(DeleteApplicationRequest deleteApplicationRequest);
    Task<GetApplicationResponse> GetById(GetApplicationRequest getApplicationRequest);
}