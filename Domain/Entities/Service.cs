﻿using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Service : Entity
{
    public int? UserId { get; set; }
    public int? EmendatorAdminId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Tag { get; set; }
    public string ImgUrl { get; set; }
    public bool State { get; set; }

    public virtual ExtendedUser User { get; set; }
}