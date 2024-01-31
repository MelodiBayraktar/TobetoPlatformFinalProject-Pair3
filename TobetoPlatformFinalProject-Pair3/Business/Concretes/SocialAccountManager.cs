using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.BusinessRules;
using Business.Dtos.Ability.Responses;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Business.Dtos.SocialAccount.Requests;
using Business.Dtos.SocialAccount.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.GetUserId;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class SocialAccountManager : ISocialAccountService
{
    private ISocialAccountDal _socialAccountDal;
    private IMapper _mapper;
    private SocialAccountBusinessRules _socialAccountBusinessRules;
    private IGetUserId _getUserId;


    public SocialAccountManager(ISocialAccountDal socialAccountDal, IMapper mapper, SocialAccountBusinessRules socialAccountBusinessRules, IGetUserId getUserId)
    {
        _socialAccountDal = socialAccountDal;
        _mapper = mapper;
        _socialAccountBusinessRules = socialAccountBusinessRules;
        _getUserId = getUserId;
    }

    [SecuredOperation("socialAccounts.add,admin,mod")]
    [ValidationAspect(typeof(SocialAccountRequestValidator))]
    public async Task<CreatedSocialAccountResponse> AddAsync(CreateSocialAccountRequest createSocialAccountRequest)
    {
        SocialAccount socialAccount = _mapper.Map<SocialAccount>(createSocialAccountRequest);
        Guid userId = _getUserId.GetUserIdFromHttpContext();
        socialAccount.UserId = userId;
        await _socialAccountBusinessRules.MaxCountAsync(socialAccount.UserId);
        Expression<Func<SocialAccount, object>> includeExpressionForUser = x => x.User;
        var createSocialAccount = await _socialAccountDal.AddAsync(socialAccount, includeExpressionForUser);
        CreatedSocialAccountResponse response = _mapper.Map<CreatedSocialAccountResponse>(createSocialAccount);
        return response;
    }

    public async Task<DeletedSocialAccountResponse> DeleteAsync(DeleteSocialAccountRequest deleteSocialAccountRequest)
    {
        SocialAccount socialAccount = await _socialAccountDal.GetAsync(c => c.Id == deleteSocialAccountRequest.Id);
        var deleteSocialAccount = await _socialAccountDal.DeleteAsync(socialAccount);
        DeletedSocialAccountResponse response = _mapper.Map<DeletedSocialAccountResponse>(deleteSocialAccount);
        return response;
    }

    public async Task<GetSocialAccountResponse> GetById(GetSocialAccountRequest getSocialAccountRequest)
    {
        SocialAccount getSocialAccount = await _socialAccountDal.GetAsync(c => c.Id == getSocialAccountRequest.Id);
        GetSocialAccountResponse response = _mapper.Map<GetSocialAccountResponse>(getSocialAccount);
        return response;
    }

    public async Task<IPaginate<GetListedSocialAccountResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _socialAccountDal.GetListAsync(include: p => p.Include(p => p.User), index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedSocialAccountResponse> response = _mapper.Map<Paginate<GetListedSocialAccountResponse>>(getList);
        return response;
    }

    public async Task<UpdatedSocialAccountResponse> UpdateAsync(UpdateSocialAccountRequest updateSocialAccountRequest)
    {
        var result = await _socialAccountDal.GetAsync(predicate: a => a.Id == updateSocialAccountRequest.Id);
        _mapper.Map(updateSocialAccountRequest, result);
        await _socialAccountDal.UpdateAsync(result);
        UpdatedSocialAccountResponse response = _mapper.Map<UpdatedSocialAccountResponse>(result);
        return response;
    }
}