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
    public partial class TuVan : UserControl
    {
        public TuVan()
        {
            InitializeComponent();
        }

        private void TuVan_Load(object sender, EventArgs e)
        {
            for(int i = 1; i < 150; i++)
            {
                bunifuDropdown1.AddItem(i.ToString());
            }
        }
    }
}
