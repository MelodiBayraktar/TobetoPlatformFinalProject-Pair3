﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Application.Responses
{
    public class CreatedApplicationResponse
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string ApplicationForStatus { get; set; }
        public string DocumentUploadForStatus { get; set; }
        public bool ApplicationStatus { get; set; }
    }
}
