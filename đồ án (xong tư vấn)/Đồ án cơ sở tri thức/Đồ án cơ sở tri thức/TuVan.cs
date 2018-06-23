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
        Dictionary<List<String>, List<String>> RuleSet;//Lưu giữ tập luật trung gian, ứng với giả thiết và kết luận
        Dictionary<List<String>, List<String>> PhoneRuleSet;/*Lưu giữ tập luật trực tiếp suy ra điện thoại, 
                                                             ứng với giả thiết và kết luận*/
        Dictionary<List<String>, List<String>> SolutionSet; //lưu giữ các luật được áp dụng trong suy diễn tiến,Sẽ dùng cho Suy diễn lùi
        List<List<String>> PhoneKnown; //lưu giữ các luật suy ra điện thoại được áp dụng trong suy diễn tiến
        HashSet<String> PhoneList;//danh sách tên các điện thoại được suy ra từ các luật
        Dictionary<List<string>, List<string>> PhoneRules = new Dictionary<List<string>, List<string>>(); //Lưu trữ luật User'input -> [listphones]
        List<string> Sol;
        // Delegate declaration (Khai báo hàm sự kiện gửi danh sách điện thoại được click tới form My App)
        public delegate void ClickTo(Dictionary<String,float> PhoneList);
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
            //Khởi tạo các trường của class
            GiaThiet = new List<string>();
            RuleSet = new Dictionary<List<String>, List<String>>();
            PhoneRuleSet = new Dictionary<List<String>, List<String>>();
            SolutionSet = new Dictionary<List<String>, List<String>>();
            //khởi tạo giá trị tuổi cho dropdown
            for (int i = 1; i < 150; i++)
            {
                bunifuDropdown1.AddItem(i.ToString());
            }

            /*
            + đọc các luật suy diễn trung gian từ file
            + đọc các luật suy diễn ra điện thoại từ file
            */
            readRules();
        }

        //Hàm đọc luật từ Cơ sở tri thức
        public void readRules()
        {
            //đọc luật trung gian
            {
                CurrenFolderPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Knowledge base\";
                XDocument doc = XDocument.Load(CurrenFolderPath + "RulesSet.Json");
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
                    ruleString = "{" + ruleString + "}";
                    Rules m = JsonHelper.ToClass<Rules>(ruleString);
                    List<String> GT = new List<string>();
                    List<String> KL = new List<string>();
                    foreach (String gt in m.GiaThiet)//thêm từng giả thiết từ luật m vào tập GT
                    {
                        GT.Add(gt);
                    }
                    foreach (String kl in m.KetLuan)//thêm từng kết luận từ luật m vào tập KL
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

        /*Hàm suy diễn tiến từ sự kiện ban đầu
        So khớp sự kiện trong Known với giả thiết của từng luật trong RuleSet */
        public void forwardInference()
        {
            {
                PhoneKnown = new List<List<string>>();
                SolutionSet = new Dictionary<List<string>, List<string>>();
                bool found = true;
                List<int> AddedRules = new List<int>();
                while (found)
                {
                    found = false;
                    int i = 1;
                    foreach (KeyValuePair<List<String>, List<String>> rule in RuleSet)
                    {
                        if (rule.Key.All(elem => Known.Contains(elem)) && !AddedRules.Contains(i))//Nếu tìm thấy một luật áp dụng được
                        {
                            SolutionSet.Add(rule.Key, rule.Value);//Thêm luật được áp dụng vào tập Solution set
                            if (rule.Value[0].Contains("DienThoai"))
                            {
                                PhoneKnown.Add(rule.Value);
                            }
                            Known.AddRange(rule.Value);//them vào known
                            found = true;
                            AddedRules.Add(i);//đánh dấu đã xét qua luật
                        }
                        i++;
                    }
                }
            }
            //In ra các luật được áp dụng từ suy diễn tiến
            //Console.WriteLine("Quá trình suy diễn tiến \n");
            foreach (KeyValuePair<List<String>, List<String>> rule in SolutionSet)
            {
                //Console.WriteLine("[" + string.Join(" AND ", rule.Key.ToArray()) + "]" + " THEN " + string.Join(" AND ", rule.Value.ToArray()) + "\n\n");
            }
            //loại bỏ các sự kiện rỗng
            Known.RemoveAll(EndsWithSpace);

            //List<string> goals = new List<string>();
            //goals.Add("DienThoai.SIM(2 SIM)");
            //this.backwardInference(goals);

            //Gọi hàm suy ra danh sách điện thoại tConsole.WriteLine(ừ tập sự kiện thu được
            //MessageBox.Show(string.Join("\n", Known.ToArray()));
            //Console.WriteLine(string.Join("\n", Known.ToArray()));

            List<string> list = new List<string>();
            list.Add(KhangNuocKhangBui);
            PhoneKnown.Add(list);
            list = new List<string>();
            list.Add(Cham2LanSang);
            PhoneKnown.Add(list);
            list = new List<string>();
            list.Add(SacPin);
            PhoneKnown.Add(list);
            //foreach (List<string> X in PhoneKnown)
            //{
            //    Console.WriteLine(string.Join(",", X.ToArray()) + "\n");
            //}
                 
        }

        //Hàm suy ra danh sách điện thoại từ các sự kiện cuối cùng được suy ra nằm trong tập Known
        public void PhoneInference()
        {
            PhoneList = new HashSet<string>();//lưu giữ danh sách điện thoại sẽ được show lên sau khi tư vấn
            PhoneRules = new Dictionary<List<string>, List<string>>();
            //So khớp giả thiết với tập luật suy ra điện thoại (PhoneRuleSet)
            foreach (KeyValuePair<List<String>, List<String>> rule in PhoneRuleSet)
            {
                bool found = false;
                foreach(List<string> X in PhoneKnown)
                {
                    //Console.WriteLine(String.Join(",",X.ToArray()) + "\n" + String.Join(",", rule.Key.ToArray())+"\n___\n");
                    if (String.Join(",",X.ToArray()).Equals(String.Join(",",rule.Key.ToArray()),StringComparison.CurrentCultureIgnoreCase))
                    {    
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    List<String> list = new List<string>();
                    foreach (string phoneName in rule.Value)
                    {
                        PhoneList.Add(phoneName);//Thêm điện thoại được suy ra từ luật vào Phonelist
                        list.Add(phoneName);
                    }
                    /*
                     - List (Sol) lưu lại Input cầu người dùng nhập vào Mà từ đó suy ra được Giả thiết này (Rule.key)
                        Sol -> x1->x2..-> Rule.key->[phones]
                     - Dùng Suy diễn lùi tìm ra Sol
                     -  Dùng Dictionary (PhoneRules) lưu lại cặp (key,values) =(Sol, list) chứa các điện thoại được suy ra từ Sol
                        Sol=NguoiDung.DienThoai(2sim)->DienThoai.Sim(2sim)->list=[Lumia 2, Nokia 8,.....]
                     */
                    Sol = new List<string>();
                    this.backwardInference(rule.Key);
                    //Console.WriteLine("______________\n"+string.Join(" , ", rule.Key) + " [" + string.Join("AND", Sol.ToArray()) + "]\n" + Sol.Count);
                    if (Sol.Count == 0) //Nếu Sol không thể tìm ra => thì Sol là các User'input VD: NguoiDung.DienThoai(KhangBui,KhangNuoc), NguoiDung.DienThoai(2Sim)
                    {
                        PhoneRules.Add(rule.Key, list);
                    }
                    else if (!PhoneRules.ContainsKey(Sol)) //Nếu Sol chưa tồn tại trong Dictionary
                    {
                        PhoneRules.Add(Sol, list);
                    }
                    else
                    {
                        PhoneRules[Sol].AddRange(list); //Nếu Sol đã tồn tại trong Dictionary
                    }
                }
                    
            }
            Console.WriteLine("___________\n");
            foreach (KeyValuePair<List<String>, List<String>> rule in PhoneRules)
            {
                Console.WriteLine(string.Join(" AND ", rule.Key.ToArray()) );
            }
            
            //MessageBox.Show(string.Join("\n", X.ToArray()));
        }

        //Hàm suy ra danh sách điện thoại từ các sự kiện cuối cùng được suy ra nằm trong tập Known
        //public void PhoneInference()
        //{
        //    PhoneList = new HashSet<string>();//lưu giữ danh sách điện thoại sẽ được show lên sau khi tư vấn
        //    PhoneRules = new Dictionary<List<string>, List<string>>();
        //    //So khớp giả thiết với tập luật suy ra điện thoại (PhoneRuleSet)
        //    foreach (KeyValuePair<List<String>, List<String>> rule in PhoneRuleSet)
        //    {
        //        if (rule.Key.All(elem => Known.Contains(elem)))//Nếu tìm thấy luật 
        //        {
        //            Console.WriteLine(string.Join(",", rule.Key.ToArray()));
        //            List<String> list = new List<string>();
        //            foreach (string phoneName in rule.Value)
        //            {
        //                PhoneList.Add(phoneName);
        //                list.Add(phoneName);
        //            }
        //            Sol = new List<string>();
        //            if (Sol!=null)
        //            {
        //                //Console.WriteLine("__________\n");
        //                this.backwardInference(rule.Key);
        //                //Console.WriteLine(string.Join(" , ", rule.Key) + " [" + string.Join("AND", Sol.ToArray()) + "]\n" );
        //                if (!PhoneRules.ContainsKey(Sol))
        //                {
        //                    PhoneRules.Add(Sol, list);//Thêm luật áp dụng được vào PhoneRules
        //                }
        //                else
        //                {
        //                    PhoneRules[Sol].AddRange(list);
        //                }
        //            }
        //        }
        //    }
        //    //MessageBox.Show(string.Join("\n", X.ToArray()));
        //}


        //Hàm suy diễn lùi tìm ra sự kiện gốc suy ra nó
        public void backwardInference(List<string> Goals)
        {
            //nếu tập goal chưa tồn tại trong giả thiết
            if (!Goals.All(elem => GiaThiet.Contains(elem)))
            {
                bool Found = false;
                List<List<string>> F = new List<List<string>>();//Tập F lưu giữ các Sự kiện ở phần giải thiết của luật được áp dụng
                foreach (KeyValuePair<List<String>, List<String>> rule in SolutionSet) //Xét từng luật tìm ra luật phát sinh ra tập Goals
                {
                    //Console.WriteLine("[" + string.Join("AND", rule.Key.ToArray()) + "]" + " THEN " + string.Join("AND", rule.Value.ToArray()) + "\n\n");
                    if (Goals.All(elem => rule.Value.Contains(elem))) //Nếu tìm thấy luật cần thiết
                    {
                        Found = true;
                        F.Add(rule.Key);
                        //Console.WriteLine("[" + string.Join("AND", rule.Key.ToArray()) + "]" + " THEN " + string.Join("AND", rule.Value.ToArray()) + "\n\n");
                    }
                }
                if (Found)//Nếu tìm được luật sinh ra tập goal
                {
                    foreach (List<String> gt in F)//Tìm luật sinh ra từng sự kiện trong giả thiết của tập r
                    {
                        Sol = gt;
                        foreach (String eventt in gt)
                        {
                            List<string> goal = new List<string>();
                            goal.Add(eventt);
                            backwardInference(goal);
                        }
                    }
                }
            }
        }

        //Hàm đánh giá xếp hạng từng điện thoại
        public Dictionary<string,float> PhoneEvaluate()
        {
            Dictionary<string, float> Phones = new Dictionary<string, float>();
            //đếm tần số xuất hiện của từng điện thoại thỏa mản yêu cầu người dùng nhập vào
            foreach (string phoneName in PhoneList)
            {
                int count = 0;
                foreach (KeyValuePair<List<String>, List<String>> rule in PhoneRules)
                {
                    if (rule.Value.Contains(phoneName))//Nếu tìm thấy luật 
                    {
                        count++;
                    }
                }
                Phones.Add(phoneName, (float)count / PhoneRules.Count);
                //Console.WriteLine(phoneName + " = " + count);
            }
            //Sắp xếp thăng dần theo tần số
            List<KeyValuePair<string, float>> myList = Phones.ToList();
            myList.Sort(
                delegate (KeyValuePair<string, float> pair1,
                KeyValuePair<string, float> pair2)
                {
                    return pair1.Value.CompareTo(pair2.Value);
                }
            );
            myList.Reverse();//Đảo ngược
            Console.WriteLine("_______________\n Ti le xep hang tung dien thoai \n");
            foreach (KeyValuePair<string, float> x in myList)
            {
                Console.WriteLine(x.Key + " = " + x.Value);
            }
            //return Danh sách điện thoại (Tên điện thoại, Tần số xuất hiện)
            return myList.ToDictionary(t => t.Key, t => t.Value);
        }

        private static bool EndsWithSpace(String s)
        {
            return string.IsNullOrEmpty(s);
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
            GiaThiet.RemoveAll(EndsWithSpace);
            Known = GiaThiet.ToList();
            //MessageBox.Show(string.Join(",", GiaThiet));
            //Thực hiện suy diễn tiến sinh ra các sự kiện có thể có
            this.forwardInference();
            this.PhoneInference();
            Dictionary<string,float> PhonesSet = this.PhoneEvaluate();
            if (PassParameters != null)
            {
                //gửi danh sách điện thoại được suy ra từ tư vấn tới giao diện MyApp
                PassParameters(PhonesSet);
            }
            //MessageBox.Show(string.Join("\n", GiaThiet));
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
                Game2D = "NguoiDung.ChoiGame(2D)";
            }
            else
            {
                Game2D = "";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                Game3D = "NguoiDung.ChoiGame(3D)";
            }
            else
            {
                Game3D = "";
            }
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
