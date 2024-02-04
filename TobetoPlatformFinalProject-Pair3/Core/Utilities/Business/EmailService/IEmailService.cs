using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concretes;

namespace Core.Utilities.Business.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDto emailDtoRequest);
    }
}
