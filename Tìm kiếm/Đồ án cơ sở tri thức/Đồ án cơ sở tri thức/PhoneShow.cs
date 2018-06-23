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
    public partial class PhoneShow : UserControl
    {
        int Y;
        Timer Timer;
        public PhoneShow()
        {
            InitializeComponent();
            Timer = new Timer();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        { 
            Timer.Interval = 5;
            Timer.Tick += Timer_Tick;
          //  Timer.Start();
            Y = pictureBox1.Location.Y;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y-1);
            if (pictureBox1.Location.Y == Y - 30)
            {
                Timer.Dispose();
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            Timer.Interval = 5;
            Timer.Tick += Timer_Tick1;
         //   Timer.Start();
        }

        private void Timer_Tick1(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 1);
            if (pictureBox1.Location.Y == Y)
            {
                Timer.Dispose();
            }
        }
        //xem chi tiết một điện thoại
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load(@"C:\Users\Wind\Desktop\Đồ án cơ sở tri thức\Đồ án cơ sở tri thức\bin\Debug\Knowledge base\SmartPhoneData.json");
            foreach (var element in doc.Root.Elements())
            {
                String jsonString = element.Value.ToString();
                jsonString = jsonString.Trim();
                jsonString = jsonString.Insert(0, "{");
                jsonString = jsonString.Insert(jsonString.Length, "}");
                SmartPhone phone = JsonHelper.ToClass<SmartPhone>(jsonString);
                if(NameButton1.Text == phone.TenDienThoai)
                {
                    new Form2(phone).Show();
                    break;
                }
            }
        }
    }
}
