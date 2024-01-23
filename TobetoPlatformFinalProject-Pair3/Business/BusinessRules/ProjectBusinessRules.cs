using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.BusinessRules;

public class ProjectBusinessRules  : BaseBusinessRules
{
    IProjectDal _projectDal;

    public ProjectBusinessRules(IProjectDal projectDal)
    {
        _projectDal = projectDal;
    }

    public Task ProjectShouldExistWhenSelected(Project project)
    {
        if (project == null)
            throw new BusinessException(ProjectMessages.ProjectNotExists);
        return Task.CompletedTask;
    }
}