using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel=Microsoft.Office.Interop.Excel;
using System.Threading;
using System.IO;
namespace ReadWrite
{
    class Program
    {
        
        public static string ProcessConvert(string begin, string value, string finish) 
        {
            string[] separators = { "," };
            string[] words = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string Convert;
            Convert = begin;
            foreach (var word in words)
            {
                if (word.Equals(words[words.Length - 1]))
                    Convert+="'" + word + "'";
                else Convert+="'" + word + "',";
            }
            Convert += finish;
            return Convert;
        }
        static void Main(string[] args)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\Wind\Documents\visual studio 2013\Projects\ReadWrite\ReadWrite\bin\Debug\Database.xlsx");
            Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.Sheets.get_Item(1);
            Excel.Range xlRange = xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            string pathtxt = @"C:\Users\Wind\Documents\visual studio 2013\Projects\ReadWrite\ReadWrite\bin\Debug\database.txt";
            FileStream fs = new FileStream(pathtxt, FileMode.Create);
            StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);
            Dictionary<int, string> DienThoai=new Dictionary<int, string>();;
            DienThoai.Add(2, "TenDIenThoai");
            DienThoai.Add(3, "CongNgheManHinh");
            DienThoai.Add(4, "DoPhanGiai");
            DienThoai.Add(5, "ManHinhRong");
            DienThoai.Add(6, "MatKinhCamUng");
            DienThoai.Add(7, "DoPhanGiaiCameraSau");                 //
            DienThoai.Add(8, "QuayPhim");
            DienThoai.Add(9, "DenFlash");
            DienThoai.Add(10, "ChupAnhNangCao");                 //
            DienThoai.Add(11, "DoPhanGiaiCameraSau");
            DienThoai.Add(12, "VideoCall");
            DienThoai.Add(13, "TinhNangCameraTruoc");             //
            DienThoai.Add(14, "HeDieuHanh");
            DienThoai.Add(15, "ChipSet");
            DienThoai.Add(16, "TocDoCPU");
            DienThoai.Add(17, "ChipDoHoa");
            DienThoai.Add(18, "RAM");
            DienThoai.Add(19, "BoNhoTrong");
            DienThoai.Add(20, "BoNhoConLai");
            DienThoai.Add(21, "TheNhoNgoai");
            DienThoai.Add(22, "MangDiDong");                    //
            DienThoai.Add(23, "SIM");
            DienThoai.Add(24, "Wifi");                         //
            DienThoai.Add(25,"GPS");                           //
            DienThoai.Add(26, "Bluetooth");                      //
            DienThoai.Add(27, "CongKetNoi_Sac");
            DienThoai.Add(28, "JackTaiNghe");
            DienThoai.Add(29, "KetNoiKhac");                //
            DienThoai.Add(30, "ThietKe");                 //
            DienThoai.Add(31, "ChatLieu");                //
            DienThoai.Add(32, "KichThuoc");
            DienThoai.Add(33, "TrongLuong");
            DienThoai.Add(34, "DungLuongPin");
            DienThoai.Add(35, "LoaiPin");
            DienThoai.Add(36, "CongNghePin");         //
            DienThoai.Add(37, "BaoMatNangCao");              //
            DienThoai.Add(38, "TinhNangDacBiet");            //
            DienThoai.Add(39, "GhiAm");                    //
            DienThoai.Add(40, "Radio");
            DienThoai.Add(41, "XemPhim");
            DienThoai.Add(42, "NgheNhac");
            DienThoai.Add(43, "ThoiDiemRaMat");
            DienThoai.Add(44, "MauSac");
            DienThoai.Add(45, "Gia");
            DienThoai.Add(46, "HangSanXuat");
            DienThoai.Add(47, "LoaiDienThoai");
            //for (int i = 2; i <= rowCount; i++)
            //{
            //    for (int j = 2; i <= 45; i++)
            //    {
            //        if(j==7||j=10||j==13||j==22||j==24||j==25||j==26||j==29||j=30||j=31||j==36||j==37||j==38||j==39)
            //            sWriter.WriteLine(ProcessConvert("          "+DienThoai.Values. : [", xlRange.Cells[i, 7].Value2.ToString(), "],"));
            //    }
            //}
            for (int i = 2; i <= rowCount; i++)// Row
            {
                
                    sWriter.WriteLine("<Object>");
                    sWriter.WriteLine("          HangSanXuat :'" + xlRange.Cells[i, 46].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine("          LoaiDienThoai :'" + xlRange.Cells[i, 47].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine("          TenDienThoai :'" + xlRange.Cells[i, 2].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine("          CongNgheManHinh :'" + xlRange.Cells[i, 3].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine("          DoPhanGiai :'" + xlRange.Cells[i, 4].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine("          ManHinhRong :'" + xlRange.Cells[i, 5].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine("          MatKinhCamUng :'" + xlRange.Cells[i, 6].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine(ProcessConvert("          DoPhanGiaiCameraSau : [", xlRange.Cells[i, 7].Value2.ToString(), "],"));
                    sWriter.WriteLine("          Quayphim :'" + xlRange.Cells[i, 8].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine("          DenFlash :'" + xlRange.Cells[i, 9].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine(ProcessConvert("          ChupAnhNangCao : [", xlRange.Cells[i, 10].Value2.ToString(), "],"));
                    sWriter.WriteLine("          DoPhanGiaiCameraTruoc :'" + xlRange.Cells[i, 11].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine("          Videocall :'" + xlRange.Cells[i, 12].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine(ProcessConvert("          TinhNangCameraTruoc : [", xlRange.Cells[i, 13].Value2.ToString(), "],"));
                    sWriter.WriteLine("          HeDieuHanh :'" + xlRange.Cells[i, 14].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine("          Chipset :'" + xlRange.Cells[i, 15].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine("          TocDoCPU :'" + xlRange.Cells[i, 16].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine("          ChipDoHoa :'" + xlRange.Cells[i, 17].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine("          RAM :'" + xlRange.Cells[i, 18].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine("          BoNhoTrong :'" + xlRange.Cells[i, 19].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine("          BoNhoConLai :'" + xlRange.Cells[i, 20].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine("          TheNhoNgoai :'" + xlRange.Cells[i, 21].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine(ProcessConvert("          MangDiDong : [", xlRange.Cells[i, 22].Value2.ToString(), "],"));
                    sWriter.WriteLine("          SIM :'" + xlRange.Cells[i, 23].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine(ProcessConvert("          Wifi : [", xlRange.Cells[i, 24].Value2.ToString(), "],"));
                    sWriter.WriteLine(ProcessConvert("          GPS : [", xlRange.Cells[i, 25].Value2.ToString(), "],"));
                    sWriter.WriteLine(ProcessConvert("          Bluetooth : [", xlRange.Cells[i, 26].Value2.ToString(), "],"));
                    sWriter.WriteLine("          CongKetNoi_Sac :'" + xlRange.Cells[i, 27].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine("          JackTaiNghe :'" + xlRange.Cells[i, 28].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine(ProcessConvert("          KetNoiKhac : [", xlRange.Cells[i, 29].Value2.ToString(), "],"));
                    sWriter.WriteLine(ProcessConvert("          ThietKe : [", xlRange.Cells[i, 30].Value2.ToString(), "],"));
                    sWriter.WriteLine(ProcessConvert("          ChatLieu : [", xlRange.Cells[i, 31].Value2.ToString(), "],"));
                    sWriter.WriteLine("          KichThuoc :'" + xlRange.Cells[i, 32].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine("          TrongLuong :'" + xlRange.Cells[i, 33].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine("          DungLuongPin :'" + xlRange.Cells[i, 34].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine("          LoaiPin :'" + xlRange.Cells[i, 35].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine(ProcessConvert("          CongNghePin : [", xlRange.Cells[i, 36].Value2.ToString(), "],"));
                    sWriter.WriteLine(ProcessConvert("          BaoMatNangCao : [", xlRange.Cells[i, 37].Value2.ToString(), "],"));
                    sWriter.WriteLine(ProcessConvert("          TinhNangDacBiet : [", xlRange.Cells[i, 38].Value2.ToString(), "],"));
                    sWriter.WriteLine(ProcessConvert("          GhiAm : [", xlRange.Cells[i, 39].Value2.ToString(), "],"));
                    sWriter.WriteLine("          Radio :'" + xlRange.Cells[i, 40].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine(ProcessConvert("          XemPim : [", xlRange.Cells[i, 41].Value2.ToString(), "],"));
                    sWriter.WriteLine(ProcessConvert("          NgheNhac : [", xlRange.Cells[i, 42].Value2.ToString(), "],"));
                    sWriter.WriteLine("          ThoiDiemRaMat :'" + xlRange.Cells[i, 43].Value2.ToString() + "'," + "\t");
                    sWriter.WriteLine(ProcessConvert("          MauSac : [", xlRange.Cells[i, 44].Value2.ToString(), "],"));
                    sWriter.WriteLine("          Gia :'" + xlRange.Cells[i, 45].Value2.ToString() + "000'" + "\t");
                    sWriter.WriteLine("</Object>");
                    sWriter.Flush();
            }
            Console.Write("Done");
            Console.ReadKey();
        }
          
    }
              
}
