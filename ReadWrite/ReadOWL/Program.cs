﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace ReadOWL
{
    class Program
    {

        static void Main(string[] args)
        {
            
            using (XmlReader reader = XmlReader.Create(@"C:\Users\nhoxe\OneDrive\Documents\GitHub\C-s-tri-th-c\Cấu trúc hệ tư vấn mua điện thoại.owl"))
            while(reader.Read())
            {
                if(reader.IsStartElement())
                {
                    switch (reader.Name.ToString())
                    {
                            case "absolute:DiaChi":
                                Console.WriteLine(reader.ReadElementContentAsString());
                                break;
                            case "HangSanXuat":
                                String HangSanXuat = reader.ReadElementContentAsString();
                                break;
                            case "LoaiDienThoai":
                                String LoaiDienThoai = reader.ReadElementContentAsString();
                                break;
                            case "CongNgheManHinh":
                                String CongNgheManHinh = reader.ReadElementContentAsString();
                                break;
                            case "DoPhanGiai":
                                String DoPhanGiai = reader.ReadElementContentAsString();
                                break;
                            case "ManHinhRong":
                                String ManHinhRong = reader.ReadElementContentAsString();
                                break;
                            case "MatKinhCamUng":
                                String MatKinhCamUng = reader.ReadElementContentAsString();
                                break;
                            case "DoPhanGiaiCameraSau":
                                String DoPhanGiaiCameraSau = reader.ReadElementContentAsString();
                                break;
                            case "Quayphim":
                                String Quayphim = reader.ReadElementContentAsString();
                                break;
                            case "DenFlash":
                                String DenFlash = reader.ReadElementContentAsString();
                                break;
                            case "ChupAnhNangCao":
                                String ChupAnhNangCao = reader.ReadElementContentAsString();
                                break;
                            case "DoPhanGiaiCameraTruoc":
                                String DoPhanGiaiCameraTruoc = reader.ReadElementContentAsString();
                                break;
                            case "Videocall":
                                String Videocall = reader.ReadElementContentAsString();
                                break;
                            case "TinhNangCameraTruoc":
                                String TinhNangCameraTruoc = reader.ReadElementContentAsString();
                                break;
                            case "HeDieuHanh":
                                String HeDieuHanh = reader.ReadElementContentAsString();
                                break;
                            case "Chipset":
                                String Chipset = reader.ReadElementContentAsString();
                                break;
                            case "TocDoCPU":
                                String TocDoCPU = reader.ReadElementContentAsString();
                                break;
                            case "ChipDoHoa":
                                String ChipDoHoa = reader.ReadElementContentAsString();
                                break;
                            case "RAM":
                                String RAM = reader.ReadElementContentAsString();
                                break;
                            case "BoNhoTrong":
                                String BoNhoTrong = reader.ReadElementContentAsString();
                                break;
                            case "BoNhoConLai":
                                String BoNhoConLai = reader.ReadElementContentAsString();
                                break;
                            case "TheNhoNgoai":
                                String TheNhoNgoai = reader.ReadElementContentAsString();
                                break;
                            case "MangDiDong":
                                String MangDiDong = reader.ReadElementContentAsString();
                                break;
                            case "SIM":
                                String SIM = reader.ReadElementContentAsString();
                                break;
                            case "Wifi":
                                String Wifi = reader.ReadElementContentAsString();
                                break;
                            case "GPS":
                                String GPS = reader.ReadElementContentAsString();
                                break;
                            case "Bluetooth":
                                String Bluetooth = reader.ReadElementContentAsString();
                                break;
                            case "CongKetNoi_Sac":
                                String CongKetNoi_Sac = reader.ReadElementContentAsString();
                                break;
                            case "JackTaiNghe":
                                String JackTaiNghe = reader.ReadElementContentAsString();
                                break;
                            case "KetNoiKhac":
                                String KetNoiKhac = reader.ReadElementContentAsString();
                                break;
                            case "ThietKe":
                                String ThietKe = reader.ReadElementContentAsString();
                                break;
                            case "ChatLieu":
                                String ChatLieu = reader.ReadElementContentAsString();
                                break;
                            case "KichThuoc":
                                String KichThuoc = reader.ReadElementContentAsString();
                                break;
                            case "TrongLuong":
                                String TrongLuong = reader.ReadElementContentAsString();
                                break;
                            case "DungLuongPin":
                                String DungLuongPin = reader.ReadElementContentAsString();
                                break;
                            case "LoaiPin":
                                String LoaiPin = reader.ReadElementContentAsString();
                                break;
                            case "CongNghePin":
                                String CongNghePin = reader.ReadElementContentAsString();
                                break;
                            case "BaoMatNangCao":
                                String BaoMatNangCao = reader.ReadElementContentAsString();
                                break;
                            case "TinhNangDacBiet":
                                String TinhNangDacBiet = reader.ReadElementContentAsString();
                                break;
                            case "GhiAm":
                                String GhiAm = reader.ReadElementContentAsString();
                                break;
                            case "Radio":
                                String Radio = reader.ReadElementContentAsString();
                                break;
                            case "XemPhim":
                                String XemPhim = reader.ReadElementContentAsString();
                                break;
                            case "NgheNhac":
                                String NgheNhac = reader.ReadElementContentAsString();
                                break;
                            case "ThoiDiemRaMat":
                                String ThoiDiemRaMat = reader.ReadElementContentAsString();
                                break;
                            case "MauSac":
                                String MauSac = reader.ReadElementContentAsString();
                                break;
                            case "Gia": String Gia = reader.ReadElementContentAsString();
                                break;
                        }
                     
                }

            }       
            Console.ReadKey();
        }
    }
}