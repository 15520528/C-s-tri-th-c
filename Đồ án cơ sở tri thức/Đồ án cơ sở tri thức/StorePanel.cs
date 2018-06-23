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
using System.IO;

namespace Đồ_án_cơ_sở_tri_thức
{
    public partial class StorePanel : UserControl
    {
        Dictionary<string, List<string>> Provinces ;
        Dictionary<String, List<string>> Districts ;
        public StorePanel()
        {
            InitializeComponent();
        }

        private void StorePanel_Load(object sender, EventArgs e)
        {
            LoadDetailDestination();//Load thông tin địa chỉ cửa hàng từng quận của tp HCM
        }
        //Load thông tin địa chỉ cửa hàng tại từng quận
        private void LoadDetailDestination()
        {
            String CurrenFolderPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Knowledge base\";
            XDocument doc = XDocument.Load(CurrenFolderPath + "Cấu trúc hệ tư vấn mua điện thoại - Copy.owl");
            Provinces = new Dictionary<string, List<string>>();
            Districts = new Dictionary<string, List<string>>();
            foreach (XElement element in doc.Root.DescendantsAndSelf())
            {
                if (element.Name == "{urn:absolute:#}TrucThuoc")
                {
                    //Console.WriteLine(element.Parent.ToString());
                    StringReader reader = new StringReader(element.Parent.ToString());
                    if (element.Parent.ToString().Contains("urn:absolute:#Tinh"))//lấy thông tin tỉnh
                    {
                        String Str = element.Parent.ToString();
                        int first = Str.IndexOf("#") + 1;
                        int last = Str.ToString().IndexOf("\"", first);
                        String tinh = Str.Substring(first, last - first).Replace("_"," ");                       
                        if (!Provinces.ContainsKey(tinh))
                        {
                            Provinces.Add(tinh, new List<string>());
                            Console.WriteLine(tinh);
                        }
                    }
                    else if (element.Parent.ToString().Contains("urn:absolute:#Quan"))//lấy tên quận và tỉnh của quận đó
                    {
                        String Str = element.Parent.ToString();
                        int first = Str.IndexOf("#") + 1;
                        int last = Str.ToString().IndexOf("\"", first);
                        String Quan = Str.Substring(first, last - first).Replace("_", " ");
                        String Tinh = "";
                        //StringReader reader = new StringReader(element.Parent.ToString());
                        while (true)//lấy tên tỉnh
                        {
                            Str = reader.ReadLine();
                            if (Str == null)
                            {
                                break;
                            }
                            if (Str.Contains("TrucThuoc"))
                            {
                                first = Str.IndexOf("#") + 1;
                                last = Str.ToString().IndexOf("\"", first);
                                Tinh = Str.Substring(first, last - first).Replace("_", " ");//lấy tên tỉnh
                            }
                        }
                        if (Provinces.ContainsKey(Tinh))
                        {
                            Provinces[Tinh].Add(Quan);
                            Console.WriteLine(Tinh + "-" + Quan);
                        }
                    }
                }
                else if (element.Name == "{urn:absolute:#}DiaChi")
                {
                    StringReader reader = new StringReader(element.Parent.ToString());
                    while (true)
                    {
                        String Str = reader.ReadLine();
                        if (Str == null)
                        {
                            break;
                        }
                        if (Str.Contains("TrucThuoc"))
                        {
                            int first = Str.IndexOf("#") + 1;
                            int last = Str.IndexOf(" ", first) - 1;
                            //Console.WriteLine(Str.Substring(first,last-first) + "\n" + element.Value + "\n___________\n");
                            String t = Str.Substring(first, last - first).Replace("_", " ");
                            if (!Districts.ContainsKey(t))
                            {
                                List<string> list = new List<string>();
                                list.Add(element.Value);
                                Districts.Add(t, list);
                            }
                            else
                            {
                                List<string> list = new List<string>();
                                list.Add(element.Value);
                                Districts[t].AddRange(list);
                            }
                            break;
                        }
                    }
                }
            }
            foreach (KeyValuePair<String, List<String>> item in Provinces)
            {
                bunifuDropdown1.AddItem(item.Key);//Thêm tỉnh vào danh Dropdown bunifuDropdown1
            }
        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            bunifuDropdown2.Clear();
            panel1.Controls.Clear();
            String province = bunifuDropdown1.selectedValue;//lấy tỉnh được chọn
            int y = 10;
            foreach (String District in Provinces[province])
            {
                bunifuDropdown2.AddItem(District);//Thêm từng địa chỉ vào bunifuDropdown 2
            }
        }

        //đổi màu label khi hover lên
        private void KeyHover(object sender, System.EventArgs e)
        {
            (sender as Label).ForeColor = Color.OrangeRed;
        }

        //đổi màu label sau khi leave
        private void KeyLeave(object sender, System.EventArgs e)
        {
            (sender as Label).ForeColor = Color.FromArgb(0, 192, 192);
        }

        //đổi màu label khi hover lên
        private void Click(object sender, System.EventArgs e)
        {
            //MessageBox.Show((sender as Label).Text);
            //panel1.Hide();
            //webBrowser1.Navigate("https://www.google.com/maps");
            //webBrowser1.BringToFront();
            //webBrowser1.Show();
        }

        private void bunifuDropdown2_onItemSelected(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            String District = bunifuDropdown2.selectedValue;//lấy quận được chọn
            //Hiển thị số lượng siêu thị lên giao diện
            Label CountDistrict = new Label();
            panel1.Controls.Add(CountDistrict);
            CountDistrict.Location = new Point(30, 10);
            CountDistrict.ForeColor = Color.Black;
            CountDistrict.AutoSize = true;
            CountDistrict.Text = "Có " + Districts[District].Count + " Siêu Thị Tại Thành Phố " + bunifuDropdown2.selectedValue +", " + bunifuDropdown1.selectedValue;
            CountDistrict.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Regular);
            CountDistrict.Cursor = Cursors.Hand;
            int y = 40;
            //Hiển thị chi tiết từng địa chỉ lên giao diện
            Console.WriteLine(District);
            foreach (String Dest in Districts[District])
            {
                Label Details = new Label();
                panel1.Controls.Add(Details);
                Details.Location = new Point(30, y);
                Details.AutoSize = true;
                Details.Text = Dest;
                Details.ForeColor = Color.FromArgb(0, 192, 192);
                Details.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                Details.Cursor = Cursors.Hand;
                Details.MouseHover += new EventHandler(KeyHover);
                Details.MouseLeave += new EventHandler(KeyLeave);
                Details.MouseClick += new MouseEventHandler(Click);
                y += 20;
            }
        }
    }
}
