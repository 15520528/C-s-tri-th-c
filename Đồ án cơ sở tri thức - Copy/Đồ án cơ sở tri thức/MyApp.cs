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
namespace Đồ_án_cơ_sở_tri_thức
{
    public partial class MyApp : Form
    {
        List<String> GiaThiet;//lưu giữ tập sự kiện ban đầu
        List<String> Known; //Tập sự kiện đã biết
        Dictionary<List<String>, List<String>> RuleSet = new Dictionary<List<String>, List<String>>();//Lưu giữ tập luật, ứng với giả thiết và kết luận
        List<SmartPhone> PhoneList = new List<SmartPhone>();
        public MyApp()
        {
            InitializeComponent();
            
        }

        private void MyApp_Load(object sender, EventArgs e)
        {
            //đọc thông tin điện thoại
            LoadSmartPhoneInfo();

            //load thông tin điện thoại ra màn hình
            phone1.BringToFront();         
            {
                int row = (PhoneList.Count / 3) + 1;
                int y = 0;
                int index = 0;
                for (int i = 0; i < row; i++)
                {
                    int x = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        if (index <= PhoneList.Count - 1)
                        {
                            PhoneShow phone = new PhoneShow();
                            phone.Location = new Point(x, y);
                            phone.Controls["NameButton1"].Text = PhoneList[index].TenDienThoai;
                            phone.Controls["PriceButton1"].Text = PhoneList[index].Gia + " VNĐ";
                            phone1.Controls.Add(phone);
                            phone.BringToFront();
                            x += 210;
                        }
                        index++;
                    }
                    y += 270;
                }
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
        }

        //hiện section lọc hãng sản phẩm
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (this.brandSelection1.Visible)
            {
                this.brandSelection1.Hide();
            }
            else
            {
                this.brandSelection1.Location = new Point(290, 46);
                this.brandSelection1.BringToFront();
                this.brandSelection1.Show();
            }
        }
        //hiện section lọc hãng sản phẩm
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (this.brandSelection1.Visible)
            {
                this.brandSelection1.Hide();
            }
            else
            {
                this.brandSelection1.Location = new Point(290, 46);
                this.brandSelection1.BringToFront();
                this.brandSelection1.Show();
            }
        }

    }
}
