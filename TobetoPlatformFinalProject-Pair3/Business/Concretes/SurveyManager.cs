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
        Survey survey = _mapper.Map<Survey>(createSurveyRequest);
        Expression<Func<Survey, object>> includeExpressionForStudent = x => x.Student;
        var createSurvey = await _surveyDal.AddAsync(survey, includeExpressionForStudent);
        CreatedSurveyResponse response = _mapper.Map<CreatedSurveyResponse>(createSurvey);
        return response;
    }

    [SecuredOperation("surveys.delete,admin")]
    public async Task<DeletedSurveyResponse> DeleteAsync(DeleteSurveyRequest deleteSurveyRequest)
    {
        Survey survey = await _surveyDal.GetAsync(c => c.Id == deleteSurveyRequest.Id);
        var deleteSurvey = await _surveyDal.DeleteAsync(survey);
        DeletedSurveyResponse response = _mapper.Map<DeletedSurveyResponse>(deleteSurvey);
        return response;
    }

    public async Task<GetSurveyResponse> GetById(GetSurveyRequest getSurveyRequest)
    {
        Survey getSurvey = await _surveyDal.GetAsync(c => c.Id == getSurveyRequest.Id);
        GetSurveyResponse response = _mapper.Map<GetSurveyResponse>(getSurvey);
        return response;
    }

    public async Task<IPaginate<GetListedSurveyResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _surveyDal.GetListAsync(include: p => p.Include(p => p.Student),index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedSurveyResponse> response = _mapper.Map<Paginate<GetListedSurveyResponse>>(getList);
        return response;
    }

    [SecuredOperation("surveys.update,admin")]
    public async Task<UpdatedSurveyResponse> UpdateAsync(UpdateSurveyRequest updateSurveyRequest)
    {
        var result = await _surveyDal.GetAsync(predicate: a => a.Id == updateSurveyRequest.Id);
        _mapper.Map(updateSurveyRequest, result);
        await _surveyDal.UpdateAsync(result);
        UpdatedSurveyResponse response = _mapper.Map<UpdatedSurveyResponse>(result);
        return response;
    }
}