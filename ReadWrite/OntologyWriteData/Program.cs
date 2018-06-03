using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.IO;

namespace OntologyWriteData
{
    class Program
    {

        //public static string ProcessConvert(string str)
        //{
        //    return str.Replace(" ", "_");
        //}
        static void Main(string[] args)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\Wind\Documents\visual studio 2013\Projects\ReadWrite\OntologyWriteData\bin\Debug\Database.xlsx");
            Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.Sheets.get_Item(1);
            Excel.Range xlRange = xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            string pathtxt = @"C:\Users\Wind\Documents\visual studio 2013\Projects\ReadWrite\OntologyWriteData\bin\Debug\database.owl";
            FileStream fs = new FileStream(pathtxt, FileMode.Create);
            StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);
            Dictionary<int, string> DienThoai = new Dictionary<int, string>(); ;
           sWriter.WriteLine("<rdf:RDF ");
                sWriter.WriteLine("xmlns=\"#\"");
                sWriter.WriteLine("xml:base=\"#\"");
                sWriter.WriteLine("xmlns:rdf=\"#\"");
                sWriter.WriteLine("xmlns:owl=\"#\"");
                sWriter.WriteLine("xmlns:xml= \"http://www.w3.org/XML/1998/namespace\" ");
                sWriter.WriteLine("xmlns:xsd=\"#\"");
                sWriter.WriteLine("xmlns:rdfs=\"#\">");
            for (int i = 2; i <= rowCount; i++)// Row
            {

                sWriter.WriteLine(" <owl:NamedIndividual rdf:about=\"urn:absolute:#" + xlRange.Cells[i, 2].Value2.ToString().Replace(" ","_") + "\">");
                sWriter.WriteLine("   <TenDienThoai rdf:datatype=\"#string\">" + xlRange.Cells[i, 2].Value2.ToString() + "</TenDienThoai>");
                sWriter.WriteLine("   <HangSanXuat rdf:datatype=\"#string\">" + xlRange.Cells[i, 46].Value2.ToString() + "</HangSanXuat>");
                sWriter.WriteLine("   <LoaiDienThoai rdf:datatype=\"#string\">" + xlRange.Cells[i, 47].Value2.ToString() + "</LoaiDienThoai>");
                sWriter.WriteLine("   <CongNgheManHinh rdf:datatype=\"#string\">" + xlRange.Cells[i, 3].Value2.ToString() + "</CongNgheManHinh>");
                sWriter.WriteLine("   <DoPhanGiai rdf:datatype=\"#string\">" + xlRange.Cells[i, 4].Value2.ToString() + "</DoPhanGiai>");
                sWriter.WriteLine("   <ManHinhRong rdf:datatype=\"#string\">" + xlRange.Cells[i, 5].Value2.ToString() + "</ManHinhRong>");
                sWriter.WriteLine("   <MatKinhCamUng rdf:datatype=\"#string\">" + xlRange.Cells[i, 6].Value2.ToString() + "</MatKinhCamUng>");
                sWriter.WriteLine("   <DoPhanGiaiCameraSau rdf:datatype=\"#string\">" + xlRange.Cells[i, 7].Value2.ToString() + "</DoPhanGiaiCameraSau>");
                sWriter.WriteLine("   <Quayphim rdf:datatype=\"#string\">" + xlRange.Cells[i, 8].Value2.ToString() + "</Quayphim>");
                sWriter.WriteLine("   <DenFlash rdf:datatype=\"#string\">" + xlRange.Cells[i, 9].Value2.ToString() + "</DenFlash>");
                sWriter.WriteLine("   <ChupAnhNangCao rdf:datatype=\"#string\">" + xlRange.Cells[i, 10].Value2.ToString() + "</ChupAnhNangCao>");
                sWriter.WriteLine("   <DoPhanGiaiCameraTruoc rdf:datatype=\"#string\">" + xlRange.Cells[i, 11].Value2.ToString() + "</DoPhanGiaiCameraTruoc>");
                sWriter.WriteLine("   <Videocall rdf:datatype=\"#string\">" + xlRange.Cells[i, 12].Value2.ToString() + "</Videocall>");
                sWriter.WriteLine("   <TinhNangCameraTruoc rdf:datatype=\"#string\">" + xlRange.Cells[i, 13].Value2.ToString() + "</TinhNangCameraTruoc>");
                sWriter.WriteLine("   <HeDieuHanh rdf:datatype=\"#string\">" + xlRange.Cells[i, 14].Value2.ToString() + "</HeDieuHanh>");
                sWriter.WriteLine("   <Chipset rdf:datatype=\"#string\">" + xlRange.Cells[i, 15].Value2.ToString() + "</Chipset>");
                sWriter.WriteLine("   <TocDoCPU rdf:datatype=\"#string\">" + xlRange.Cells[i, 16].Value2.ToString() + "</TocDoCPU>");
                sWriter.WriteLine("   <ChipDoHoa rdf:datatype=\"#string\">" + xlRange.Cells[i, 17].Value2.ToString() + "</ChipDoHoa>");
                sWriter.WriteLine("   <RAM rdf:datatype=\"#string\">" + xlRange.Cells[i, 18].Value2.ToString() + "</RAM>");
                sWriter.WriteLine("   <BoNhoTrong rdf:datatype=\"#string\">" + xlRange.Cells[i, 19].Value2.ToString() + "</BoNhoTrong>");
                sWriter.WriteLine("   <BoNhoConLai rdf:datatype=\"#string\">" + xlRange.Cells[i, 20].Value2.ToString() + "</BoNhoConLai>");
                sWriter.WriteLine("   <TheNhoNgoai rdf:datatype=\"#string\">" + xlRange.Cells[i, 21].Value2.ToString() + "</TheNhoNgoai>");
                sWriter.WriteLine("   <MangDiDong rdf:datatype=\"#string\">" + xlRange.Cells[i, 22].Value2.ToString() + "</MangDiDong>");
                sWriter.WriteLine("   <SIM rdf:datatype=\"#string\">" + xlRange.Cells[i, 23].Value2.ToString() + "</SIM>");
                sWriter.WriteLine("   <Wifi rdf:datatype=\"#string\">" + xlRange.Cells[i, 24].Value2.ToString() + "</Wifi>");
                sWriter.WriteLine("   <GPS rdf:datatype=\"#string\">" + xlRange.Cells[i, 25].Value2.ToString() + "</GPS>");
                sWriter.WriteLine("   <Bluetooth rdf:datatype=\"#string\">" + xlRange.Cells[i, 26].Value2.ToString() + "</Bluetooth>");
                sWriter.WriteLine("   <CongKetNoi_Sac rdf:datatype=\"#string\">" + xlRange.Cells[i, 27].Value2.ToString() + "</CongKetNoi_Sac>");
                sWriter.WriteLine("   <JackTaiNghe rdf:datatype=\"#string\">" + xlRange.Cells[i, 28].Value2.ToString() + "</JackTaiNghe>");
                sWriter.WriteLine("   <KetNoiKhac rdf:datatype=\"#string\">" + xlRange.Cells[i, 29].Value2.ToString() + "</KetNoiKhac>");
                sWriter.WriteLine("   <ThietKe rdf:datatype=\"#string\">" + xlRange.Cells[i, 30].Value2.ToString() + "</ThietKe>");
                sWriter.WriteLine("   <ChatLieu rdf:datatype=\"#string\">" + xlRange.Cells[i, 31].Value2.ToString() + "</ChatLieu>");
                sWriter.WriteLine("   <KichThuoc rdf:datatype=\"#string\">" + xlRange.Cells[i, 32].Value2.ToString() + "</KichThuoc>");
                sWriter.WriteLine("   <TrongLuong rdf:datatype=\"#string\">" + xlRange.Cells[i, 33].Value2.ToString() + "</TrongLuong>");
                sWriter.WriteLine("   <DungLuongPin rdf:datatype=\"#string\">" + xlRange.Cells[i, 34].Value2.ToString() + "</DungLuongPin>");
                sWriter.WriteLine("   <LoaiPin rdf:datatype=\"#string\">" + xlRange.Cells[i, 35].Value2.ToString() + "</LoaiPin>");
                sWriter.WriteLine("   <CongNghePin rdf:datatype=\"#string\">" + xlRange.Cells[i, 36].Value2.ToString() + "</CongNghePin>");
                sWriter.WriteLine("   <BaoMatNangCao rdf:datatype=\"#string\">" + xlRange.Cells[i, 37].Value2.ToString() + "</BaoMatNangCao>");
                sWriter.WriteLine("   <TinhNangDacBiet rdf:datatype=\"#string\">" + xlRange.Cells[i, 38].Value2.ToString() + "</TinhNangDacBiet>");
                sWriter.WriteLine("   <GhiAm rdf:datatype=\"#string\">" + xlRange.Cells[i, 39].Value2.ToString() + "</GhiAm>");
                sWriter.WriteLine("   <Radio rdf:datatype=\"#string\">" + xlRange.Cells[i, 40].Value2.ToString() + "</Radio>");
                sWriter.WriteLine("   <XemPim rdf:datatype=\"#string\">" + xlRange.Cells[i, 41].Value2.ToString() + "</XemPim>");
                sWriter.WriteLine("   <NgheNhac rdf:datatype=\"#string\">" + xlRange.Cells[i, 42].Value2.ToString() + "</NgheNhac>");
                sWriter.WriteLine("   <ThoiDiemRaMat rdf:datatype=\"#string\">" + xlRange.Cells[i, 43].Value2.ToString() + "</ThoiDiemRaMat>");
                sWriter.WriteLine("   <MauSac rdf:datatype=\"#string\">" + xlRange.Cells[i, 44].Value2.ToString() + "</MauSac>");
                sWriter.WriteLine("   <Gia rdf:datatype=\"#string\">" + xlRange.Cells[i, 45].Value2.ToString() + "000</Gia>");
                sWriter.WriteLine(" </owl:NamedIndividual>");
                sWriter.Flush();
            }
            sWriter.WriteLine("</rdf:RDF>");
            sWriter.Flush();
            Console.Write("Done");
            Console.ReadKey();
        }

    }
}
