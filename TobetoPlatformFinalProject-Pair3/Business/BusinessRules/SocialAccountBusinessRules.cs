using Business.Constants;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Business.Rules;
using DataAccess.Abstracts;

namespace Business.BusinessRules;

public class SocialAccountBusinessRules  : BaseBusinessRules
{
    private readonly ISocialAccountDal _socialAccountDal;
    public SocialAccountBusinessRules(ISocialAccountDal socialAccountDal)
    {
        _socialAccountDal = socialAccountDal;
    }

    public async Task MaxCountAsync(Guid userId)
    {
        var result = await _socialAccountDal.GetListAsync(sm => sm.UserId == userId);

        if (result.Count > 3)
        {
            throw new BusinessException(SocialAccountMessages.SocialMediaLimit);
        }
    }
}
