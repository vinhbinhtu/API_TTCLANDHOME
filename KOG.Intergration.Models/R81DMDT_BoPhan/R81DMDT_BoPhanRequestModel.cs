using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KOG.Intergration.Models.R81DMDT_BoPhan
{
    public class R81DMDT_BoPhanRequestModel
    {
        [Required]
        public string? Ma_Dt { get; set; }

        [Required]
        public string? Ten_Dt { get; set; }

        [Required]
        public string? Ma_Nh_Dt { get; set; }

        [Required]
        public string? San { get; set; }

        [Required]
        public int? SyncStatus { get; set; }

    }
}
