using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.BusinessRules;

public class ContactUsBusinessRules  : BaseBusinessRules
{
    IContactUsDal _contactUsDal;

    public ContactUsBusinessRules(IContactUsDal contactUsDal)
    {
        _contactUsDal = contactUsDal;
    }


    public Task ContactUsShouldExistWhenSelected(ContactUs? contactUs)
    {
        if (contactUs == null)
            throw new BusinessException(ContactUsMessages.ContactUsNotExists);
        return Task.CompletedTask;
    }
}