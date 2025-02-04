using Microsoft.AspNetCore.Identity;

namespace Skema_WebAPI.Models
{
    public class User : IdentityUser
    {
        public required string FullName { get; set; }
    }
}
