﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Settings.Responses
{
    public class DeletedSettingsResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
