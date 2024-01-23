﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.ForeignLanguage.Responses
{
    public class GetForeignLanguageResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LanguageLevel { get; set; }
    }
}
