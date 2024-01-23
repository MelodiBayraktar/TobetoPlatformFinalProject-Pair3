﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Survey.Responses
{
    public class UpdatedSurveyResponse
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
