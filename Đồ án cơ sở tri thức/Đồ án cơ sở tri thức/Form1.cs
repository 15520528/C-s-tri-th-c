using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.IO;

namespace Đồ_án_cơ_sở_tri_thức
{
    public partial class Form1 : Form
    {
        List<String> GiaThiet;//lưu giữ tập sự kiện ban đầu
        List<String> Known; //Tập sự kiện đã biết
        Dictionary<List<String>, List<String> > RuleSet ;//Lưu giữ tập luật, ứng với giả thiết và kết luận
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAsumpsion();//lấy giả thiết từ người dùng nhập vào
            readRules();//đọc tập luật từ file
            foreach (KeyValuePair<List<String>, List<String>> rule in RuleSet)
            {
                richTextBox1.Text += "["+string.Join("AND", rule.Key.ToArray())+"]" + " THEN " + string.Join("AND", rule.Value.ToArray()) + "\n\n";
            }
            forwardInference();//suy diễn tiến
        }

        public void forwardInference()
        {
            bool found = true;
            List<int> AddedRules = new List<int>();
            while (found)
            {
                found = false;
                int i = 1;
                foreach (KeyValuePair<List<String>, List<String>> rule in RuleSet)
                {
                    if (rule.Key.All(elem => Known.Contains(elem)) && !AddedRules.Contains(i))
                    {
                        Console.WriteLine(string.Join(",", rule.Key.ToArray()));
                        Known.AddRange(rule.Value);
                        found = true;
                        AddedRules.Add(i);//đánh dấu đã xét qua luật
                    }
                    i++;
                }
            }
            richTextBox2.Text = string.Join("\n", Known.ToArray());
        }

        public void readRules()
        {
            //đọc luật
            XDocument doc = XDocument.Load(@"C:\Users\nhoxe\OneDrive\Documents\GitHub\C-s-tri-th-c\Rules.txt");
            foreach (var element in doc.Root.Elements())
            {
                String ruleString = element.Value;
                ruleString = ruleString.Trim();
                ruleString = "{" + ruleString + "}";
                Rules m = JsonHelper.ToClass<Rules>(ruleString);
                List<String> GT = new List<string>();
                List<String> KL = new List<string>();
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

        public void getAsumpsion()
        {
            GiaThiet.Add("NguoiSuDung.Tuoi(RatTre)");
            GiaThiet.Add("DienThoai.LoaiDienThoai(Phổ thông)");
            GiaThiet.Add("NguoiSuDung.Tuoi(TrungBinh)");
            GiaThiet.Add("DienThoai.LoaiDienThoai(Thông minh)");
            GiaThiet.Add("NguoiSuDung.ThuNhapCaNhan(Cao)");
            GiaThiet.Add("NguoiSuDung.ThuNhapCaNhan(RatCao)");
            GiaThiet.Add("NguoiSuDung.NhuCau(LuotWebMangXaHoi)");
            GiaThiet.Add("NguoiSuDung.ThoiGianSuDung(RatNhieu)");
            GiaThiet.Add("NguoiSuDung.NhuCau(ChoiGame)");
            Known = GiaThiet; //gán tập giả thiết ban đầu vào tập known

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GiaThiet = new List<String>();
            RuleSet = new Dictionary<List<string>, List<string>>();
            webBrowser1.BringToFront();
            //webBrowser1.Navigate("https://www.google.com/maps?527 Phan Văn Trị, P. 05, Q. Gò Vấp, TP. Hồ Chí Minh");
            //webBrowser1.DocumentText =
            //            "<html><body>Please enter your name:<br/>" +
            //    "<input type='text' name='userName'/><br/>" +
            //    @"<img src='C:\Users\nhoxe\OneDrive\Documents\GitHub\C-s-tri-th-c\Tìm kiếm\Đồ án cơ sở tri thức\Đồ án cơ sở tri thức\bin\Debug\hinh\Asus Zenfone 2 Go ZB500KG.PNG' alt='Cinque Terre' width='300' height='200'>" +
            //    "<a href='ABC'>continue</a>" +
            //    "</body></html>";
            String text = File.ReadAllText(@"C:\Users\nhoxe\OneDrive\Documents\GitHub\C-s-tri-th-c\Đồ án cơ sở tri thức\Đồ án cơ sở tri thức\bin\Debug\Knowledge base\Articles\SUPER AMOLED.html");
            this.webBrowser1.DocumentText = text;
            webBrowser1.Navigating +=
            new WebBrowserNavigatingEventHandler(webBrowser1_Navigating);
            
        }
        private void webBrowser1_Navigating(object sender,
        WebBrowserNavigatingEventArgs e)
        {
            e.Cancel = true;
            if (this.webBrowser1.Document == null)
            {
                //this.webBrowser1.DocumentText = htmlSource;
            }
            else
            {
                this.webBrowser1.Document.OpenNew(true);
                String text = File.ReadAllText(@"C:\Users\nhoxe\OneDrive\Documents\GitHub\C-s-tri-th-c\Đồ án cơ sở tri thức\Đồ án cơ sở tri thức\bin\Debug\Knowledge base\Articles\SUPER AMOLED.html");
                this.webBrowser1.Document.Write(text);
                //    this.webBrowser1.Document.Write("<html><body>Please enter your name1321313asdasdasdasd:<br/>" +
                //"<input type='text' name='userName'/><br/>" +
                //"<a href='1234444'>continue</a>" +
                //"</body></html>");

            }
        }

    }
    public class Rules
    { 
        [JsonProperty("GT")]
        public string[] GiaThiet { get; set; }

        [JsonProperty("KL")]
        public string[] KetLuan { get; set; }
    }

    public static class JsonHelper
    {
        public static string FromClass<T>(T data, bool isEmptyToNull = false,
                                          JsonSerializerSettings jsonSettings = null)
        {
            string response = string.Empty;

            if (!EqualityComparer<T>.Default.Equals(data, default(T)))
                response = JsonConvert.SerializeObject(data, jsonSettings);

            return isEmptyToNull ? (response == "{}" ? "null" : response) : response;
        }

        public static T ToClass<T>(string data, JsonSerializerSettings jsonSettings = null)
        {
            var response = default(T);

            if (!string.IsNullOrEmpty(data))
                response = jsonSettings == null
                    ? JsonConvert.DeserializeObject<T>(data)
                    : JsonConvert.DeserializeObject<T>(data, jsonSettings);

            return response;
        }
    }
}
