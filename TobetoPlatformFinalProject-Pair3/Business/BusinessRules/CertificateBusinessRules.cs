using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class CertificateBusinessRules : BaseBusinessRules
    {
        ICertificateDal _certificateDal;

        public CertificateBusinessRules(ICertificateDal certificateDal)
        {
            _certificateDal = certificateDal;
        }

        public Task CertificateShouldExistWhenSelected(Certificate? application)
        {
            if (application == null)
                throw new BusinessException(CertificateMessages.CertificateNotExists);
            return Task.CompletedTask;
        }

        public async Task CertificateIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
        {
            Certificate? certificate = await _certificateDal.GetAsync(
                predicate: at => at.Id == id,
                enableTracking: false,
                cancellationToken: cancellationToken
            );
            await CertificateShouldExistWhenSelected(certificate);
        }
    }
}
