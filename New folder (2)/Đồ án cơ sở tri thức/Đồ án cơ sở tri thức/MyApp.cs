using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_cơ_sở_tri_thức
{
    public partial class MyApp : Form
    {
        public MyApp()
        {
            InitializeComponent();
        }

        private void MyApp_Load(object sender, EventArgs e)
        {
            phone1.BringToFront();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tuVan1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            phone1.BringToFront();
        }
    }
}
