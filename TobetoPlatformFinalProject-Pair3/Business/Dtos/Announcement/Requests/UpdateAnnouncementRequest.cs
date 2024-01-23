﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Announcement.Requests
{
    public class UpdateAnnouncementRequest
    {
        public Guid Id { get; set; }
        public Guid AnnouncementsNewsCategoryId { get; set; }
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string AnnouncementContent { get; set; }
    }
}
