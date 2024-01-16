using AutoMapper;
using Business.Abstracts;
using Business.Dtos.LiveCourse.Requests;
using Business.Dtos.LiveCourse.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class LiveCourseManager : ILiveCourseService
{
    private ILiveCourseDal _liveCourseDal;
    private IMapper _mapper;

    public LiveCourseManager(ILiveCourseDal liveCourseDal, IMapper mapper)
    {
        _liveCourseDal = liveCourseDal;
        _mapper = mapper;
    }

    public async Task<CreatedLiveCourseResponse> AddAsync(CreateLiveCourseRequest createLiveCourseRequest)
    {
        var liveCourse = _mapper.Map<LiveCourse>(createLiveCourseRequest);
        var createLiveCourse = await _liveCourseDal.AddAsync(liveCourse);
        return _mapper.Map<CreatedLiveCourseResponse>(createLiveCourse);
    }

    public async Task<DeletedLiveCourseResponse> DeleteAsync(DeleteLiveCourseRequest deleteLiveCourseRequest)
    {
        var liveCourse = await _liveCourseDal.GetAsync(c => c.Id == deleteLiveCourseRequest.Id);
        var deleteLiveCourse = await _liveCourseDal.DeleteAsync(liveCourse);
        return _mapper.Map<DeletedLiveCourseResponse>(deleteLiveCourse);
    }

    public async Task<GetLiveCourseResponse> GetById(GetLiveCourseRequest getLiveCourseRequest)
    {
        var getLiveCourse = await _liveCourseDal.GetAsync(c => c.Id == getLiveCourseRequest.Id);
        return _mapper.Map<GetLiveCourseResponse>(getLiveCourse);
    }

    public async Task<IPaginate<GetListedLiveCourseResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _liveCourseDal.GetListAsync(include: p => p.Include(p => p.CourseDetail), index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedLiveCourseResponse>>(getList);
    }

    public async Task<UpdatedLiveCourseResponse> UpdateAsync(UpdateLiveCourseRequest updateLiveCourseRequest)
    {
        var liveCourse = _mapper.Map<LiveCourse>(updateLiveCourseRequest);
        var updatedLiveCourse = await _liveCourseDal.UpdateAsync(liveCourse);
        return _mapper.Map<UpdatedLiveCourseResponse>(updatedLiveCourse);
    }
}