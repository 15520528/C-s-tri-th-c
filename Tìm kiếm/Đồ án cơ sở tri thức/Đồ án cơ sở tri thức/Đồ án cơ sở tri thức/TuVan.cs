using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Đồ_án_cơ_sở_tri_thức.KnowledgeBase;

namespace Đồ_án_cơ_sở_tri_thức
{
    public partial class TuVan : UserControl
    {
        List<String> GiaThiet;//lưu giữ tập sự kiện ban đầu mà người dùng nhập vào
        List<String> Known; //Tập sự kiện đã biết, lưu giữ các sự kiện được sinh ra trong quá trình suy diễn tiến 
        Dictionary<List<String>, List<String>> RuleSet;//Lưu giữ tập luật, ứng với giả thiết và kết luận
        Dictionary<List<String>, List<String>> PhoneRuleSet;//Lưu giữ tập luật, ứng với giả thiết và kết luận
        HashSet<String> PhoneList;//danh sách tên các điện thoại từ các sự kiện ban đầu
        // Delegate declaration (Khai báo hàm sự kiện gửi danh sách điện thoại được click tới form My App)
        public delegate void ClickTo(HashSet<String> PhoneList);
        // Event declaration
        public event ClickTo PassParameters;
        String CurrenFolderPath;
        String TuoiNguoiDungGT;
        String ThuNhapNguoiDungGT;
        String SoGioDungDienThoai;
        String Game2D;
        String Game3D;
        String MangDiDong;
        String Wifi;
        String DoPhanGiaiThap;
        String DoPhanGiaTrungBinh;
        String DoPhanGiaCao;
        String XemPhimWeb;
        String XemPhimDienThoai;
        String ChatLuongNhac;
        String ChatLuongAnh;
        String SoLuonSim;
        String KhangNuocKhangBui;
        String Cham2LanSang;
        String SacPin;
        String Touch;
        public TuVan()
        {
            InitializeComponent();
        }

        private void TuVan_Load(object sender, EventArgs e)
        {
            GiaThiet = new List<string>();
            RuleSet = new Dictionary<List<String>, List<String>>();
            PhoneRuleSet = new Dictionary<List<String>, List<String>>();
            //khởi tạo giá trị tuổi cho dropdown
            for (int i = 1; i < 150; i++)
            {
                bunifuDropdown1.AddItem(i.ToString());
            }

            //đọc các luật suy diễn trung gian từ file
            //đọc các luật suy diễn ra điện thoại từ file
            readRules();
        }

        public void readRules()
        {
            //đọc luật trung gian
            {
                CurrenFolderPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Knowledge base\";
                XDocument doc = XDocument.Load(CurrenFolderPath + "Tập luật.Json");
                foreach (var element in doc.Root.Elements())
                {
                    String ruleString = element.Value;
                    ruleString = ruleString.Trim();
                    //ruleString = "GT : ['NguoiSudung.TinhCach(HuongNoi)','NguoiSudung.NhuCau(ChoiGame)'],KL: ['DanhGiaDienThoai.CauHinh(Manh)', 'DanhGiaDienThoai.TocDoKetNoiMang(Nhanh)', 'NguoiSudung.ThoiGianSuDung(RatNhieu)'] ";
                    ruleString = "{" + ruleString + "}";
                    Rules m = JsonHelper.ToClass<Rules>(ruleString);
                    List<String> GT = new List<string>();
                    List<String> KL = new List<string>();
                    //Console.WriteLine(ruleString);
                    foreach (String gt in m.GiaThiet)
                    {
                        GT.Add(gt);
                    }
                    foreach (String kl in m.KetLuan)
                    {
                        KL.Add(kl);
                    }
                    RuleSet.Add(GT, KL);
                }
            }
            //đọc luật suy ra điện thoại
            {
                CurrenFolderPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Knowledge base\";
                XDocument doc = XDocument.Load(CurrenFolderPath + "Luật suy ra điện thoại.txt");
                foreach (var element in doc.Root.Elements())
                {
                    String ruleString = element.Value;
                    ruleString = ruleString.Trim();
                    //ruleString = "GT : ['NguoiSudung.TinhCach(HuongNoi)','NguoiSudung.NhuCau(ChoiGame)'],KL: ['DanhGiaDienThoai.CauHinh(Manh)', 'DanhGiaDienThoai.TocDoKetNoiMang(Nhanh)', 'NguoiSudung.ThoiGianSuDung(RatNhieu)'] ";
                    ruleString = "{" + ruleString + "}";
                    Rules m = JsonHelper.ToClass<Rules>(ruleString);
                    List<String> GT = new List<string>();
                    List<String> KL = new List<string>();
                    //Console.WriteLine(ruleString);
                    foreach (String gt in m.GiaThiet)
                    {
                        GT.Add(gt);
                    }
                    foreach (String kl in m.KetLuan)
                    {
                        KL.Add(kl);
                    }
                    PhoneRuleSet.Add(GT, KL);
                }
            }
            //foreach (KeyValuePair<List<String>, List<String>> rule in PhoneRuleSet)
            //{
            //    Console.WriteLine("[" + string.Join("AND", rule.Key.ToArray()) + "]" + " THEN " + string.Join("AND", rule.Value.ToArray()) + "\n\n");
            //}
        }

