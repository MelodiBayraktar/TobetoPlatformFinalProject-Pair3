using Business.Dtos.SocialAccount.Requests;
using Business.Dtos.SocialAccount.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ISocialAccountService
{
    Task<IPaginate<GetListedSocialAccountResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedSocialAccountResponse> AddAsync(CreateSocialAccountRequest createSocialAccountRequest);
    Task<UpdatedSocialAccountResponse> UpdateAsync(UpdateSocialAccountRequest updateSocialAccountRequest);
    Task<DeletedSocialAccountResponse> DeleteAsync(DeleteSocialAccountRequest deleteSocialAccountRequest);
    Task<GetSocialAccountResponse> GetById(GetSocialAccountRequest getSocialAccountRequest);
}