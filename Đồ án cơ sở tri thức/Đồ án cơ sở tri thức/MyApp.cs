using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Đồ_án_cơ_sở_tri_thức.KnowledgeBase;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Xml;

namespace Đồ_án_cơ_sở_tri_thức
{
    public partial class MyApp : Form
    {
        BrandSelection brandSelection2 = new BrandSelection();
        List<String> GiaThiet;//lưu giữ tập sự kiện ban đầu
        List<String> Known; //Tập sự kiện đã biết
        Dictionary<List<String>, List<String>> RuleSet = new Dictionary<List<String>, List<String>>();//Lưu giữ tập luật, ứng với giả thiết và kết luận
        List<SmartPhone> PhoneList = new List<SmartPhone>();
        String PhonePicturePath;
        String CurrenFolderPath ;

        public MyApp()
        {
            InitializeComponent();
        }

        private void MyApp_Load(object sender, EventArgs e)
        {

            PhonePicturePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) +@"\hinh\";
            Console.WriteLine(PhonePicturePath);
            //Khởi tạo giao diện lọc điện thoại theo hãng
            brandSelection2.Visible = false;
            phone1.BringToFront();
            brandSelection2.PassParameters += new BrandSelection.ClickTo(PhoneFilterClick);
            tuVan1.PassParameters += new TuVan.ClickTo(PhoneInterenceResult);

            this.Controls.Add(brandSelection2);

            //đọc thông tin điện thoại
            this.LoadSmartPhoneInfo();

            //Show danh sách điện thoại ra màn hình
            this.ShowPhone(this.PhoneList);
        }

