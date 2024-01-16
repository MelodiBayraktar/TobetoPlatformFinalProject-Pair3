using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Certificate.Requests
{
    public class UpdateCertificateRequest
    {
        public Guid? Id { get; set;}
        public Guid? UserId { get; set;}
        public string? FilePath { get; set; }
        public string? FileType { get; set; }
        public DateTime? UploadDate { get; set; }
    }
}
