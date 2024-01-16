using AutoMapper;
using Business.Abstracts;
using Business.Dtos.AsyncContent.Requests;
using Business.Dtos.AsyncContent.Responses;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AsyncContentManager : IAsyncContentService
{
    private IAsyncContentDal _asyncContentDal;
    private IMapper _mapper;

    public AsyncContentManager(IAsyncContentDal asyncContentDal, IMapper mapper)
    {
        _asyncContentDal = asyncContentDal;
        _mapper = mapper;
    }

    public async Task<CreatedAsyncContentResponse> AddAsync(CreateAsyncContentRequest createAsyncContentRequest)
    {
        var asyncContent = _mapper.Map<AsyncContent>(createAsyncContentRequest);
        var createAsyncContent = await _asyncContentDal.AddAsync(asyncContent);
        return _mapper.Map<CreatedAsyncContentResponse>(createAsyncContent);
    }

    public async Task<DeletedAsyncContentResponse> DeleteAsync(DeleteAsyncContentRequest deleteAsyncContentRequest)
    {
        var asyncContent = await _asyncContentDal.GetAsync(c => c.Id == deleteAsyncContentRequest.Id);
        var deleteAsyncContent = await _asyncContentDal.DeleteAsync(asyncContent);
        return _mapper.Map<DeletedAsyncContentResponse>(deleteAsyncContent);
    }

    public async Task<GetAsyncContentResponse> GetById(GetAsyncContentRequest getAsyncContentRequest)
    {
        var getAsyncContent = await _asyncContentDal.GetAsync(c => c.Id == getAsyncContentRequest.Id);
        return _mapper.Map<GetAsyncContentResponse>(getAsyncContent);
    }

    public async Task<IPaginate<GetListedAsyncContentResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _asyncContentDal.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedAsyncContentResponse>>(getList);
    }

    public async Task<UpdatedAsyncContentResponse> UpdateAsync(UpdateAsyncContentRequest updateAsyncContentRequest)
    {
        var asyncContent = _mapper.Map<AsyncContent>(updateAsyncContentRequest);
        var updatedAsyncContent = await _asyncContentDal.UpdateAsync(asyncContent);
        return _mapper.Map<UpdatedAsyncContentResponse>(updatedAsyncContent);
    }
}