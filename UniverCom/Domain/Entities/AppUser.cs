using Microsoft.AspNetCore.Identity;

namespace UniverCom.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Secondname { get; set; }

        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}