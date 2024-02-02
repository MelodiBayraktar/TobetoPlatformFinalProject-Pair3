﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Course.Responses
{
    public class DeletedCourseResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
