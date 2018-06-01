using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Reflection;
namespace readJsonIncSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = @"{
            GT:['NguoiSuDung.NhuCau(LuotWebMangXaHoi)'],
		    KL:['DanhGiaDienThoai.TocDoKetNoiMang(TrungBinh)']		
                }";
            //SmartPhone m = JsonHelper.ToClass<SmartPhone>(json);
            //Type myType = typeof(SmartPhone);
            //foreach (string a in m.TinhNangDacBiet)
            //{
            //    Console.WriteLine(a);
            //}
            //Console.WriteLine(m.BoNhoConLai);

            //Rules m = JsonHelper.ToClass<Rules>(json);
            //Type myType = typeof(Rules);
            //foreach (string a in m.GiaThiet)
            //{
            //    Console.WriteLine(a);
            //}

            //SmartPhone[] PhoneArr = new SmartPhone[172];
            //XDocument doc = XDocument.Load(@"D:\courses_2016-2017\Nam 3\Kì 2\Cơ sở tri thức\đồ án\SmartPhoneData.json");
            //int index = 0;
            //foreach (var element in doc.Root.Elements())
            //{
            //    String jsonString = element.Value.ToString();
            //    jsonString = jsonString.Trim();
            //    jsonString = jsonString.Insert(0, "{");
            //    jsonString = jsonString.Insert(jsonString.Length, "}");
            //    //Console.WriteLine(jsonString);
            //    SmartPhone m = JsonHelper.ToClass<SmartPhone>(jsonString);
            //    PhoneArr[index] = m;
            //    index++;  
            //}
            //foreach (string a in PhoneArr[100].TinhNangDacBiet)
            //{
            //    Console.WriteLine(a);
            //}

            XDocument doc = XDocument.Load(@"C:\Users\nhoxe\OneDrive\Documents\GitHub\C-s-tri-th-c\Rules.txt");
            foreach (var element in doc.Root.Elements())
            {
                Console.WriteLine("{0} ", element.Value);
            }
        }
        public void giaiMoRam(String Khoang)
            {
                switch (Khoang) {
                    case "DungLuongThap":

                        break;
                    case "DungLuongTrungBinh":

                        break;
                    case "DungLuongHoiCao":

                        break;
                    case "DungLuongCao":

                        break;
                }

            }
    }
        public static class JsonHelper
        {
            public static string FromClass<T>(T data, bool isEmptyToNull = false,
                                              JsonSerializerSettings jsonSettings = null)
            {
                string response = string.Empty;

                if (!EqualityComparer<T>.Default.Equals(data, default(T)))
                    response = JsonConvert.SerializeObject(data, jsonSettings);

                return isEmptyToNull ? (response == "{}" ? "null" : response) : response;
            }

            public static T ToClass<T>(string data, JsonSerializerSettings jsonSettings = null)
            {
                var response = default(T);

                if (!string.IsNullOrEmpty(data))
                    response = jsonSettings == null
                        ? JsonConvert.DeserializeObject<T>(data)
                        : JsonConvert.DeserializeObject<T>(data, jsonSettings);

                return response;
            }
        }

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

        [JsonProperty("XemPhim")]
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

    public class Rules
    {

        [JsonProperty("GT")]
        public string[] GiaThiet { get; set; }

        [JsonProperty("KL")]
        public string[] KetLuan { get; set; }
    }
}
