using Business.Dtos.Application.Requests;
using Business.Dtos.Application.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IApplicationService
{
    Task<IPaginate<GetListedApplicationResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedApplicationResponse> AddAsync(CreateApplicationRequest createApplicationRequest);
    Task<UpdatedApplicationResponse> UpdateAsync(UpdateApplicationRequest updateApplicationRequest);
    Task<DeletedApplicationResponse> DeleteAsync(DeleteApplicationRequest deleteApplicationRequest);
    Task<GetApplicationResponse> GetById(GetApplicationRequest getApplicationRequest);
}