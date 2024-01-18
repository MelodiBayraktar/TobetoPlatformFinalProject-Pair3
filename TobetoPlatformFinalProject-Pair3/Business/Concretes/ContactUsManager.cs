using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Business.Dtos.ContactUs.Responses;
using Business.Dtos.ContactUs.Requests;
using Core.Utilities.Business.Requests;
using Entities.Concretes;

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

    [SecuredOperation("admin")]
    public async Task<CreatedContactUsResponse> AddAsync(CreateContactUsRequest createContactUsRequest)
    {
        var contactUs = _mapper.Map<ContactUs>(createContactUsRequest);
        var createContactUs = await _contactUsDal.AddAsync(contactUs);
        return _mapper.Map<CreatedContactUsResponse>(createContactUs);
    }

    public async Task<DeletedContactUsResponse> DeleteAsync(DeleteContactUsRequest deleteContactUsRequest)
    {
        var contactUs = await _contactUsDal.GetAsync(c => c.Id == deleteContactUsRequest.Id);
        var deletecontactUs = await _contactUsDal.DeleteAsync(contactUs);
        return _mapper.Map<DeletedContactUsResponse>(deletecontactUs);
    }

    public async Task<GetContactUsResponse> GetById(GetContactUsRequest getContactUsRequest)
    {
        var getContactUs = await _contactUsDal.GetAsync(c => c.Id == getContactUsRequest.Id);
        return _mapper.Map<GetContactUsResponse>(getContactUs);
    }


    public async Task<IPaginate<GetListedContactUsResponse>> GetListAsync(PageRequest pageRequest)
    {
        var result = await _contactUsDal.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedContactUsResponse> response = _mapper.Map<Paginate<GetListedContactUsResponse>>(result);
        return response;
    }

    public async Task<UpdatedContactUsResponse> UpdateAsync(UpdateContactUsRequest updateContactUsRequest)
    {
        var contactUs = _mapper.Map<ContactUs>(updateContactUsRequest);
        var updatedContactUs = await _contactUsDal.UpdateAsync(contactUs);
        return _mapper.Map<UpdatedContactUsResponse>(updatedContactUs);
    }
}