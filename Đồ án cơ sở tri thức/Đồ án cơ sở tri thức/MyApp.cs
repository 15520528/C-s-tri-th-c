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
            brandSelection2.PassParameters += new BrandSelection.ClickTo(PhoneFilterClick);
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
            XDocument doc = XDocument.Load(@"D:\courses_2016-2017\Nam 3\Kì 2\Cơ sở tri thức\đồ án\SmartPhoneData.json");
            foreach (var element in doc.Root.Elements())
            {
                String jsonString = element.Value.ToString();
                jsonString = jsonString.Trim();
                jsonString = jsonString.Insert(0, "{");
                jsonString = jsonString.Insert(jsonString.Length, "}");
                SmartPhone phone = JsonHelper.ToClass<SmartPhone>(jsonString);
                //Console.WriteLine(phone.DoPhanGiai);
                PhoneList.Add(phone);
            }
            //String PhoneStr = "[";
            //foreach (SmartPhone phone in PhoneList)
            //{
            //    int pos = Array.IndexOf(phone.MangDiDong, "3G");
            //    //int pos1 = Array.IndexOf(phone.MangDiDong, "4G");
            //    int pos2 = Array.IndexOf(phone.Wifi, "Wi-Fi 802.11 b/g/n");
            //    int pos3 = Array.IndexOf(phone.Wifi, "Wi-Fi Direct");
            //    int pos4 = Array.IndexOf(phone.Wifi, "Wi-Fi hotspot");
            //    if (pos > -1 && pos2 > -1 && pos3 > -1 &&pos4 > -1 && phone.DoPhanGiai.Contains("HD"))
            //    {
            //        PhoneStr += "'" + phone.TenDienThoai + "',\n";
            //        Console.WriteLine("{0} - {1}", phone.TenDienThoai, string.Join(", ", phone.NgheNhac));
            //    }


            //}
            //PhoneStr.Trim();
            //PhoneStr = PhoneStr.Remove(PhoneStr.Length - 1, 1);
            //PhoneStr += "]";
            //richTextBox1.Text = PhoneStr;
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
