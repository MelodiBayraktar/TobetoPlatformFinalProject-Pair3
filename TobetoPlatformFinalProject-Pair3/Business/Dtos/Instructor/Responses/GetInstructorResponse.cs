﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Instructor.Responses
{
    public class GetInstructorResponse
    {
        public Guid Id { get; set;}
        public Guid UserId { get; set;}
        public string UserName { get; set; }
    }
}
