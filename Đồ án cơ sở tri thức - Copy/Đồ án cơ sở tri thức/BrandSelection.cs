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
        MyApp _parent;
        public BrandSelection()
        {
            InitializeComponent();
        }

        //đóng ứng dụng
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //lọc điện thoại
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            //this.Parent.get
            
        }
    }
}
