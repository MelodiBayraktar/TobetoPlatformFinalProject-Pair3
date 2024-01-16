using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Instructor.Responses
{
    public class DeletedInstructorResponse
    {
        public Guid? Id { get; set;}
        public Guid? UserId { get; set;}
    }
}
