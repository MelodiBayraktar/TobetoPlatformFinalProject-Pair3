using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Certificate.Requests;
using Business.Dtos.Certificate.Responses;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class CertificateManager : ICertificateService
{
    private ICertificateDal _certificateDal;
    private IMapper _mapper;

    public CertificateManager(ICertificateDal certificateDal, IMapper mapper)
    {
        _certificateDal = certificateDal;
        _mapper = mapper;
    }

    public async Task<CreatedCertificateResponse> AddAsync(CreateCertificateRequest createCertificateRequest)
    {
        var certificate = _mapper.Map<Certificate>(createCertificateRequest);
        var createCertificate = await _certificateDal.AddAsync(certificate);
        return _mapper.Map<CreatedCertificateResponse>(createCertificate);
    }

    public async Task<DeletedCertificateResponse> DeleteAsync(DeleteCertificateRequest deleteCertificateRequest)
    {
        var certificate = await _certificateDal.GetAsync(c => c.Id == deleteCertificateRequest.Id);
        var deleteCertificate = await _certificateDal.DeleteAsync(certificate);
        return _mapper.Map<DeletedCertificateResponse>(deleteCertificate);
    }

    public async Task<GetCertificateResponse> GetById(GetCertificateRequest getCertificateRequest)
    {
        var getCertificate = await _certificateDal.GetAsync(c => c.Id == getCertificateRequest.Id);
        return _mapper.Map<GetCertificateResponse>(getCertificate);
    }

    public async Task<IPaginate<GetListedCertificateResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _certificateDal.GetListAsync(include: p => p.Include(p => p.User), index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedCertificateResponse>>(getList);
    }

    public async Task<UpdatedCertificateResponse> UpdateAsync(UpdateCertificateRequest updateCertificateRequest)
    {
        var certificate = _mapper.Map<Certificate>(updateCertificateRequest);
        var updatedCertificate = await _certificateDal.UpdateAsync(certificate);
        return _mapper.Map<UpdatedCertificateResponse>(updatedCertificate);
    }
}