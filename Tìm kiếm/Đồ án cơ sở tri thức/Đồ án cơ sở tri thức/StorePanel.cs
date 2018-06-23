using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
namespace Đồ_án_cơ_sở_tri_thức
{
    public partial class StorePanel : UserControl
    {
        public StorePanel()
        {
            InitializeComponent();
            bunifuDropdown1.AddItem("Hồ Chí Minh");
            bunifuDropdown2.AddItem("Quận 1");
            bunifuDropdown2.AddItem("Quận 2");
            bunifuDropdown1.selectedIndex = 0;
            bunifuDropdown2.selectedIndex = 0;
        }

         public static Dictionary<string, string> DiaChiCacCuaHang = new Dictionary<string, string>();
        string[] DiaChiHienThi;
        
        public static List<string> DiaChi = new List<string>();
        public static List<string> Quan = new List<string>();
       public static void Load_info()
        {
            string[] All = File.ReadAllLines(@"C:\Users\Wind\Desktop\Đồ án cơ sở tri thức\Đồ án cơ sở tri thức\bin\Debug\Knowledge base\Cấu trúc hệ tư vấn mua điện thoại - Copy.owl");
            string ck_Quan = "<owl:NamedIndividual rdf:about=\"urn:absolute:#Quận";
            //string ck_DiaChi = "<absolute:DiaChi rdf:datatype=\"#string\">";



            using (XmlReader reader = XmlReader.Create(@"C:\Users\Wind\Desktop\Đồ án cơ sở tri thức\Đồ án cơ sở tri thức\bin\Debug\Knowledge base\Cấu trúc hệ tư vấn mua điện thoại - Copy.owl"))
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {

                        switch (reader.Name.ToString())
                        {

                            case "absolute:DiaChi":
                                string st = reader.ReadElementContentAsString();
                                DiaChi.Add(st);

                                break;
                        }
                    }
                }

            foreach (var p in All)// them Quan
            {
                if (p.Contains(ck_Quan))
                {
                    string k;
                    k = p.Replace(ck_Quan, "Quận ");
                    k = k.Replace("\">", "");
                    k = k.Replace("_", " ");
                    k = k.Trim();
                    Quan.Add(k);
                }

            }


            foreach (string s1 in Quan)
            {
                string st = "";
                foreach (string s2 in DiaChi)
                {

                    if (s2.Contains(s1.Replace("Quận", "").Trim()))
                        st = st + s2 + ";";

                }
                DiaChiCacCuaHang.Add(s1, st);
            }
          
            
        }
        private  void StorePanel_Load(object sender, EventArgs e)
        {
            
        }
        public static string[] ProcessConvert(string Address)
        {
            string[] separators = { ";" };
            Address.Replace(" ", "_");
            string[] words = Address.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            return words;
        }
        
       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (KeyValuePair<string, string> kvp in DiaChiCacCuaHang)
            {

                DiaChiHienThi = ProcessConvert(kvp.Value.ToString());
                foreach(string s in DiaChiHienThi)
                {
                    String drawString = s;

                    // Create font and brush.
                    Font drawFont = new Font("Arial", 10);
                    SolidBrush drawBrush = new SolidBrush(Color.Black);

                    // Create point for upper-left corner of drawing.
                    PointF drawPoint = new PointF(150, 150);

                    // Draw string to screen.
                    e.Graphics.DrawString(drawString, drawFont, drawBrush, drawPoint);
                }

            }
            
           
           
        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
           
        }

        private void StorePanel_Load_1(object sender, EventArgs e)
        {

        }

    }
}
