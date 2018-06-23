using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load(@"C:\Users\nhoxe\OneDrive\Documents\GitHub\C-s-tri-th-c\Đồ án cơ sở tri thức\Đồ án cơ sở tri thức\bin\Debug\Knowledge base\Cấu trúc hệ tư vấn mua điện thoại - Copy.owl");
            Dictionary<string, Dictionary<string, List<string>>> Provinces = new Dictionary<string, Dictionary<string, List<string>>>();
            Dictionary<String, List<string>> Districts = new Dictionary<string, List<string>>();
            foreach (XElement element in doc.Root.DescendantsAndSelf())
            {
                if(element.Name== "{urn:absolute:#}TrucThuoc")
                {
                    //Console.WriteLine(element.Parent.ToString());
                    StringReader reader = new StringReader(element.Parent.ToString());
                    if (element.Parent.ToString().Contains("urn:absolute:#Tinh"))//lấy thông tin tỉnh
                    {
                        String Str = element.Parent.ToString();
                        int first = Str.IndexOf("#") + 1;
                        int last = Str.ToString().IndexOf("\"", first);
                        String tinh = Str.Substring(first, last - first);
                        Console.WriteLine(tinh);
                        if (!Provinces.ContainsKey(tinh))
                        {
                            Provinces.Add(tinh, null);
                        }
                    }
                }
                else if (element.Name == "{urn:absolute:#}DiaChi")
                {
                    StringReader reader = new StringReader(element.Parent.ToString());
                    while (true)
                    {
                        String Str = reader.ReadLine();
                        if (Str == null)
                        {
                            break;
                        }
                        if (Str.Contains("TrucThuoc"))
                        {
                            int first = Str.IndexOf("#") + 1;
                            int last = Str.IndexOf(" ", first) - 1;
                            //Console.WriteLine(Str.Substring(first,last-first) + "\n" + element.Value + "\n___________\n");
                            String t = Str.Substring(first, last - first);
                            if (!Districts.ContainsKey(t))
                            {
                                List<string> list = new List<string>();
                                list.Add(element.Value);
                                Districts.Add(t, list);
                            }
                            else
                            {
                                List<string> list = new List<string>();
                                list.Add(element.Value);
                                Districts[t].AddRange(list);
                            }
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join("\n", Districts["Quận_1"].ToArray()));
        }
        //private void LoadDetailDestination()
        //{
        //    String CurrenFolderPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Knowledge base\";
        //    XDocument doc = XDocument.Load(CurrenFolderPath + "Cấu trúc hệ tư vấn mua điện thoại - Copy.owl");
        //    Districs = new Dictionary<string, List<string>>();
        //    foreach (XElement element in doc.Root.DescendantsAndSelf())
        //    {
        //        if (element.Name == "{urn:absolute:#}DiaChi")
        //        {
        //            StringReader reader = new StringReader(element.Parent.ToString());
        //            while (true)
        //            {
        //                String Str = reader.ReadLine();
        //                if (Str == null)
        //                {
        //                    break;
        //                }
        //                if (Str.Contains("TrucThuoc"))
        //                {
        //                    int first = Str.IndexOf("#") + 1;
        //                    int last = Str.IndexOf(" ", first) - 1;
        //                    //Console.WriteLine(Str.Substring(first,last-first) + "\n" + element.Value + "\n___________\n");
        //                    String t = Str.Substring(first, last - first);
        //                    if (!Districs.ContainsKey(t))
        //                    {
        //                        List<string> list = new List<string>();
        //                        list.Add(element.Value);
        //                        Districs.Add(t, list);
        //                    }
        //                    else
        //                    {
        //                        List<string> list = new List<string>();
        //                        list.Add(element.Value);
        //                        Districs[t].AddRange(list);
        //                    }
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    foreach (KeyValuePair<String, List<String>> item in Districs)
        //    {
        //        bunifuDropdown1.AddItem(item.Key);//Thêm tỉnh vào danh Dropdown bunifuDropdown1
        //    }
        //}
    }
}
