using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace PublishingBusinessManagement.Models;

public class User : IdentityUser
{
    public string Email { get; set; } = null!;
}
