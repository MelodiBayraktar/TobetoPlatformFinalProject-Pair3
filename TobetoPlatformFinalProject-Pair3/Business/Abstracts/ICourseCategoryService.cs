using Business.Dtos.CourseCategory.Requests;
using Business.Dtos.CourseCategory.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ICourseCategoryService
{
    Task<IPaginate<GetListedCourseCategoryResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedCourseCategoryResponse> AddAsync(CreateCourseCategoryRequest createCourseCategoryRequest);
    Task<UpdatedCourseCategoryResponse> UpdateAsync(UpdateCourseCategoryRequest updateCourseCategoryRequest);
    Task<DeletedCourseCategoryResponse> DeleteAsync(DeleteCourseCategoryRequest deleteCourseCategoryRequest);
    Task<GetCourseCategoryResponse> GetById(GetCourseCategoryRequest getCourseCategoryRequest);
}