using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_cơ_sở_tri_thức
{
    public partial class BrandSelection : UserControl
    {
        //Danh sách tên hãng điện thoại được chọn
        List<String> CheckedPhoneList;

        // Delegate declaration (Khai báo hàm sự kiện gửi danh sách điện thoại được click tới form My App)
        public delegate void ClickTo(List<String> CheckedPhoneList);

        // Event declaration
        public event ClickTo PassParameters;

        public BrandSelection()
        {
            InitializeComponent();
            CheckedPhoneList = new List<String>();
        }

        //đóng ứng dụng
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //lọc điện thoại
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (PassParameters != null)
            {
                PassParameters(CheckedPhoneList);
            }
        }

        //SamSung Checked
        private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox2.Checked)
            {
                CheckedPhoneList.Add("Samsung");
            }
            else
            {
                CheckedPhoneList.Remove("Samsung");
            }
        }

        //OPPO checked
        private void bunifuCheckbox3_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox3.Checked)
            {
                CheckedPhoneList.Add("OPPO");
            }
            else
            {
                CheckedPhoneList.Remove("OPPO");
            }
        }

        //Sony checked
        private void bunifuCheckbox4_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox4.Checked)
            {
                CheckedPhoneList.Add("Sony");
            }
            else
            {
                CheckedPhoneList.Remove("Sony");
            }
        }

        //Motorola checked
        private void bunifuCheckbox9_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox9.Checked)
            {
                CheckedPhoneList.Add("Motorola");
            }
            else
            {
                CheckedPhoneList.Remove("Motorola");
            }
        }

        //Asus checked
        private void bunifuCheckbox10_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox10.Checked)
            {
                CheckedPhoneList.Add("Asus");
            }
            else
            {
                CheckedPhoneList.Remove("Asus");
            }
        }

        //HTC checked
        private void bunifuCheckbox12_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox12.Checked)
            {
                CheckedPhoneList.Add("HTC");
            }
            else
            {
                CheckedPhoneList.Remove("HTC");
            }
        }

        //Xiami checked
        private void bunifuCheckbox8_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox8.Checked)
            {
                CheckedPhoneList.Add("Xiaomi");
            }
            else
            {
                CheckedPhoneList.Remove("Xiaomi");
            }
        }

        //Mobiistar checked
        private void bunifuCheckbox11_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox11.Checked)
            {
                CheckedPhoneList.Add("Mobiistar");
            }
            else
            {
                CheckedPhoneList.Remove("Mobiistar");
            }
        }

        //Mobell checked
        private void bunifuCheckbox13_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox13.Checked)
            {
                CheckedPhoneList.Add("Mobell");
            }
            else
            {
                CheckedPhoneList.Remove("Mobell");
            }
        }

        private void BrandSelection_Load(object sender, EventArgs e)
        {

        }

        //Intels checked
        private void bunifuCheckbox15_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox15.Checked)
            {
                CheckedPhoneList.Add("Itel");
            }
            else
            {
                CheckedPhoneList.Remove("Itel");
            }
        }

        //Nokia checked
        private void bunifuCheckbox5_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox5.Checked)
            {
                CheckedPhoneList.Add("Nokia");
            }
            else
            {
                CheckedPhoneList.Remove("Nokia");
            }
        }

        //Vivo checked
        private void bunifuCheckbox7_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox7.Checked)
            {
                CheckedPhoneList.Add("Vivo");
            }
            else
            {
                CheckedPhoneList.Remove("Vivo");
            }
        }

        //Huawei checked
        private void bunifuCheckbox6_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox6.Checked)
            {
                CheckedPhoneList.Add("Huawei");
            }
            else
            {
                CheckedPhoneList.Remove("Huawei");
            }
        }

        //Iphone checked
        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox1.Checked)
            {
                CheckedPhoneList.Add("Apple");
            }
            else
            {
                CheckedPhoneList.Remove("Apple");
            }
        }

        //Philips checked
        private void bunifuCheckbox14_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox14.Checked)
            {
                CheckedPhoneList.Add("Philips");
            }
            else
            {
                CheckedPhoneList.Remove("Philips");
            }
        }

        private void bunifuCheckbox16_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox16.Checked)
            {
                bunifuCheckbox1.Checked = true;
                bunifuCheckbox2.Checked = true;
                bunifuCheckbox3.Checked = true;
                bunifuCheckbox4.Checked = true;
                bunifuCheckbox5.Checked = true;
                bunifuCheckbox6.Checked = true;
                bunifuCheckbox7.Checked = true;
                bunifuCheckbox8.Checked = true;
                bunifuCheckbox9.Checked = true;
                bunifuCheckbox10.Checked = true;
                bunifuCheckbox11.Checked = true;
                bunifuCheckbox12.Checked = true;
                bunifuCheckbox13.Checked = true;
                bunifuCheckbox14.Checked = true;
                bunifuCheckbox15.Checked = true;

                CheckedPhoneList.Add("Apple");
                CheckedPhoneList.Add("Samsung");
                CheckedPhoneList.Add("OPPO");
                CheckedPhoneList.Add("Sony");
                CheckedPhoneList.Add("Nokia");
                CheckedPhoneList.Add("Vivo");
                CheckedPhoneList.Add("Huawei");
                CheckedPhoneList.Add("Xiaomi");
                CheckedPhoneList.Add("Motorola");
                CheckedPhoneList.Add("Asus");
                CheckedPhoneList.Add("HTC");
                CheckedPhoneList.Add("Mobiistar");
                CheckedPhoneList.Add("Mobell");
                CheckedPhoneList.Add("Philips");
                CheckedPhoneList.Add("Itel");    
            }
            else
            {
                bunifuCheckbox1.Checked = false;
                bunifuCheckbox2.Checked = false;
                bunifuCheckbox3.Checked = false;
                bunifuCheckbox4.Checked = false;
                bunifuCheckbox5.Checked = false;
                bunifuCheckbox6.Checked = false;
                bunifuCheckbox7.Checked = false;
                bunifuCheckbox8.Checked = false;
                bunifuCheckbox9.Checked = false;
                bunifuCheckbox10.Checked = false;
                bunifuCheckbox11.Checked = false;
                bunifuCheckbox12.Checked = false;
                bunifuCheckbox13.Checked = false;
                bunifuCheckbox14.Checked = false;
                bunifuCheckbox15.Checked = false;
                CheckedPhoneList.Clear();
            }
        }
    }
}
