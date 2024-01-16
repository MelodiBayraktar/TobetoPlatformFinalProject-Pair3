using AutoMapper;
using Business.Abstracts;
using Business.Dtos.SocialAccount.Requests;
using Business.Dtos.SocialAccount.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class SocialAccountManager : ISocialAccountService
{
    private ISocialAccountDal _socialAccountDal;
    private IMapper _mapper;

    public SocialAccountManager(ISocialAccountDal socialAccountDal, IMapper mapper)
    {
        _socialAccountDal = socialAccountDal;
        _mapper = mapper;
    }

    public async Task<CreatedSocialAccountResponse> AddAsync(CreateSocialAccountRequest createSocialAccountRequest)
    {
        var socialAccount = _mapper.Map<SocialAccount>(createSocialAccountRequest);
        var createSocialAccount = await _socialAccountDal.AddAsync(socialAccount);
        return _mapper.Map<CreatedSocialAccountResponse>(createSocialAccount);
    }

    public async Task<DeletedSocialAccountResponse> DeleteAsync(DeleteSocialAccountRequest deleteSocialAccountRequest)
    {
        var socialAccount = await _socialAccountDal.GetAsync(c => c.Id == deleteSocialAccountRequest.Id);
        var deleteSocialAccount = await _socialAccountDal.DeleteAsync(socialAccount);
        return _mapper.Map<DeletedSocialAccountResponse>(deleteSocialAccount);
    }

    public async Task<GetSocialAccountResponse> GetById(GetSocialAccountRequest getSocialAccountRequest)
    {
        var getSocialAccount = await _socialAccountDal.GetAsync(c => c.Id == getSocialAccountRequest.Id);
        return _mapper.Map<GetSocialAccountResponse>(getSocialAccount);
    }

    public async Task<IPaginate<GetListedSocialAccountResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _socialAccountDal.GetListAsync(include: p => p.Include(p => p.User), index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedSocialAccountResponse>>(getList);
    }

    public async Task<UpdatedSocialAccountResponse> UpdateAsync(UpdateSocialAccountRequest updateSocialAccountRequest)
    {
        var socialAccount = _mapper.Map<SocialAccount>(updateSocialAccountRequest);
        var updatedSocialAccount = await _socialAccountDal.UpdateAsync(socialAccount);
        return _mapper.Map<UpdatedSocialAccountResponse>(updatedSocialAccount);
    }
}