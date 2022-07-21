using System.Text.Json.Serialization;

namespace KOG.Intergration.Models.R81DMDT_BoPhan
{
    public class R81DMDT_BoPhanResponseModel
    {
        public string? Ma_Dt { get; set; }

        public string? Ten_Dt { get; set; }

        public string? Ma_Nh_Dt { get; set; }

        public string? San { get; set; }

        public int? SyncStatus { get; set; }

        [JsonIgnore]
        public DateTime? CreateDateTime { get; set; }

        [JsonIgnore]
        public string? CreateBy { get; set; }

        [JsonIgnore]
        public DateTime? ModifyDateTime { get; set; }

        [JsonIgnore]
        public string? ModifyBy { get; set; }

    }
}