        //Hiển thị danh sách điện thoại 
        private void ShowPhone(List<SmartPhone> list)
        {
            int row = (list.Count / 3) + 1;
            int y = 0;
            int index = 0;
            for (int i = 0; i < row; i++)
            {
                int x = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (index <= list.Count - 1)
                    {
                        PhoneShow phone = new PhoneShow();
                        phone.Location = new Point(x, y);
                        phone.Controls["NameButton1"].Text = list[index].TenDienThoai;
                        phone.Controls["PriceButton1"].Text = list[index].Gia + " VNĐ";
                        phone.Controls["pictureBox1"].BackgroundImage = Image.FromFile(PhonePicturePath+ list[index].TenDienThoai +".PNG");
                        phone1.Controls.Add(phone);
                        x += 210;
                    }
                    index++;
                }
                y += 270;
            }
        }

        //show điện thoại từ kết quả tư vấn 
        protected void PhoneInterenceResult(HashSet<String> InferenceList)
        {
            List<String> list = InferenceList.ToList();
            //MessageBox.Show(string.Join(",", InferenceList));
            int row = (list.Count / 3) + 1;
            int y = 0;
            int Count = 0;
            for (int i = 0; i < row; i++)
            {
                int x = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (Count <= list.Count - 1)
                    {
                        int index = 0;
                        foreach (SmartPhone Phone in PhoneList)
                        {
                            if (Phone.TenDienThoai == list[Count])
                            {
                                break;
                            }
                            index++;
                        }
                        PhoneShow phone = new PhoneShow();
                        phone.Location = new Point(x, y);
                        phone.Controls["NameButton1"].Text = PhoneList[index].TenDienThoai;
                        phone.Controls["PriceButton1"].Text = PhoneList[index].Gia + " VNĐ";
                        phone.Controls["pictureBox1"].BackgroundImage = Image.FromFile(PhonePicturePath + PhoneList[index].TenDienThoai + ".PNG");
                        phone2.Controls.Add(phone);
                        x += 210;
                    }
                    Count++;
                }
                y += 270;
            }
            phone2.Visible = true;
            phone2.BringToFront();
        }

        //Show điện thoại ra giao diện với danh sách các hãng được check
        protected void PhoneFilterClick(List<String> CheckedPhoneList)
        {
            //MessageBox.Show(string.Join("\n",CheckedPhoneList));
            //lấy danh sách các điện thoại thuộc hãng chứa trong CheckedPhoneList
            List<String> list = new List<String>();
            foreach(SmartPhone phone in this.PhoneList) {
                if (CheckedPhoneList.Contains(phone.HangSanXuat))
                {
                    list.Add(phone.TenDienThoai);
                }
            }
            //Show các điện thoại được lọc ra giao diện
            this.PhoneFilter(list);
        }

        private void PhoneFilter(List<String> list)
        {
            foreach (Control phone in phone1.Controls)
            {
                phone.Visible = false;
            }
            int row = (list.Count / 3) + 1;
            int y = 0;
            int index = 0;
            for (int i = 0; i < row; i++)
            {
                int x = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (index <= list.Count - 1)
                    {
                        phone1.Controls[index].Location = new Point(x, y);
                        phone1.Controls[index].Controls["NameButton1"].Text = list[index];
                        phone1.Controls[index].Controls["pictureBox1"].BackgroundImage = Image.FromFile(PhonePicturePath + list[index] + ".PNG");
                        phone1.Controls[index].Visible = true;
                        //phone1.Controls[i].Controls["PriceButton1"].Text = list[index].Gia + " VNĐ";
                        x += 210;
                    }
                    index++;
                }
                y += 270;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tuVan1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            phone1.BringToFront();
        }

        //load thong tin dien thoai tu file cau truc
        private void LoadSmartPhoneInfo()
        {
            //CurrenFolderPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Knowledge base\";
            //XDocument doc = XDocument.Load(CurrenFolderPath + "SmartPhoneData.json");
            //foreach (var element in doc.Root.Elements())
            //{
            //    String jsonString = element.Value.ToString();
            //    jsonString = jsonString.Trim();
            //    jsonString = jsonString.Insert(0, "{");
            //    jsonString = jsonString.Insert(jsonString.Length, "}");
            //    SmartPhone phone = JsonHelper.ToClass<SmartPhone>(jsonString);
            //    //Console.WriteLine(phone.DoPhanGiai);
            //    PhoneList.Add(phone);
            //}
            String[] Str;
            String jsonString = "{";
            CurrenFolderPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Knowledge base\";
            using (XmlReader reader = XmlReader.Create(CurrenFolderPath + "Cấu trúc hệ tư vấn mua điện thoại.owl"))
            while (reader.Read())
            {
                
                if (reader.IsStartElement())
                {
                   
                    switch (reader.Name.ToString())
                    {
                        case "TenDienThoai":
                                jsonString = "{";
                                String TenDienThoai = reader.ReadElementContentAsString();
                                jsonString += "TenDienThoai:" +"'"+ TenDienThoai + "',";
                            break;
                        case "HangSanXuat":
                            String HangSanXuat = reader.ReadElementContentAsString();
                                jsonString += "HangSanXuat:" + "'"+HangSanXuat + "',";
                                break;
                        case "LoaiDienThoai":
                            String LoaiDienThoai = reader.ReadElementContentAsString();
                                jsonString += "LoaiDienThoai:" +"'"+LoaiDienThoai + "',";
                                break;
                        case "CongNgheManHinh":
                            String CongNgheManHinh = reader.ReadElementContentAsString();
                                jsonString += "CongNgheManHinh:" +"'"+ CongNgheManHinh + "',";
                                break;
                        case "DoPhanGiai":
                            String DoPhanGiai = reader.ReadElementContentAsString();
                                jsonString += "DoPhanGiai:" +"'"+ DoPhanGiai + "',";
                                break;
                        case "ManHinhRong":
                            String ManHinhRong = reader.ReadElementContentAsString();
                                jsonString += "ManHinhRong:" +"'"+ ManHinhRong + "',";
                                break;
                        case "MatKinhCamUng":
                            String MatKinhCamUng = reader.ReadElementContentAsString();
                                jsonString += "MatKinhCamUng:" +"'"+ MatKinhCamUng + "',";
                                break;
                        case "DoPhanGiaiCameraSau":
                                Str = reader.ReadElementContentAsString().Split(',').ToArray();
                                for (int i = 0; i < Str.Length; i++)
                                {
                                    Str[i] = "'" + Str[i] + "'";
                                }
                                String DoPhanGiaiCameraSau = String.Join(",", Str).Insert(0, "[");
                                DoPhanGiaiCameraSau = DoPhanGiaiCameraSau.Insert(DoPhanGiaiCameraSau.Length, "]");
                                //Console.WriteLine(DoPhanGiaiCameraSau);
                                jsonString += "DoPhanGiaiCameraSau:" + DoPhanGiaiCameraSau + ",";
                                break;
                        case "Quayphim":
                            String Quayphim = reader.ReadElementContentAsString();
                                jsonString += "Quayphim:" +"'"+ Quayphim + "',";
                                break;
                        case "DenFlash":
                            String DenFlash = reader.ReadElementContentAsString();
                                jsonString += "DenFlash:" +"'"+ DenFlash + "',";
                                break;
                        case "ChupAnhNangCao":
                                Str = reader.ReadElementContentAsString().Split(',').ToArray();
                                for (int i = 0; i < Str.Length; i++)
                                {
                                    Str[i] = "'" + Str[i] + "'";
                                }
                                String ChupAnhNangCao = String.Join(",", Str).Insert(0, "[");
                                ChupAnhNangCao = ChupAnhNangCao.Insert(ChupAnhNangCao.Length, "]");
                                //Console.WriteLine(ChupAnhNangCao);
                                jsonString += "ChupAnhNangCao:" + ChupAnhNangCao + ",";
                                break;
                        case "DoPhanGiaiCameraTruoc":
                                String DoPhanGiaiCameraTruoc = reader.ReadElementContentAsString();
                                jsonString += "DoPhanGiaiCameraTruoc:" + "'" + DoPhanGiaiCameraTruoc + "',";
                                break;
                        case "Videocall":
                            String Videocall = reader.ReadElementContentAsString();
                                jsonString += "Videocall:" +"'"+ Videocall + "',";
                                break;
                        case "TinhNangCameraTruoc":
                                Str = reader.ReadElementContentAsString().Split(',').ToArray();
                                for (int i = 0; i < Str.Length; i++)
                                {
                                    Str[i] = "'" + Str[i] + "'";
                                }
                                String TinhNangCameraTruoc = String.Join(",", Str).Insert(0, "[");
                                TinhNangCameraTruoc = TinhNangCameraTruoc.Insert(TinhNangCameraTruoc.Length, "]");
                                //Console.WriteLine(TinhNangCameraTruoc);
                                jsonString += "TinhNangCameraTruoc:" + TinhNangCameraTruoc + ",";
                                break;
                        case "HeDieuHanh":
                            String HeDieuHanh = reader.ReadElementContentAsString();
                                jsonString += "HeDieuHanh:" +"'"+ HeDieuHanh + "',";
                                break;
                        case "Chipset":
                            String Chipset = reader.ReadElementContentAsString();
                                jsonString += "Chipset:" +"'"+ Chipset + "',";
                                break;
                        case "TocDoCPU":
                            String TocDoCPU = reader.ReadElementContentAsString();
                                jsonString += "TocDoCPU:" +"'"+ TocDoCPU + "',";
                                break;
                        case "ChipDoHoa":
                            String ChipDoHoa = reader.ReadElementContentAsString();
                                jsonString += "ChipDoHoa:" +"'"+ ChipDoHoa + "',";
                                break;
                        case "RAM":
                            String RAM = reader.ReadElementContentAsString();
                                jsonString += "RAM:" +"'" +RAM + "',";
                                break;
                        case "BoNhoTrong":
                            String BoNhoTrong = reader.ReadElementContentAsString();
                                jsonString += "BoNhoTrong:" + "'"+ BoNhoTrong + "',";
                                break;
                        case "BoNhoConLai":
                            String BoNhoConLai = reader.ReadElementContentAsString();
                                jsonString += "BoNhoConLai:" +"'"+ BoNhoConLai + "',";
                                break;
                        case "TheNhoNgoai":
                            String TheNhoNgoai = reader.ReadElementContentAsString();
                                jsonString += "TheNhoNgoai:" +"'"+ TheNhoNgoai + "',";
                                break;
                        case "MangDiDong":
                                Str = reader.ReadElementContentAsString().Split(',').ToArray();
                                for (int i = 0; i < Str.Length; i++)
                                {
                                    Str[i] = "'" + Str[i] + "'";
                                }
                                String MangDiDong = String.Join(",", Str).Insert(0, "[");
                                MangDiDong = MangDiDong.Insert(MangDiDong.Length, "]");
                                //Console.WriteLine(MangDiDong);
                                jsonString += "MangDiDong:" + MangDiDong + ",";
                                break;
                        case "SIM":
                            String SIM = reader.ReadElementContentAsString();
                                jsonString += "SIM:" +"'"+ SIM + "',";
                                break;
                        case "Wifi":
                                Str = reader.ReadElementContentAsString().Split(',').ToArray();
                                for (int i = 0; i < Str.Length; i++)
                                {
                                    Str[i] = "'" + Str[i] + "'";
                                }
                                String Wifi = String.Join(",", Str).Insert(0, "[");
                                Wifi = Wifi.Insert(Wifi.Length, "]");
                                //Console.WriteLine(Wifi);
                                jsonString += "Wifi:" + Wifi + ",";
                                break;
                        case "GPS":
                                Str = reader.ReadElementContentAsString().Split(',').ToArray();
                                for (int i = 0; i < Str.Length; i++)
                                {
                                    Str[i] = "'" + Str[i] + "'";
                                }
                                String GPS = String.Join(",", Str).Insert(0, "[");
                                GPS = GPS.Insert(GPS.Length, "]");
                                //Console.WriteLine(GPS);
                                jsonString += "GPS:" + GPS + ",";
                                break;
                        case "Bluetooth":
                                Str = reader.ReadElementContentAsString().Split(',').ToArray();
                                for (int i = 0; i < Str.Length; i++)
                                {
                                    Str[i] = "'" + Str[i] + "'";
                                }
                                String Bluetooth = String.Join(",", Str).Insert(0, "[");
                                Bluetooth = Bluetooth.Insert(Bluetooth.Length, "]");
                                //Console.WriteLine(Bluetooth);
                                jsonString += "Bluetooth:" + Bluetooth + ",";
                                break;
                        case "CongKetNoi_Sac":
                            String CongKetNoi_Sac = reader.ReadElementContentAsString();
                                jsonString += "CongKetNoi_Sac:" +"'"+ CongKetNoi_Sac + "',";
                                break;
                        case "JackTaiNghe":
                            String JackTaiNghe = reader.ReadElementContentAsString();
                                jsonString += "JackTaiNghe:" +"'"+ JackTaiNghe + "',";
                                break;
                        case "KetNoiKhac":
                                Str = reader.ReadElementContentAsString().Split(',').ToArray();
                                for (int i = 0; i < Str.Length; i++)
                                {
                                    Str[i] = "'" + Str[i] + "'";
                                }
                                String KetNoiKhac = String.Join(",", Str).Insert(0, "[");
                                KetNoiKhac = KetNoiKhac.Insert(KetNoiKhac.Length, "]");
                                //Console.WriteLine(KetNoiKhac);
                                jsonString += "KetNoiKhac:" + KetNoiKhac + ",";
                                break;
                        case "ThietKe":
                                Str = reader.ReadElementContentAsString().Split(',').ToArray();
                                for (int i = 0; i < Str.Length; i++)
                                {
                                    Str[i] = "'" + Str[i] + "'";
                                }
                                String ThietKe = String.Join(",", Str).Insert(0, "[");
                                ThietKe = ThietKe.Insert(ThietKe.Length, "]");
                                //Console.WriteLine(ThietKe);
                                jsonString += "ThietKe:" + ThietKe + ",";
                                break;
                        case "ChatLieu":
                                Str = reader.ReadElementContentAsString().Split(',').ToArray();
                                for (int i = 0; i < Str.Length; i++)
                                {
                                    Str[i] = "'" + Str[i] + "'";
                                }
                                String ChatLieu = String.Join(",", Str).Insert(0, "[");
                                ChatLieu = ChatLieu.Insert(ChatLieu.Length, "]");
                                //Console.WriteLine(ChatLieu);
                                jsonString += "ChatLieu:" + ChatLieu + ",";
                                break;
                        case "KichThuoc":
                            String KichThuoc = reader.ReadElementContentAsString();
                                jsonString += "KichThuoc:" +"'"+ KichThuoc + "',";
                                break;
                        case "TrongLuong":
                            String TrongLuong = reader.ReadElementContentAsString();
                                jsonString += "TrongLuong:" +"'"+ TrongLuong + "',";
                                break;
                        case "DungLuongPin":
                            String DungLuongPin = reader.ReadElementContentAsString();
                                jsonString += "DungLuongPin:" + "'"+ DungLuongPin + "',";
                                break;
                        case "LoaiPin":
                            String LoaiPin = reader.ReadElementContentAsString();
                                jsonString += "LoaiPin:" +"'"+ LoaiPin + "',";
                                break;
                        case "CongNghePin":
                                Str = reader.ReadElementContentAsString().Split(',').ToArray();
                                for (int i = 0; i < Str.Length; i++)
                                {
                                    Str[i] = "'" + Str[i] + "'";
                                }
                                String CongNghePin = String.Join(",", Str).Insert(0, "[");
                                CongNghePin = CongNghePin.Insert(CongNghePin.Length, "]");
                                //Console.WriteLine(CongNghePin);
                                jsonString += "CongNghePin:" + CongNghePin + ",";
                                break;
                        case "BaoMatNangCao":
                                Str = reader.ReadElementContentAsString().Split(',').ToArray();
                                for (int i = 0; i < Str.Length; i++)
                                {
                                    Str[i] = "'" + Str[i] + "'";
                                }
                                String BaoMatNangCao = String.Join(",", Str).Insert(0, "[");
                                BaoMatNangCao = BaoMatNangCao.Insert(BaoMatNangCao.Length, "]");
                                //Console.WriteLine(BaoMatNangCao);
                                jsonString += "BaoMatNangCao:" + BaoMatNangCao + ",";
                                break;
                        case "TinhNangDacBiet":
                                Str = reader.ReadElementContentAsString().Split(',').ToArray();
                                for (int i = 0; i < Str.Length; i++)
                                {
                                    Str[i] = "'" + Str[i] + "'";
                                }
                                String TinhNangDacBiet = String.Join(",", Str).Insert(0, "[");
                                TinhNangDacBiet = TinhNangDacBiet.Insert(TinhNangDacBiet.Length, "]");
                                //Console.WriteLine(TinhNangDacBiet);
                                jsonString += "TinhNangDacBiet:" + TinhNangDacBiet + ",";
                                break;
                        case "GhiAm":
                                Str = reader.ReadElementContentAsString().Split(',').ToArray();
                                for (int i = 0; i < Str.Length; i++)
                                {
                                    Str[i] = "'" + Str[i] + "'";
                                }
                                String GhiAm = String.Join(",", Str).Insert(0, "[");
                                GhiAm = GhiAm.Insert(GhiAm.Length, "]");
                                //Console.WriteLine(GhiAm);
                                jsonString += "XemPim:" + GhiAm + ",";
                                break;
                        case "Radio":
                            String Radio = reader.ReadElementContentAsString();
                                jsonString += "Radio:" + "'"+Radio + "',";
                                break;
                        case "XemPim":
                                Str = reader.ReadElementContentAsString().Split(',').ToArray();
                                for (int i = 0; i < Str.Length; i++)
                                {
                                    Str[i] = "'" + Str[i] + "'";
                                }
                                String XemPhim = String.Join(",", Str).Insert(0, "[");
                                XemPhim = XemPhim.Insert(XemPhim.Length, "]");
                                //Console.WriteLine(XemPhim);
                                jsonString += "XemPim:" + XemPhim + ",";
                                break;
                        case "NgheNhac":
                                Str = reader.ReadElementContentAsString().Split(',').ToArray();
                                for (int i = 0; i < Str.Length; i++)
                                {
                                    Str[i] = "'" + Str[i] + "'";
                                }
                                String NgheNhac = String.Join(",", Str).Insert(0, "[");
                                NgheNhac = NgheNhac.Insert(NgheNhac.Length, "]");
                                //Console.WriteLine(NgheNhac);
                                jsonString += "NgheNhac:" + NgheNhac + ",";
                                break;
                        case "ThoiDiemRaMat":
                            String ThoiDiemRaMat = reader.ReadElementContentAsString();
                                jsonString += "ThoiDiemRaMat:" +"'"+ ThoiDiemRaMat + "',";
                                break;
                        case "MauSac":
                                Str = reader.ReadElementContentAsString().Split(',').ToArray();
                                for(int i=0;i< Str.Length;i++)
                                {
                                    Str[i] = "'" + Str[i] + "'";
                                }
                                String MauSac = String.Join(",", Str).Insert(0, "[");
                                MauSac = MauSac.Insert(MauSac.Length, "]");
                                //Console.WriteLine(MauSac);
                                jsonString += "MauSac:" + MauSac + ",";
                                break;
                        case "Gia":
                            String Gia = reader.ReadElementContentAsString();
                                jsonString += "Gia:" + "'" + Gia +"'";
                                jsonString += "}";
                                Console.WriteLine(jsonString + "\n________________\n");
                                SmartPhone phone = JsonHelper.ToClass<SmartPhone>(jsonString);
                                PhoneList.Add(phone);
                                break;
                    }
                }         
            }
        }
        
        //hiện section lọc hãng sản phẩm
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (this.brandSelection2.Visible)
            {
                this.brandSelection2.Hide();
            }
            else
            {
                this.brandSelection2.Location = new Point(290, 46);
                this.brandSelection2.BringToFront();
                this.brandSelection2.Show();
            }
            //this.brandSelection1
        }

        //hiện section lọc hãng sản phẩm
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (this.brandSelection2.Visible)
            {
                this.brandSelection2.Hide();
            }
            else
            {
                this.brandSelection2.Location = new Point(290, 46);
                this.brandSelection2.BringToFront();
                this.brandSelection2.Show();
            }
        }

        //lọc điện thoại thuộc hãng apple
        private void NameButton1_Click(object sender, EventArgs e)
        {
            List<String> list = new List<string>();
            foreach (SmartPhone phone in this.PhoneList)
            {
                if (phone.HangSanXuat == "Apple")
                {
                    list.Add(phone.TenDienThoai);
                }
            }
            PhoneFilter(list);//tiền hành lọc
        }

        //lọc điện thoại thuộc hãng SamSung
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            List<String> list = new List<string>();
            foreach (SmartPhone phone in this.PhoneList)
            {
                if (phone.HangSanXuat == "Samsung")
                {
                    list.Add(phone.TenDienThoai);
                }
            }
            PhoneFilter(list);//tiền hành lọc
        }

        //lọc điện thoại thuộc hãng OPPO
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            List<String> list = new List<string>();
            foreach (SmartPhone phone in this.PhoneList)
            {
                if (phone.HangSanXuat == "OPPO")
                {
                    list.Add(phone.TenDienThoai);
                }
            }
            PhoneFilter(list);//tiền hành lọc
        }
    }
}
