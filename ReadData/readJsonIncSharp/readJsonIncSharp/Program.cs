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
            HangSanXuat :'Motorola',	
          LoaiDienThoai :'Thông minh',	
          TenDienThoai :'Motorola Moto X4',	
          CongNgheManHinh :'IPS LCD',	
          DoPhanGiai :'Full HD (1080 x 1920 pixels)',	
          ManHinhRong :'5.2',	
          MatKinhCamUng :'Kính cường lực Gorilla Glass 3',	
          DoPhanGiaiCameraSau : ['12',' 8'],
          Quayphim :'Quay phim 4K 2160p@30fps',	
          DenFlash :'Có',	
          ChupAnhNangCao : ['Chụp ảnh xóa phông',' Tự động lấy nét',' Chạm lấy nét',' Nhận diện khuôn mặt',' HDR',' Panorama'],
          DoPhanGiaiCameraTruoc :'16 MP',	
          Videocall :'Có',	
          TinhNangCameraTruoc : ['Camera góc rộng',' Đèn Flash trợ sáng',' Tự động lấy nét',' Nhận diện khuôn mặt',' Chế độ làm đẹp'],
          HeDieuHanh :'Android 7.1 (Nougat)',	
          Chipset :'Qualcomm Snapdragon 630 8 nhân',	
          TocDoCPU :'2.2 GHz',	
          ChipDoHoa :'Adreno 508',	
          RAM :'4',	
          BoNhoTrong :'64',	
          BoNhoConLai :'45',	
          TheNhoNgoai :'MicroSD, hỗ trợ tối đa 256 ',	
          MangDiDong : ['3G',' 4G LTE Cat 6'],
          SIM :'2',	
          Wifi : ['Wi-Fi 802.11 a/b/g/n/ac',' Dual-band',' DLNA',' Wi-Fi Direct',' Wi-Fi hotspot'],
          GPS : ['A-GPS',' GLONASS'],
          Bluetooth : ['v5.0',' apt-X',' A2DP',' LE'],
          CongKetNoi_Sac :'USB Type-C',	
          JackTaiNghe :'3.5 mm',	
          KetNoiKhac : ['NFC',' OTG'],
          ThietKe : ['Nguyên khối'],
          ChatLieu : ['Khung kim loại + mặt kính cường lực'],
          KichThuoc :'Dài 148.4 mm - Ngang 73.4 mm - Dày 8 mm',	
          TrongLuong :'163 g',	
          DungLuongPin :'3000',	
          LoaiPin :'Pin chuẩn Li-Ion',	
          CongNghePin : ['Sạc pin nhanh',' Tiết kiệm pin'],
          BaoMatNangCao : ['Mở khóa bằng vân tay'],
          TinhNangDacBiet : ['Kháng nước',' kháng bụi'],
          GhiAm : ['Có',' microphone chuyên dụng chống ồn'],
          Radio :'Có',	
          XemPim : ['H.265',' 3GP',' MP4',' AVI',' WMV',' H.263'],
          NgheNhac : ['Midi',' Lossless',' MP3',' WAV',' WMA',' WMA9',' AAC',' AAC+',' AAC++',' eAAC+'],
          ThoiDiemRaMat :'8/1/2017',	
          MauSac : ['Xanh Dương',' Đen'],
          Gia :'8990000'		
                }";
            //SmartPhone m = JsonHelper.ToClass<SmartPhone>(json);
            //Type myType = typeof(SmartPhone);
            //foreach (string a in m.TinhNangDacBiet)
            //{
            //    Console.WriteLine(a);
            //}
            //Console.WriteLine(m.BoNhoConLai);

            //Rules m = JsonHelper.ToClass<Rules>(json);
            //Type myType = typeof(SmartPhone);
            //foreach (string a in m.GiaThiet)
            //{
            //    Console.WriteLine(a);
            //}

            SmartPhone[] PhoneArr = new SmartPhone[172];
            XDocument doc = XDocument.Load(@"D:\courses_2016-2017\Nam 3\Kì 2\Cơ sở tri thức\đồ án\SmartPhoneData.json");
            int index = 0;
            foreach (var element in doc.Root.Elements())
            {
                String jsonString = element.Value.ToString();
                jsonString = jsonString.Trim();
                jsonString = jsonString.Insert(0, "{");
                jsonString = jsonString.Insert(jsonString.Length, "}");
                //Console.WriteLine(jsonString);
                SmartPhone m = JsonHelper.ToClass<SmartPhone>(jsonString);
                PhoneArr[index] = m;
                index++;  
            }
            foreach (string a in PhoneArr[171].TinhNangDacBiet)
            {
                Console.WriteLine(a);
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
        //public class SmartPhone
        //{

        //    [JsonProperty("Name")]
        //    public string Name { get; set; }

        //    [JsonProperty("ReleaseDate")]
        //    public DateTime ReleaseDate { get; set; }

        //    [JsonProperty("Genres")]
        //    public string[] Genrese { get; set; }

        //}

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

        [JsonProperty("GiaThiet")]
        public string[] GiaThiet { get; set; }

        [JsonProperty("KetLuan")]
        public string[] KetLuan { get; set; }
    }
}
