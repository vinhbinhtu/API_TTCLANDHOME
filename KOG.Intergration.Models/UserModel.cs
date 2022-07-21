using Microsoft.AspNet.Identity.EntityFramework;
using System.Text.Json.Serialization;

namespace KOG.Intergration.Models
{
    public class UserModel : IdentityUser
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? FullName { get; set; }

        public string Email { get; set; }

        public int RoleId { get; set; }

        [JsonIgnore]
        public string? PasswordHash { get; set; }
    }
}