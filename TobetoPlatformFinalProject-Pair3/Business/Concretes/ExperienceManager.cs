using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Experience.Requests;
using Business.Dtos.Experience.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ExperienceManager : IExperienceService
{
    private IExperienceDal _experienceDal;
    private IMapper _mapper;

    public ExperienceManager(IExperienceDal experienceDal, IMapper mapper)
    {
        _experienceDal = experienceDal;
        _mapper = mapper;
    }

    public async Task<CreatedExperienceResponse> AddAsync(CreateExperienceRequest createExperienceRequest)
    {
        var experience = _mapper.Map<Experience>(createExperienceRequest);
        var createExperience = await _experienceDal.AddAsync(experience);
        return _mapper.Map<CreatedExperienceResponse>(createExperience);
    }

    public async Task<DeletedExperienceResponse> DeleteAsync(DeleteExperienceRequest deleteExperienceRequest)
    {
        var experience = await _experienceDal.GetAsync(c => c.Id == deleteExperienceRequest.Id);
        var deleteExperience = await _experienceDal.DeleteAsync(experience);
        return _mapper.Map<DeletedExperienceResponse>(deleteExperience);
    }

    public async Task<GetExperienceResponse> GetById(GetExperienceRequest getExperienceRequest)
    {
        var getExperience = await _experienceDal.GetAsync(c => c.Id == getExperienceRequest.Id);
        return _mapper.Map<GetExperienceResponse>(getExperience);
    }

    public async Task<IPaginate<GetListedExperienceResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _experienceDal.GetListAsync(include: p => p.Include(p => p.User), index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedExperienceResponse>>(getList);
    }

    public async Task<UpdatedExperienceResponse> UpdateAsync(UpdateExperienceRequest updateExperienceRequest)
    {
        var experience = _mapper.Map<Experience>(updateExperienceRequest);
        var updatedExperience = await _experienceDal.UpdateAsync(experience);
        return _mapper.Map<UpdatedExperienceResponse>(updatedExperience);
    }
}