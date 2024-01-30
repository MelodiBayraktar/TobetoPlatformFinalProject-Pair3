using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Ability.Responses;
using Business.Dtos.Certificate.Requests;
using Business.Dtos.Certificate.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.GetUserId;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class CertificateManager : ICertificateService
{
    private ICertificateDal _certificateDal;
    private IMapper _mapper;
    private IGetUserId _getUserId;

    public CertificateManager(ICertificateDal certificateDal, IMapper mapper, IGetUserId getUserId)
    {
        _certificateDal = certificateDal;
        _mapper = mapper;
        _getUserId = getUserId;
    }
    [SecuredOperation("certificates.add,admin,mod")]
    [ValidationAspect(typeof(CertificateRequestValidator))]
    public async Task<CreatedCertificateResponse> AddAsync(CreateCertificateRequest createCertificateRequest)
    {
        Certificate certificate = _mapper.Map<Certificate>(createCertificateRequest);
        Guid userId = _getUserId.GetUserIdFromHttpContext();
        certificate.UserId = userId;
        Expression<Func<Certificate, object>> includeExpressionForUser = x => x.User;
        var createCertificate = await _certificateDal.AddAsync(certificate, includeExpressionForUser);
        CreatedCertificateResponse response = _mapper.Map<CreatedCertificateResponse>(createCertificate);
        return response;
    }

    public async Task<DeletedCertificateResponse> DeleteAsync(DeleteCertificateRequest deleteCertificateRequest)
    {
        Certificate certificate = await _certificateDal.GetAsync(c => c.Id == deleteCertificateRequest.Id);
        await _certificateDal.DeleteAsync(certificate);
        DeletedCertificateResponse response =  _mapper.Map<DeletedCertificateResponse>(certificate);
        return response;
    }

    public async Task<GetCertificateResponse> GetById(GetCertificateRequest getCertificateRequest)
    {
        Certificate getCertificate = await _certificateDal.GetAsync(c => c.Id == getCertificateRequest.Id);
        GetCertificateResponse response = _mapper.Map<GetCertificateResponse>(getCertificate);
        return response;
    }

    public async Task<IPaginate<GetListedCertificateResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _certificateDal.GetListAsync(include: p => p.Include(p => p.User), index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedCertificateResponse> response = _mapper.Map<Paginate<GetListedCertificateResponse>>(getList);
        return response;
    }

    public async Task<UpdatedCertificateResponse> UpdateAsync(UpdateCertificateRequest updateCertificateRequest)
    {
        var result = await _certificateDal.GetAsync(predicate: a => a.Id == updateCertificateRequest.Id);
        _mapper.Map(updateCertificateRequest, result);
        await _certificateDal.UpdateAsync(result);
        UpdatedCertificateResponse response = _mapper.Map<UpdatedCertificateResponse>(result);
        return response;
    }
}