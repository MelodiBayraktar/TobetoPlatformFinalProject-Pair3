using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class InstructorManager : IInstructorService
{
    private IInstructorDal _instructorDal;
    private IMapper _mapper;

    public InstructorManager(IInstructorDal instructorDal, IMapper mapper)
    {
        _instructorDal = instructorDal;
        _mapper = mapper;
    }

    public async Task<CreatedInstructorResponse> AddAsync(CreateInstructorRequest createInstructorRequest)
    {
        var instructor = _mapper.Map<Instructor>(createInstructorRequest);
        var createInstructor = await _instructorDal.AddAsync(instructor);
        return _mapper.Map<CreatedInstructorResponse>(createInstructor);
    }

    public async Task<DeletedInstructorResponse> DeleteAsync(DeleteInstructorRequest deleteInstructorRequest)
    {
        var instructor = await _instructorDal.GetAsync(c => c.Id == deleteInstructorRequest.Id);
        var deleteInstructor = await _instructorDal.DeleteAsync(instructor);
        return _mapper.Map<DeletedInstructorResponse>(deleteInstructor);
    }

    public async Task<GetInstructorResponse> GetById(GetInstructorRequest getInstructorRequest)
    {
        var getInstructor = await _instructorDal.GetAsync(c => c.Id == getInstructorRequest.Id);
        return _mapper.Map<GetInstructorResponse>(getInstructor);
    }

    public async Task<IPaginate<GetListedInstructorResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _instructorDal.GetListAsync(include: p => p.Include(p => p.User), index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedInstructorResponse>>(getList);
    }

    public async Task<UpdatedInstructorResponse> UpdateAsync(UpdateInstructorRequest updateInstructorRequest)
    {
        var instructor = _mapper.Map<Instructor>(updateInstructorRequest);
        var updatedInstructor = await _instructorDal.UpdateAsync(instructor);
        return _mapper.Map<UpdatedInstructorResponse>(updatedInstructor);
    }
}