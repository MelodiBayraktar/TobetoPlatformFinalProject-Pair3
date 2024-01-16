using AutoMapper;
using Business.Abstracts;
using Business.Dtos.CourseExam.Requests;
using Business.Dtos.CourseExam.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class CourseExamManager : ICourseExamService
{
    private ICourseExamDal _courseExamDal;
    private IMapper _mapper;

    public CourseExamManager(ICourseExamDal courseExamDal, IMapper mapper)
    {
        _courseExamDal = courseExamDal;
        _mapper = mapper;
    }

    public async Task<CreatedCourseExamResponse> AddAsync(CreateCourseExamRequest createCourseExamRequest)
    {
        var courseExam = _mapper.Map<CourseExam>(createCourseExamRequest);
        var createCourseExam = await _courseExamDal.AddAsync(courseExam);
        return _mapper.Map<CreatedCourseExamResponse>(createCourseExam);
    }

    public async Task<DeletedCourseExamResponse> DeleteAsync(DeleteCourseExamRequest deleteCourseExamRequest)
    {
        var courseExam = await _courseExamDal.GetAsync(c => c.Id == deleteCourseExamRequest.Id);
        var deleteCourseExam = await _courseExamDal.DeleteAsync(courseExam);
        return _mapper.Map<DeletedCourseExamResponse>(deleteCourseExam);
    }

    public async Task<GetCourseExamResponse> GetById(GetCourseExamRequest getCourseExamRequest)
    {
        var getCourseExam = await _courseExamDal.GetAsync(c => c.Id == getCourseExamRequest.Id);
        return _mapper.Map<GetCourseExamResponse>(getCourseExam);
    }

    public async Task<IPaginate<GetListedCourseExamResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _courseExamDal.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedCourseExamResponse>>(getList);
    }

    public async Task<UpdatedCourseExamResponse> UpdateAsync(UpdateCourseExamRequest updateCourseExamRequest)
    {
        var courseExam = _mapper.Map<CourseExam>(updateCourseExamRequest);
        var updatedCourseExam = await _courseExamDal.UpdateAsync(courseExam);
        return _mapper.Map<UpdatedCourseExamResponse>(updatedCourseExam);
    }
}