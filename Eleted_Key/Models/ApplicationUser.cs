using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public override string UserName { get; set; }
}

