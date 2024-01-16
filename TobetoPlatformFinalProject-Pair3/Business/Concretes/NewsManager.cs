using AutoMapper;
using Business.Abstracts;
using Business.Dtos.News.Requests;
using Business.Dtos.News.Responses;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
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

    public async Task<CreatedNewsResponse> AddAsync(CreateNewsRequest createNewsRequest)
    {
        var news = _mapper.Map<News>(createNewsRequest);
        var createNews = await _newsDal.AddAsync(news);
        return _mapper.Map<CreatedNewsResponse>(createNews);
    }

    public async Task<DeletedNewsResponse> DeleteAsync(DeleteNewsRequest deleteNewsRequest)
    {
        var news = await _newsDal.GetAsync(c => c.Id == deleteNewsRequest.Id);
        var deleteNews = await _newsDal.DeleteAsync(news);
        return _mapper.Map<DeletedNewsResponse>(deleteNews);
    }

    public async Task<GetNewsResponse> GetById(GetNewsRequest getNewsRequest)
    {
        var getNews = await _newsDal.GetAsync(c => c.Id == getNewsRequest.Id);
        return _mapper.Map<GetNewsResponse>(getNews);
    }

    public async Task<IPaginate<GetListedNewsResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _newsDal.GetListAsync(include: p => p.Include(p => p.Project).Include(p => p.AnnouncementsNewsCategory), index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedNewsResponse>>(getList);
    }

    public async Task<UpdatedNewsResponse> UpdateAsync(UpdateNewsRequest updateNewsRequest)
    {
        var news = _mapper.Map<News>(updateNewsRequest);
        var updatedNews = await _newsDal.UpdateAsync(news);
        return _mapper.Map<UpdatedNewsResponse>(updatedNews);
    }
}