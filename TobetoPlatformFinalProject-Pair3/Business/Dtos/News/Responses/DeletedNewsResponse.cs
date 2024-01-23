using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.News.Responses
{
    public class DeletedNewsResponse
    {
        public Guid Id { get; set; }
        public Guid AnnouncementsNewsCategoryId { get; set; }
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string NewsContent { get; set; }
    }
}
