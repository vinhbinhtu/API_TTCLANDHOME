using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KOG.Intergration.Entity.Models
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        [StringLength(50)]
        public string? FullName { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        public int RoleId { get; set; }

        [JsonIgnore]
        public string? PasswordHash { get; set; }

    }
}