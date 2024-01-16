﻿using Core.Entities;

namespace Entities;

public class Instructor : Entity<Guid>
{
    public Guid? UserId { get; set;}

    public User? User { get; set;}
    public List<Session>? Sessions { get; set;}
}