        //Hàm suy diễn tiến từ sự kiện ban đầu
        public void forwardInference()
        {
            {
                bool found = true;
                List<int> AddedRules = new List<int>();
                while (found)
                {
                    found = false;
                    int i = 1;
                    foreach (KeyValuePair<List<String>, List<String>> rule in RuleSet)
                    {
                        if (rule.Key.All(elem => Known.Contains(elem)) && !AddedRules.Contains(i))
                        {
                            Console.WriteLine(string.Join(",", rule.Key.ToArray()));
                            Known.AddRange(rule.Value);
                            found = true;
                            AddedRules.Add(i);//đánh dấu đã xét qua luật
                        }
                        i++;
                    }
                }
            }
            Known.RemoveAll(EndsWithSpace);
            //Gọi hàm suy ra danh sách điện thoại từ tập sự kiện thu được
            //MessageBox.Show(string.Join("\n", Known.ToArray()));
            PhoneInference();      
        }

        //Hàm suy ra danh sách điện thoại từ các sự kiện cuối cùng được suy ra
        public void PhoneInference()
        {
            List<String> X = new List<string>();
            PhoneList = new HashSet<string>();
            foreach (KeyValuePair<List<String>, List<String>> rule in PhoneRuleSet)
            {
                if (rule.Key.All(elem => Known.Contains(elem)))
                {
                    Console.WriteLine(string.Join(",", rule.Key.ToArray()));
                    foreach (string phoneName in rule.Value) {
                        PhoneList.Add(phoneName);
                    }
                    X.AddRange(rule.Key);
                }
            }
            //MessageBox.Show(string.Join("\n", X.ToArray()));
        }

        private static bool EndsWithSpace(String s)
        {
            return s == "";
        }

        //Tiến hành tư vấn cho User
        private void button1_Click(object sender, EventArgs e)
        {
            GiaThiet.Clear();
            GiaThiet.Add(TuoiNguoiDungGT);
            GiaThiet.Add(ThuNhapNguoiDungGT);
            GiaThiet.Add(SoGioDungDienThoai);
            GiaThiet.Add(Game2D);
            GiaThiet.Add(Game3D);
            GiaThiet.Add(MangDiDong);
            GiaThiet.Add(Wifi);
            GiaThiet.Add(DoPhanGiaiThap);
            GiaThiet.Add(DoPhanGiaTrungBinh);
            GiaThiet.Add(DoPhanGiaCao);
            GiaThiet.Add(XemPhimWeb);
            GiaThiet.Add(XemPhimDienThoai);
            GiaThiet.Add(ChatLuongNhac);
            GiaThiet.Add(ChatLuongAnh);
            GiaThiet.Add(SoLuonSim);
            GiaThiet.Add(KhangNuocKhangBui);
            GiaThiet.Add(Cham2LanSang);
            GiaThiet.Add(SacPin);
            GiaThiet.Add(Touch);
            Known = GiaThiet;
            forwardInference();
            if (PassParameters != null)
            {
                PassParameters(PhoneList);
            }
            //MessageBox.Show(string.Join(",", GiaThiet));
        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            if (int.Parse(bunifuDropdown1.selectedValue) >= 6 && int.Parse(bunifuDropdown1.selectedValue) <= 12)
            {
                TuoiNguoiDungGT = "NguoiSuDung.Tuoi(6-12)";
            }
            else if (int.Parse(bunifuDropdown1.selectedValue) >= 13 && int.Parse(bunifuDropdown1.selectedValue) <= 19)
            {
                TuoiNguoiDungGT = "NguoiSuDung.Tuoi(13-19)";
            }
            else if (int.Parse(bunifuDropdown1.selectedValue) >= 20 && int.Parse(bunifuDropdown1.selectedValue) <= 34)
            {
                TuoiNguoiDungGT = "NguoiSuDung.Tuoi(20-35)";
            }
            else if (int.Parse(bunifuDropdown1.selectedValue) >= 35 && int.Parse(bunifuDropdown1.selectedValue) <= 60)
            {
                TuoiNguoiDungGT = "NguoiSuDung.Tuoi(35-60)";
            }
            else if (int.Parse(bunifuDropdown1.selectedValue) > 60)
            {
                TuoiNguoiDungGT = "NguoiSuDung.Tuoi(>60)";
            }
            else
            {
                TuoiNguoiDungGT = "";
            }
        }

