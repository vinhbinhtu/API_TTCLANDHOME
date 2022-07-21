using System.Text.Json.Serialization;

namespace KOG.Intergration.Models.R81DMDT_NhanVien
{
    public class R81DMDT_NhanVienRequestModel
    {
        public string? Ma_Dt { get; set; }

        public string? Ten_Dt { get; set; }

        public string? Ong_Ba { get; set; }

        public string? Dia_Chi { get; set; }

        public string? Ma_Bp { get; set; }

        public string? Ma_Nh_Dt { get; set; }

        public DateTime? Ngay_Sinh { get; set; }

        public string? So_Phone { get; set; }

        public string? Email { get; set; }

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
