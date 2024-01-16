using AutoMapper;
using Business.Abstracts;
using Business.Dtos.AsyncLessonsDetail.Requests;
using Business.Dtos.AsyncLessonsDetail.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AsyncLessonsDetailManager : IAsyncLessonsDetailService
{
    private IAsyncLessonsDetailDal _asyncLessonsDetailDal;
    private IMapper _mapper;

    public AsyncLessonsDetailManager(IAsyncLessonsDetailDal asyncLessonsDetailDal, IMapper mapper)
    {
        _asyncLessonsDetailDal = asyncLessonsDetailDal;
        _mapper = mapper;
    }

    public async Task<CreatedAsyncLessonsDetailResponse> AddAsync(CreateAsyncLessonsDetailRequest createAsyncLessonsDetailRequest)
    {
        var asyncLessonsDetail = _mapper.Map<AsyncLessonsDetail>(createAsyncLessonsDetailRequest);
        var createAsyncLessonsDetail = await _asyncLessonsDetailDal.AddAsync(asyncLessonsDetail);
        return _mapper.Map<CreatedAsyncLessonsDetailResponse>(createAsyncLessonsDetail);
    }

    public async Task<DeletedAsyncLessonsDetailResponse> DeleteAsync(DeleteAsyncLessonsDetailRequest deleteAsyncLessonsDetailRequest)
    {
        var asyncLessonsDetail = await _asyncLessonsDetailDal.GetAsync(c => c.Id == deleteAsyncLessonsDetailRequest.Id);
        var deleteAsyncLessonsDetail = await _asyncLessonsDetailDal.DeleteAsync(asyncLessonsDetail);
        return _mapper.Map<DeletedAsyncLessonsDetailResponse>(deleteAsyncLessonsDetail);
    }

    public async Task<GetAsyncLessonsDetailResponse> GetById(GetAsyncLessonsDetailRequest getAsyncLessonsDetailRequest)
    {
        var getAsyncLessonsDetail = await _asyncLessonsDetailDal.GetAsync(c => c.Id == getAsyncLessonsDetailRequest.Id);
        return _mapper.Map<GetAsyncLessonsDetailResponse>(getAsyncLessonsDetail);
    }

    public async Task<IPaginate<GetListedAsyncLessonsDetailResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _asyncLessonsDetailDal.GetListAsync(include: p => p.Include(p => p.AsyncLessonsOfContent), index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedAsyncLessonsDetailResponse>>(getList);
    }

    public async Task<UpdatedAsyncLessonsDetailResponse> UpdateAsync(UpdateAsyncLessonsDetailRequest updateAsyncLessonsDetailRequest)
    {
        var asyncLessonsDetail = _mapper.Map<AsyncLessonsDetail>(updateAsyncLessonsDetailRequest);
        var updatedAsyncLessonsDetail = await _asyncLessonsDetailDal.UpdateAsync(asyncLessonsDetail);
        return _mapper.Map<UpdatedAsyncLessonsDetailResponse>(updatedAsyncLessonsDetail);
    }
}