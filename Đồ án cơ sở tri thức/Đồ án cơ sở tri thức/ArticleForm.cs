using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_cơ_sở_tri_thức
{
    public partial class ArticleForm : Form
    {
        public String Keyword { get; set; }
        public String HtmlFilePath { get; set; }
        public ArticleForm()
        {
            InitializeComponent();
            
        }
        public ArticleForm(String keyword, String HtmlFilePath)
        {
            this.Keyword = keyword;
            this.HtmlFilePath = HtmlFilePath;
            InitializeComponent();
            this.ShowArticles();//Show bài báo ra giao diện
        }
        private void webBrowser1_Navigating(object sender,
        WebBrowserNavigatingEventArgs e)
        {
            e.Cancel = true;
            if (this.webBrowser1.Document == null)
            {
                //this.webBrowser1.DocumentText = htmlSource;
                String text = File.ReadAllText(HtmlFilePath);
                this.webBrowser1.DocumentText = text;
            }
            else
            {
                //this.webBrowser1.Document.OpenNew(true);
                //String text = File.ReadAllText(@"C:\Users\nhoxe\OneDrive\Documents\GitHub\C-s-tri-th-c\Đồ án cơ sở tri thức\Đồ án cơ sở tri thức\bin\Debug\Knowledge base\Articles\SUPER AMOLED.html");
                //this.webBrowser1.Document.Write(text);
                //    this.webBrowser1.Document.Write("<html><body>Please enter your name1321313asdasdasdasd:<br/>" +
                //"<input type='text' name='userName'/><br/>" +
                //"<a href='1234444'>continue</a>" +
                //"</body></html>");
            }
        }
        public void ShowArticles()
        {
            String text = File.ReadAllText(HtmlFilePath);
            this.webBrowser1.DocumentText = text;
            webBrowser1.Navigating +=
            new WebBrowserNavigatingEventHandler(webBrowser1_Navigating);
        }

        private void ArticleForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(250, 100);
        }
    }
}
