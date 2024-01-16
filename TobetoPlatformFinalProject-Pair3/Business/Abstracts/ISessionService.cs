using Business.Dtos.Session.Requests;
using Business.Dtos.Session.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ISessionService
{
    Task<IPaginate<GetListedSessionResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedSessionResponse> AddAsync(CreateSessionRequest createSessionRequest);
    Task<UpdatedSessionResponse> UpdateAsync(UpdateSessionRequest updateSessionRequest);
    Task<DeletedSessionResponse> DeleteAsync(DeleteSessionRequest deleteSessionRequest);
    Task<GetSessionResponse> GetById(GetSessionRequest getSessionRequest);
}