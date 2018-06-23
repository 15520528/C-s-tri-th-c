using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Đồ_án_cơ_sở_tri_thức.Inference
{
    public class Inference
    {
        static List<String> GiaThiet;//lưu giữ tập sự kiện ban đầu
        static List<String> Known; //Tập sự kiện đã biết
        static Dictionary<List<String>, List<String>> RuleSet = new Dictionary<List<String>, List<String>>();//Lưu giữ tập luật, ứng với giả thiết và kết luận
        public static void forwardInference()
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
            //richTextBox2.Text = string.Join("\n", Known.ToArray());
        }

        public static void readRules()
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

        public static void getAsumpsion()
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
    }
}
