using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.BusinessRules;

public class StudentBusinessRules
{
    IStudentDal _studentDal;

    public StudentBusinessRules(IStudentDal studentDal)
    {
        _studentDal = studentDal;
    }

    public Task StudentShouldExistWhenSelected(Student student)
    {
        if (student == null)
            throw new BusinessException(StudentMessages.StudentNotExists);
        return Task.CompletedTask;
    }
}