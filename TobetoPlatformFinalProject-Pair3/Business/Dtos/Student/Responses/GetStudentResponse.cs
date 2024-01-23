using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Student.Responses
{
    public class GetStudentResponse
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
    }
}
