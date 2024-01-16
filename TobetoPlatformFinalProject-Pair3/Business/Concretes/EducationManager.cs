using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Education.Requests;
using Business.Dtos.Education.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class EducationManager : IEducationService
{
    private IEducationDal _educationDal;
    private IMapper _mapper;

    public EducationManager(IEducationDal educationDal, IMapper mapper)
    {
        _educationDal = educationDal;
        _mapper = mapper;
    }

    public async Task<CreatedEducationResponse> AddAsync(CreateEducationRequest createEducationRequest)
    {
        var education = _mapper.Map<Education>(createEducationRequest);
        var createEducation = await _educationDal.AddAsync(education);
        return _mapper.Map<CreatedEducationResponse>(createEducation);
    }

    public async Task<DeletedEducationResponse> DeleteAsync(DeleteEducationRequest deleteEducationRequest)
    {
        var education = await _educationDal.GetAsync(c => c.Id == deleteEducationRequest.Id);
        var deleteEducation = await _educationDal.DeleteAsync(education);
        return _mapper.Map<DeletedEducationResponse>(deleteEducation);
    }

    public async Task<GetEducationResponse> GetById(GetEducationRequest getEducationRequest)
    {
        var getEducation = await _educationDal.GetAsync(c => c.Id == getEducationRequest.Id);
        return _mapper.Map<GetEducationResponse>(getEducation);
    }

    public async Task<IPaginate<GetListedEducationResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _educationDal.GetListAsync(include: p => p.Include(p => p.User), index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedEducationResponse>>(getList);
    }

    public async Task<UpdatedEducationResponse> UpdateAsync(UpdateEducationRequest updateEducationRequest)
    {
        var education = _mapper.Map<Education>(updateEducationRequest);
        var updatedEducation = await _educationDal.UpdateAsync(education);
        return _mapper.Map<UpdatedEducationResponse>(updatedEducation);
    }
}