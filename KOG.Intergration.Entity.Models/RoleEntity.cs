using System.ComponentModel.DataAnnotations;

namespace KOG.Intergration.Entity.Models
{
    public class RoleEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string RoleName { get; set; }

    }
}