using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOG.Intergration.Models
{
    [Keyless]
    [Table("c30seeds_phieudatcho")]
    public partial class PhieuDatCho
    {
        [Required]
        [StringLength(5)]
        public string Ma_Ct { get; set; }

        [Required]
        [StringLength(20)]
        public string Ma_Dt { get; set; }

        [Required]
        [StringLength(100)]
        public string Ong_Ba { get; set; }

        [Required]
        [StringLength(20)]
        public string Ma_DvCs { get; set; }

        public Decimal? TTien0 { get; set; }

        public int? SyncStatus { get; set; }
    }
}
