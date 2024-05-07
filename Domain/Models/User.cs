﻿using Microsoft.AspNetCore.Identity;

namespace Domain.Models;

public class User:IdentityUser<int>
{
    public ICollection<UserRole> Roles { get; set; }
}