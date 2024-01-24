using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Student.Responses;
using Business.Dtos.Survey.Requests;
using Business.Dtos.Survey.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class SurveyManager : ISurveyService
{
    private ISurveyDal _surveyDal;
    private IMapper _mapper;

    public SurveyManager(ISurveyDal surveyDal, IMapper mapper)
    {
        _surveyDal = surveyDal;
        _mapper = mapper;
    }
    [SecuredOperation("surveys.add,admin")]
    [ValidationAspect(typeof(SurveyRequestValidator))]
    public async Task<CreatedSurveyResponse> AddAsync(CreateSurveyRequest createSurveyRequest)
    {
        // var survey = _mapper.Map<Survey>(createSurveyRequest);
        // var createSurvey = await _surveyDal.AddAsync(survey);
        // return _mapper.Map<CreatedSurveyResponse>(createSurvey);
        var survey = _mapper.Map<Survey>(createSurveyRequest);
        Expression<Func<Survey, object>> includeExpressionForStudent = x => x.Student;

        var createSurvey = await _surveyDal.AddAsync(survey, includeExpressionForStudent);
        return _mapper.Map<CreatedSurveyResponse>(createSurvey);
    }
    [SecuredOperation("surveys.delete,admin")]
    public async Task<DeletedSurveyResponse> DeleteAsync(DeleteSurveyRequest deleteSurveyRequest)
    {
        var survey = await _surveyDal.GetAsync(c => c.Id == deleteSurveyRequest.Id);
        var deleteSurvey = await _surveyDal.DeleteAsync(survey);
        return _mapper.Map<DeletedSurveyResponse>(deleteSurvey);
    }

    public async Task<GetSurveyResponse> GetById(GetSurveyRequest getSurveyRequest)
    {
        var getSurvey = await _surveyDal.GetAsync(c => c.Id == getSurveyRequest.Id);
        return _mapper.Map<GetSurveyResponse>(getSurvey);
    }

    public async Task<IPaginate<GetListedSurveyResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _surveyDal.GetListAsync(include: p => p.Include(p => p.Student),index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedSurveyResponse>>(getList);
    }
    [SecuredOperation("surveys.update,admin")]
    public async Task<UpdatedSurveyResponse> UpdateAsync(UpdateSurveyRequest updateSurveyRequest)
    {
        var survey = _mapper.Map<Survey>(updateSurveyRequest);
        var updatedSurvey = await _surveyDal.UpdateAsync(survey);
        return _mapper.Map<UpdatedSurveyResponse>(updatedSurvey);
    }
}