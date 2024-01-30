using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Business.Dtos.ContactUs.Responses;
using Business.Dtos.ContactUs.Requests;
using Core.Utilities.Business.Requests;
using Entities.Concretes;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;

namespace Business.Concretes;

public class ContactUsManager:IContactUsService
{
    IContactUsDal _contactUsDal;
    IMapper _mapper;

    public ContactUsManager(IContactUsDal contactUsDal, IMapper mapper)
    {
        _contactUsDal = contactUsDal;
        _mapper = mapper;
    }
    
    [ValidationAspect(typeof(ContactUsRequestValidator))]
    public async Task<CreatedContactUsResponse> AddAsync(CreateContactUsRequest createContactUsRequest)
    {
        ContactUs contactUs = _mapper.Map<ContactUs>(createContactUsRequest);
        var createContactUs = await _contactUsDal.AddAsync(contactUs);
        CreatedContactUsResponse response =  _mapper.Map<CreatedContactUsResponse>(createContactUs);
        return response;
    }

    public async Task<DeletedContactUsResponse> DeleteAsync(DeleteContactUsRequest deleteContactUsRequest)
    {
        ContactUs contactUs = await _contactUsDal.GetAsync(c => c.Id == deleteContactUsRequest.Id);
        await _contactUsDal.DeleteAsync(contactUs);
        DeletedContactUsResponse response = _mapper.Map<DeletedContactUsResponse>(contactUs);
        return response;
    }

    public async Task<GetContactUsResponse> GetById(GetContactUsRequest getContactUsRequest)
    {
        ContactUs getContactUs = await _contactUsDal.GetAsync(c => c.Id == getContactUsRequest.Id);
        GetContactUsResponse response = _mapper.Map<GetContactUsResponse>(getContactUs);
        return response;
    }
    
    public async Task<IPaginate<GetListedContactUsResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _contactUsDal.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedContactUsResponse> response = _mapper.Map<Paginate<GetListedContactUsResponse>>(getList);
        return response;
    }

    public async Task<UpdatedContactUsResponse> UpdateAsync(UpdateContactUsRequest updateContactUsRequest)
    {
        var result = await _contactUsDal.GetAsync(predicate: a => a.Id == updateContactUsRequest.Id);
        _mapper.Map(updateContactUsRequest, result);
        await _contactUsDal.UpdateAsync(result);
        UpdatedContactUsResponse response = _mapper.Map<UpdatedContactUsResponse>(result);
        return response;
    }
}