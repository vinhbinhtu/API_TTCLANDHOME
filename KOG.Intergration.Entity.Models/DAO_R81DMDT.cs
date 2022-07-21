using System.ComponentModel.DataAnnotations;

namespace KOG.Intergration.Entity.Models
{
    public class DAO_R81DMDT
    {
        [Key]
        [StringLength(20)]
        public string? Ma_Dt { get; set; }

        [StringLength(200)]
        public string? Ten_Dt { get; set; }

        [StringLength(20)]
        public string? Ma_Nh_Dt { get; set; }

        [StringLength(20)]
        public string? Dia_Chi { get; set; }

        [StringLength(50)]
        public string? So_Phone { get; set; }

        [StringLength(100)]
        public string? Ong_Ba { get; set; }

        [StringLength(50)]
        public string? Email { get; set; }

        [StringLength(20)]
        public string? Ma_Bp { get; set; }

        public DateTime? Ngay_Sinh { get; set; }

        [StringLength(20)]
        public string? San { get; set; }

        public int? SyncStatus { get; set; }

        [StringLength(200)]
        public string? CrmEntity { get; set; }

        public Guid? CrmEntityId { get; set; }
    }
}