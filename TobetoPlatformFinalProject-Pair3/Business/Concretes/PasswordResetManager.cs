using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Business.Dtos.PasswordReset.Requests;
using Business.Dtos.PasswordReset.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.GetUserId;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities;
using Entities.Concretes;

namespace Business.Concretes;

public class PasswordResetManager : IPasswordResetService
{
    private IPasswordResetDal _passwordResetDal;
    private IMapper _mapper;

    public PasswordResetManager(IPasswordResetDal passwordResetDal, IMapper mapper)
    {
        _passwordResetDal = passwordResetDal;
        _mapper = mapper;
    }

    //public async Task<CreatedPasswordResetResponse> AddAsync(CreatePasswordResetRequest createPasswordResetRequest)
    //{
    //    var passwordReset = _mapper.Map<PasswordReset>(createPasswordResetRequest);
    //    var createPasswordReset = await _passwordResetDal.AddAsync(passwordReset);
    //    return _mapper.Map<CreatedPasswordResetResponse>(createPasswordReset);
    //}

    //public async Task<DeletedPasswordResetResponse> DeleteAsync(DeletePasswordResetRequest deletePasswordResetRequest)
    //{
    //    var passwordReset = await _passwordResetDal.GetAsync(c => c.Id == deletePasswordResetRequest.Id);
    //    var deletePasswordReset = await _passwordResetDal.DeleteAsync(passwordReset);
    //    return _mapper.Map<DeletedPasswordResetResponse>(deletePasswordReset);
    //}

    //public async Task<GetPasswordResetResponse> GetById(GetPasswordResetRequest getPasswordResetRequest)
    //{
    //    var getPasswordReset = await _passwordResetDal.GetAsync(c => c.Id == getPasswordResetRequest.Id);
    //    return _mapper.Map<GetPasswordResetResponse>(getPasswordReset);
    //}

    //public async Task<IPaginate<GetListedPasswordResetResponse>> GetListAsync(PageRequest pageRequest)
    //{
    //    var getList = await _passwordResetDal.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);
    //    return _mapper.Map<Paginate<GetListedPasswordResetResponse>>(getList);
    //}

    [SecuredOperation("passwordResets.update,admin")]
    [ValidationAspect(typeof(PasswordResetRequestValidator))]
    public async Task<UpdatedPasswordResetResponse> UpdateAsync(UpdatePasswordResetRequest updatePasswordResetRequest)
    {
        var result = await _passwordResetDal.GetAsync(predicate: a => a.Id == updatePasswordResetRequest.Id);
        _mapper.Map(updatePasswordResetRequest, result);
        await _passwordResetDal.UpdateAsync(result);
        UpdatedPasswordResetResponse response = _mapper.Map<UpdatedPasswordResetResponse>(result);
        return response;
    }
}