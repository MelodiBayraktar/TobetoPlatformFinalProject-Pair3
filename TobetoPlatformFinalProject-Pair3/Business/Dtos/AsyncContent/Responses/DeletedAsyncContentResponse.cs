using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.AsyncContent.Responses
{
    public class DeletedAsyncContentResponse
    {
        public Guid? Id { get; set; }
        public Guid? AsyncCourseId { get; set; }
        public string? Name { get; set; }
    }
}
