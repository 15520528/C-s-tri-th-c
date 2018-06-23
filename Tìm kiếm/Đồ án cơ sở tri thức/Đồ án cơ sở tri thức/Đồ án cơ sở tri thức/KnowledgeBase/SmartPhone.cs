using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Đồ_án_cơ_sở_tri_thức.KnowledgeBase
{
    public class SmartPhone
    {
        [JsonProperty("HangSanXuat")]
        public string HangSanXuat { get; set; }
        [JsonProperty("LoaiDienThoai")]
        public string LoaiDienThoai { get; set; }

        [JsonProperty("TenDienThoai")]
        public string TenDienThoai { get; set; }

        [JsonProperty("CongNgheManHinh")]
        public string CongNgheManHinh { get; set; }

        [JsonProperty("DoPhanGiai")]
        public string DoPhanGiai { get; set; }

        [JsonProperty("ManHinhRong")]
        public string ManHinhRong { get; set; }

        [JsonProperty("MatKinhCamUng")]
        public string MatKinhCamUng { get; set; }

        [JsonProperty("DoPhanGiaiCameraSau")]
        public string[] DoPhanGiaiCameraSau { get; set; }

        [JsonProperty("Quayphim")]
        public string Quayphim { get; set; }

        [JsonProperty("DenFlash")]
        public string DenFlash { get; set; }

        [JsonProperty("ChupAnhNangCao")]
        public string[] ChupAnhNangCao { get; set; }

        [JsonProperty("DoPhanGiaiCameraTruoc")]
        public string DoPhanGiaiCameraTruoc { get; set; }

        [JsonProperty("Videocall")]
        public string Videocall { get; set; }

        [JsonProperty("TinhNangCameraTruoc")]
        public string[] TinhNangCameraTruoc { get; set; }

        [JsonProperty("HeDieuHanh")]
        public string HeDieuHanh { get; set; }

        [JsonProperty("Chipset")]
        public string Chipset { get; set; }

        [JsonProperty("TocDoCPU")]
        public string TocDoCPU { get; set; }

        [JsonProperty("ChipDoHoa")]
        public string ChipDoHoa { get; set; }

        [JsonProperty("Ram")]
        public string Ram { get; set; }

        [JsonProperty("BoNhoTrong")]
        public string BoNhoTrong { get; set; }

        [JsonProperty("BoNhoConLai")]
        public string BoNhoConLai { get; set; }

        [JsonProperty("TheNhoNgoai")]
        public string TheNhoNgoai { get; set; }

        [JsonProperty("MangDiDong")]
        public string[] MangDiDong { get; set; }

        [JsonProperty("Sim")]
        public string Sim { get; set; }

        [JsonProperty("Wifi")]
        public string[] Wifi { get; set; }

        [JsonProperty("GPS")]
        public string[] GPS { get; set; }

        [JsonProperty("Bluetooth")]
        public string[] Bluetooth { get; set; }

        [JsonProperty("CongKetNoi_Sac")]
        public string CongKetNoi_Sac { get; set; }

        [JsonProperty("JackTaiNghe")]
        public string JackTaiNghe { get; set; }

        [JsonProperty("KetNoiKhac")]
        public string[] KetNoiKhac { get; set; }

        [JsonProperty("ThietKe")]
        public string[] ThietKe { get; set; }

        [JsonProperty("ChatLieu")]
        public string[] ChatLieu { get; set; }

        [JsonProperty("KichThuoc")]
        public string KichThuoc { get; set; }

        [JsonProperty("TrongLuong")]
        public string TrongLuong { get; set; }

        [JsonProperty("DungLuongPin")]
        public string DungLuongPin { get; set; }

        [JsonProperty("LoaiPin")]
        public string LoaiPin { get; set; }

        [JsonProperty("CongNghePin")]
        public string[] CongNghePin { get; set; }

        [JsonProperty("BaoMatNangCao")]
        public string[] BaoMatNangCao { get; set; }

        [JsonProperty("TinhNangDacBiet")]
        public string[] TinhNangDacBiet { get; set; }

        [JsonProperty("GhiAm")]
        public string[] GhiAm { get; set; }

        [JsonProperty("Radio")]
        public string Radio { get; set; }

        [JsonProperty("XemPim")]
        public string[] XemPhim { get; set; }

        [JsonProperty("NgheNhac")]
        public string[] NgheNhac { get; set; }

        [JsonProperty("ThoiDiemRaMat")]
        public string ThoiDiemRaMat { get; set; }

        [JsonProperty("MauSac")]
        public string[] MauSac { get; set; }

        [JsonProperty("Gia")]
        public string Gia { get; set; }
    }
}
