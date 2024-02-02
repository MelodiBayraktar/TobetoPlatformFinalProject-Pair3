using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Announcement.Responses;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Business.Dtos.News.Requests;
using Business.Dtos.News.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class NewsManager : INewsService
{
    private INewsDal _newsDal;
    private IMapper _mapper;

    public NewsManager(INewsDal newsDal, IMapper mapper)
    {
        _newsDal = newsDal;
        _mapper = mapper;
    }

    [SecuredOperation("news.add,admin")]
    [ValidationAspect(typeof(NewsRequestValidator))]
    public async Task<CreatedNewsResponse> AddAsync(CreateNewsRequest createNewsRequest)
    {
        News news = _mapper.Map<News>(createNewsRequest);
        Expression<Func<News, object>> includeExpressionForProject = x => x.Project;
        Expression<Func<News, object>> includeExpressionForAnnouncementsNewsCategory = y => y.AnnouncementsNewsCategory;
        var createNews = await _newsDal.AddAsync(news, includeExpressionForProject,includeExpressionForAnnouncementsNewsCategory);
        CreatedNewsResponse response = _mapper.Map<CreatedNewsResponse>(createNews);
        return response;
    }

    [SecuredOperation("news.delete,admin")]
    public async Task<DeletedNewsResponse> DeleteAsync(DeleteNewsRequest deleteNewsRequest)
    {
        News news = await _newsDal.GetAsync(c => c.Id == deleteNewsRequest.Id);
        var deleteNews = await _newsDal.DeleteAsync(news);
        DeletedNewsResponse response = _mapper.Map<DeletedNewsResponse>(deleteNews);
        return response;
    }

    public async Task<GetNewsResponse> GetById(GetNewsRequest getNewsRequest)
    {
        News getNews = await _newsDal.GetAsync(c => c.Id == getNewsRequest.Id,
            include: p => p.Include(p => p.Project).Include(p => p.AnnouncementsNewsCategory));
        GetNewsResponse response = _mapper.Map<GetNewsResponse>(getNews);
        return response;
    }

    public async Task<IPaginate<GetListedNewsResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _newsDal.GetListAsync(include: p => p.Include(p => p.Project).Include(p => p.AnnouncementsNewsCategory), index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedNewsResponse> response = _mapper.Map<Paginate<GetListedNewsResponse>>(getList);
        return response;
    }

    [SecuredOperation("news.update,admin")]
    public async Task<UpdatedNewsResponse> UpdateAsync(UpdateNewsRequest updateNewsRequest)
    {
        var result = await _newsDal.GetAsync(predicate: a => a.Id == updateNewsRequest.Id);
        _mapper.Map(updateNewsRequest, result);
        await _newsDal.UpdateAsync(result);
        UpdatedNewsResponse response = _mapper.Map<UpdatedNewsResponse>(result);
        return response;
    }
}