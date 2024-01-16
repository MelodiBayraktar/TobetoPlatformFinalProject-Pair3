using Business.Dtos.Certificate.Requests;
using Business.Dtos.Certificate.Responses;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;

namespace Business.Abstracts;

public interface ICertificateService
{
    Task<IPaginate<GetListedCertificateResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedCertificateResponse> AddAsync(CreateCertificateRequest createCertificateRequest);
    Task<UpdatedCertificateResponse> UpdateAsync(UpdateCertificateRequest updateCertificateRequest);
    Task<DeletedCertificateResponse> DeleteAsync(DeleteCertificateRequest deleteCertificateRequest);
    Task<GetCertificateResponse> GetById(GetCertificateRequest getCertificateRequest);
}