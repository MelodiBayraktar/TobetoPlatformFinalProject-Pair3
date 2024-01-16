using AutoMapper;
using Business.Abstracts;
using Business.Dtos.AsyncLessonsOfContent.Requests;
using Business.Dtos.AsyncLessonsOfContent.Responses;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AsyncLessonsOfContentManager : IAsyncLessonsOfContentService
{
    private IAsyncLessonsOfContentDal _asyncLessonsOfContentDal;
    private IMapper _mapper;

    public AsyncLessonsOfContentManager(IAsyncLessonsOfContentDal asyncLessonsOfContentDal, IMapper mapper)
    {
        _asyncLessonsOfContentDal = asyncLessonsOfContentDal;
        _mapper = mapper;
    }

    public async Task<CreatedAsyncLessonsOfContentResponse> AddAsync(CreateAsyncLessonsOfContentRequest createAsyncLessonsOfContentRequest)
    {
        var asyncLessonsOfContent = _mapper.Map<AsyncLessonsOfContent>(createAsyncLessonsOfContentRequest);
        var createAsyncLessonsOfContent = await _asyncLessonsOfContentDal.AddAsync(asyncLessonsOfContent);
        return _mapper.Map<CreatedAsyncLessonsOfContentResponse>(createAsyncLessonsOfContent);
    }

    public async Task<DeletedAsyncLessonsOfContentResponse> DeleteAsync(DeleteAsyncLessonsOfContentRequest deleteAsyncLessonsOfContentRequest)
    {
        var asyncLessonsOfContent = await _asyncLessonsOfContentDal.GetAsync(c => c.Id == deleteAsyncLessonsOfContentRequest.Id);
        var deleteAsyncLessonsOfContent = await _asyncLessonsOfContentDal.DeleteAsync(asyncLessonsOfContent);
        return _mapper.Map<DeletedAsyncLessonsOfContentResponse>(deleteAsyncLessonsOfContent);
    }

    public async Task<GetAsyncLessonsOfContentResponse> GetById(GetAsyncLessonsOfContentRequest getAsyncLessonsOfContentRequest)
    {
        var getAsyncLessonsOfContent = await _asyncLessonsOfContentDal.GetAsync(c => c.Id == getAsyncLessonsOfContentRequest.Id);
        return _mapper.Map<GetAsyncLessonsOfContentResponse>(getAsyncLessonsOfContent);
    }

    public async Task<IPaginate<GetListedAsyncLessonsOfContentResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _asyncLessonsOfContentDal.GetListAsync(include: p => p.Include(p => p.AsyncContent), index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedAsyncLessonsOfContentResponse>>(getList);
    }

    public async Task<UpdatedAsyncLessonsOfContentResponse> UpdateAsync(UpdateAsyncLessonsOfContentRequest updateAsyncLessonsOfContentRequest)
    {
        var asyncLessonsOfContent = _mapper.Map<AsyncLessonsOfContent>(updateAsyncLessonsOfContentRequest);
        var updatedAsyncLessonsOfContent = await _asyncLessonsOfContentDal.UpdateAsync(asyncLessonsOfContent);
        return _mapper.Map<UpdatedAsyncLessonsOfContentResponse>(updatedAsyncLessonsOfContent);
    }
}