        private void bunifuDropdown3_onItemSelected(object sender, EventArgs e)
        {
            if(bunifuDropdown3.selectedIndex == 0)
            {
                ThuNhapNguoiDungGT = "NguoiDung.ThuNhapCaNhan(0-5)";
            }
            else if (bunifuDropdown3.selectedIndex == 1)
            {
                ThuNhapNguoiDungGT = "NguoiDung.ThuNhapCaNhan(5-15)";
            }
            else if (bunifuDropdown3.selectedIndex == 2)
            {
                ThuNhapNguoiDungGT = "NguoiDung.ThuNhapCaNhan(15-25)";
            }
            else if (bunifuDropdown3.selectedIndex == 3)
            {
                ThuNhapNguoiDungGT = "NguoiDung.ThuNhapCaNhan(25-50)";
            }
            else if (bunifuDropdown3.selectedIndex == 4)
            {
                ThuNhapNguoiDungGT = "NguoiDung.ThuNhapCaNhan(>50)";
            }
            else
            {
                ThuNhapNguoiDungGT = "";
            }
        }

        private void bunifuDropdown2_onItemSelected(object sender, EventArgs e)
        {
            if (bunifuDropdown2.selectedIndex==0)
            {
                SoGioDungDienThoai = "NguoiSuDung.ThoiGianSuDung(0-2)";
            }
            else if (bunifuDropdown2.selectedIndex == 1)
            {
                SoGioDungDienThoai = "NguoiSuDung.ThoiGianSuDung(2-4)";
            }
            else if (bunifuDropdown2.selectedIndex == 2)
            {
                SoGioDungDienThoai = "NguoiSuDung.ThoiGianSuDung(4-6)";
            }
            else if (bunifuDropdown2.selectedIndex == 3)
            {
                SoGioDungDienThoai = "NguoiSuDung.ThoiGianSuDung(>6)";
            }
            else
            {
                SoGioDungDienThoai = "";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Game2D = "";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                MangDiDong = "NguoiDung.KetNoiInternet(MangDiDong)";
            }
            else
            {
                MangDiDong = "";
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                Wifi = "NguoiDung.KetNoiInternet(Wifi)";
            }
            else
            {
                Wifi = "";
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                DoPhanGiaiThap = "NguoiDung.DoPhanGiaiThuongXem(144p-480p)";
            }
            else
            {
                DoPhanGiaiThap = "";
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                DoPhanGiaTrungBinh = "NguoiDung.DoPhanGiaiThuongXem(720p-1080p)";
            }
            else
            {
                DoPhanGiaTrungBinh = "";
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                DoPhanGiaCao = "NguoiDung.DoPhanGiaiThuongXem(2k-4k)";
            }
            else
            {
                DoPhanGiaCao = "";
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                XemPhimWeb = "NguoiDung.XemViDeo(Web)";
            }
            else
            {
                XemPhimWeb = "";
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                XemPhimDienThoai = "NguoiDung.XemViDeo(TrongDienThoai)";
            }
            else
            {
                XemPhimDienThoai = "";
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                ChatLuongNhac = "NguoiDung.ThichChatLuongNhac(Cao";
            }
            else
            {
                ChatLuongNhac = "";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                ChatLuongNhac = "NguoiDung.ThichChatLuongNhac(TrungBinh)";
            }
            else
            {
                ChatLuongNhac = "";
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                ChatLuongNhac = "NguoiDung.ThichChatLuongNhac(Thap)";
            }
            else
            {
                ChatLuongNhac = "";
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                ChatLuongAnh = "NguoiDung.ThichChatLuongAnh(Cao)";
            }
            else
            {
                ChatLuongAnh = "";
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
            {
                ChatLuongAnh = "NguoiDung.ThichChatLuongAnh(TrungBinh)";
            }
            else
            {
                ChatLuongAnh = "";
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                ChatLuongAnh = "NguoiDung.ThichChatLuongAnh(Thap)";
            }
            else
            {
                ChatLuongAnh = "";
            }
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked)
            {
                SoLuonSim = "NguoiDung.ThichSoSim(1)";
            }
            else
            {
                SoLuonSim = "";
            }
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton11.Checked)
            {
                SoLuonSim = "NguoiDung.ThichSoSim(2)";
            }
            else
            {
                SoLuonSim = "";
            } 
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox12.Checked)
            {
                KhangNuocKhangBui = "DienThoai.TinhNangDacBiet(KhangNuoc,KhangBui)";
            }
            else
            {
                KhangNuocKhangBui = "";
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                Cham2LanSang = "DienThoai.TinhNangDacBiet(Cham 2 Lan Sang Man Hinh)";
            }
            else
            {
                Cham2LanSang = "";
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked)
            {
                SacPin = "DienThoai.TinhNangDacBiet(Sac Pin Cho Thiet Bi Khac)";
            }
            else
            {
                SacPin = "";
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                Touch = "DienThoai.TinhNangDacBiet(3D Touch)";
            }
            else
            {
                Touch = "";
            }
        }
    }
}
