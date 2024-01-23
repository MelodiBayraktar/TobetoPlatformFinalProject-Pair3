using AutoMapper;
using Business.Abstracts;
using Business.Dtos.PasswordReset.Requests;
using Business.Dtos.PasswordReset.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using DataAccess.Abstracts;
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

    [ValidationAspect(typeof(PasswordResetUpdateValidator))]
    public async Task<UpdatedPasswordResetResponse> UpdateAsync(UpdatePasswordResetRequest updatePasswordResetRequest)
    {
        var passwordReset = _mapper.Map<PasswordReset>(updatePasswordResetRequest);
        var updatedPasswordReset = await _passwordResetDal.UpdateAsync(passwordReset);
        return _mapper.Map<UpdatedPasswordResetResponse>(updatedPasswordReset);
    }
}