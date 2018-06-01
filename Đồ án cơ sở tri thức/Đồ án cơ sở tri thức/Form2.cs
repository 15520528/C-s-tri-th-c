using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Đồ_án_cơ_sở_tri_thức.KnowledgeBase;
namespace Đồ_án_cơ_sở_tri_thức
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(SmartPhone Phone)
        {
            InitializeComponent();
            //Màn Hình
            {
                //công nghệ màn hình
                {
                    Label CongNgheManHinh = new Label();
                    this.Controls.Add(CongNgheManHinh);
                    CongNgheManHinh.Location = new Point(500, label5.Location.Y);
                    CongNgheManHinh.AutoSize = true;
                    CongNgheManHinh.Text = Phone.CongNgheManHinh;
                    CongNgheManHinh.ForeColor = Color.FromArgb(0, 192, 192);
                    CongNgheManHinh.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    CongNgheManHinh.Cursor = Cursors.Hand;
                    CongNgheManHinh.Show();
                }

                //độ phân giải
                {
                    Label DoPG = new Label();
                    this.Controls.Add(DoPG);
                    DoPG.Location = new Point(500, label6.Location.Y);
                    DoPG.AutoSize = true;
                    DoPG.Text = Phone.DoPhanGiai;
                    DoPG.ForeColor = Color.FromArgb(0, 192, 192);
                    DoPG.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    DoPG.Cursor = Cursors.Hand;
                    DoPG.Show();
                }

                //độ màn hình rộng
                {
                    Label ManHR = new Label();
                    this.Controls.Add(ManHR);
                    ManHR.Location = new Point(500, label8.Location.Y);
                    ManHR.AutoSize = true;
                    ManHR.Text = Phone.ManHinhRong + " ''";
                    ManHR.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    ManHR.Cursor = Cursors.Hand;
                    ManHR.Show();
                }

                //mặt kính cảm ứng
                {
                    Label MatKCU = new Label();
                    this.Controls.Add(MatKCU);
                    MatKCU.Location = new Point(500, label7.Location.Y);
                    MatKCU.AutoSize = true;
                    MatKCU.Text = Phone.MatKinhCamUng;
                    MatKCU.ForeColor = Color.FromArgb(0, 192, 192);
                    MatKCU.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    MatKCU.Cursor = Cursors.Hand;
                    MatKCU.Show();
                }
            }

            //Camera Sau
            {
                //độ phân giải camera sau
                {
                    Label[] DoPGCameraSau = new Label[Phone.DoPhanGiaiCameraSau.Length];
                    int i = 0;
                    foreach (String doPG in Phone.DoPhanGiaiCameraSau)
                    {
                        DoPGCameraSau[i] = new Label();
                        this.Controls.Add(DoPGCameraSau[i]);
                        if (i == 0)
                        {
                            DoPGCameraSau[i].Location = new Point(500, label13.Location.Y);
                        }
                        else
                        {
                            int X = DoPGCameraSau[i - 1].Location.X + DoPGCameraSau[i - 1].Width + 2;
                            DoPGCameraSau[i].Location = new Point(X, label13.Location.Y);
                        }
                        DoPGCameraSau[i].AutoSize = true;
                        if (i == 0 && Phone.DoPhanGiaiCameraSau.Length > 1)
                        {
                            DoPGCameraSau[i].Text = doPG + " MP,";
                        }
                        else
                        {
                            DoPGCameraSau[i].Text = doPG + " MP";
                        }
                        DoPGCameraSau[i].Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                        DoPGCameraSau[i].Cursor = Cursors.Hand;
                        DoPGCameraSau[i].Show();
                        i++;
                    }
                }

                //quay phim
                {
                    Label[] QuayPhim = new Label[Phone.Quayphim.Length];
                    int i = 0;
                    foreach (String QP in Phone.Quayphim.Split(','))
                    {
                        QuayPhim[i] = new Label();
                        this.Controls.Add(QuayPhim[i]);
                        if (i == 0)
                        {
                            QuayPhim[i].Location = new Point(500, label12.Location.Y);
                        }
                        else
                        {
                            int X = QuayPhim[i - 1].Location.X + QuayPhim[i - 1].Width + 2;
                            QuayPhim[i].Location = new Point(X, label12.Location.Y);
                        }
                        QuayPhim[i].AutoSize = true;
                        if (i != Phone.Quayphim.Split(',').Length - 1)
                        {
                            QuayPhim[i].Text = QP + ", ";
                        }
                        else
                        {
                            QuayPhim[i].Text = QP;
                        }
                        QuayPhim[i].ForeColor = Color.FromArgb(0, 192, 192);
                        QuayPhim[i].Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                        QuayPhim[i].Cursor = Cursors.Hand;
                        QuayPhim[i].Show();
                        i++;
                    }
                }

                //mặt kính cảm ứng
                {
                    Label Flash = new Label();
                    this.Controls.Add(Flash);
                    Flash.Location = new Point(500, label10.Location.Y);
                    Flash.AutoSize = true;
                    Flash.Text = Phone.DenFlash;
                    Flash.ForeColor = Color.FromArgb(0, 192, 192);
                    Flash.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    Flash.Cursor = Cursors.Hand;
                    Flash.Show();
                }

                //chụp ảnh nâng cao
                {
                    Label[] ChupAnhNC = new Label[Phone.ChupAnhNangCao.Length];
                    int i = 0;
                    foreach (String str in Phone.ChupAnhNangCao)
                    {
                        ChupAnhNC[i] = new Label();
                        this.Controls.Add(ChupAnhNC[i]);
                        if (i == 0)
                        {
                            ChupAnhNC[i].Location = new Point(500, label11.Location.Y);
                        }
                        else
                        {
                            int X = ChupAnhNC[i - 1].Location.X + ChupAnhNC[i - 1].Width + 2;
                            ChupAnhNC[i].Location = new Point(X, label11.Location.Y);
                        }
                        ChupAnhNC[i].AutoSize = true;
                        if (i != Phone.ChupAnhNangCao.Length - 1)
                        {
                            ChupAnhNC[i].Text = str + ",";
                        }
                        else
                        {
                            ChupAnhNC[i].Text = str;
                        }
                        ChupAnhNC[i].ForeColor = Color.FromArgb(0, 192, 192);
                        ChupAnhNC[i].Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                        ChupAnhNC[i].Cursor = Cursors.Hand;
                        ChupAnhNC[i].Show();
                        i++;
                    }
                }
            }

            //Camera truóc
            {
                //độ phân giải camera trước
                {
                    Label DoPGCameraTruoc = new Label();
                    this.Controls.Add(DoPGCameraTruoc);
                    DoPGCameraTruoc.Location = new Point(500, label16.Location.Y);
                    DoPGCameraTruoc.AutoSize = true;
                    DoPGCameraTruoc.Text = Phone.DoPhanGiaiCameraTruoc;
                    DoPGCameraTruoc.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    DoPGCameraTruoc.Cursor = Cursors.Hand;
                    DoPGCameraTruoc.Show();
                }

                //video call
                {
                    Label VideoCall = new Label();
                    this.Controls.Add(VideoCall);
                    VideoCall.Location = new Point(500, label14.Location.Y);
                    VideoCall.AutoSize = true;
                    VideoCall.Text = Phone.Videocall;
                    VideoCall.ForeColor = Color.FromArgb(0, 192, 192);
                    VideoCall.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    VideoCall.Cursor = Cursors.Hand;
                    VideoCall.Show();
                }

                //Tính Năng Camera trước
                {
                    Label[] TinhNangCameraTruoc = new Label[Phone.TinhNangCameraTruoc.Length];
                    int i = 0;
                    foreach (String str in Phone.TinhNangCameraTruoc)
                    {
                        TinhNangCameraTruoc[i] = new Label();
                        this.Controls.Add(TinhNangCameraTruoc[i]);
                        if (i == 0)
                        {
                            TinhNangCameraTruoc[i].Location = new Point(500, label15.Location.Y);
                        }
                        else
                        {
                            int X = TinhNangCameraTruoc[i - 1].Location.X + TinhNangCameraTruoc[i - 1].Width + 2;
                            TinhNangCameraTruoc[i].Location = new Point(X, label15.Location.Y);
                        }
                        TinhNangCameraTruoc[i].AutoSize = true;
                        if (i != Phone.TinhNangCameraTruoc.Length - 1)
                        {
                            TinhNangCameraTruoc[i].Text = str + ",";
                        }
                        else
                        {
                            TinhNangCameraTruoc[i].Text = str;
                        }
                        TinhNangCameraTruoc[i].ForeColor = Color.FromArgb(0, 192, 192);
                        TinhNangCameraTruoc[i].Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                        TinhNangCameraTruoc[i].Cursor = Cursors.Hand;
                        TinhNangCameraTruoc[i].Show();
                        i++;
                    }
                }
            }
            
            //Hệ điều hành & CPU
            {
                //Hệ điều hành
                {
                    Label HeDieuHanh = new Label();
                    this.Controls.Add(HeDieuHanh);
                    HeDieuHanh.Location = new Point(500, label21.Location.Y);
                    HeDieuHanh.AutoSize = true;
                    HeDieuHanh.Text = Phone.HeDieuHanh;
                    HeDieuHanh.ForeColor = Color.FromArgb(0, 192, 192);
                    HeDieuHanh.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    HeDieuHanh.Cursor = Cursors.Hand;
                    HeDieuHanh.Show();
                }

                //chip set
                {
                    Label ChipSet = new Label();
                    this.Controls.Add(ChipSet);
                    ChipSet.Location = new Point(500, label20.Location.Y);
                    ChipSet.AutoSize = true;
                    ChipSet.Text = Phone.Chipset;
                    ChipSet.ForeColor = Color.FromArgb(0, 192, 192);
                    ChipSet.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    ChipSet.Cursor = Cursors.Hand;
                    ChipSet.Show();
                }

                //tốc độ cpu
                {
                    Label TocDoCPU = new Label();
                    this.Controls.Add(TocDoCPU);
                    TocDoCPU.Location = new Point(500, label18.Location.Y);
                    TocDoCPU.AutoSize = true;
                    TocDoCPU.Text = Phone.TocDoCPU;
                    TocDoCPU.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    TocDoCPU.Cursor = Cursors.Hand;
                    TocDoCPU.Show();
                }

                //chip đồ họa
                {
                    Label ChipDoHoa = new Label();
                    this.Controls.Add(ChipDoHoa);
                    ChipDoHoa.Location = new Point(500, label19.Location.Y);
                    ChipDoHoa.AutoSize = true;
                    ChipDoHoa.Text = Phone.ChipDoHoa;
                    ChipDoHoa.ForeColor = Color.FromArgb(0, 192, 192);
                    ChipDoHoa.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    ChipDoHoa.Cursor = Cursors.Hand;
                    ChipDoHoa.Show();
                }
            }

            //Bộ nhớ && lưu trữ
            {
                //Ram
                {
                    Label Ram = new Label();
                    this.Controls.Add(Ram);
                    Ram.Location = new Point(500, label26.Location.Y);
                    Ram.AutoSize = true;
                    Ram.Text = Phone.Ram + " GB";
                    Ram.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    Ram.Cursor = Cursors.Hand;
                    Ram.Show();
                }

                //Bộ nhớ trong
                {
                    Label BoNhoTrong = new Label();
                    this.Controls.Add(BoNhoTrong);
                    BoNhoTrong.Location = new Point(500, label25.Location.Y);
                    BoNhoTrong.AutoSize = true;
                    BoNhoTrong.Text = Phone.BoNhoTrong + " GB";
                    BoNhoTrong.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    BoNhoTrong.Cursor = Cursors.Hand;
                    BoNhoTrong.Show();
                }

                //Bộ nhớ còn lại
                {
                    Label BoNhoConLai = new Label();
                    this.Controls.Add(BoNhoConLai);
                    BoNhoConLai.Location = new Point(500, label23.Location.Y);
                    BoNhoConLai.AutoSize = true;
                    BoNhoConLai.Text = Phone.BoNhoConLai + " GB";
                    BoNhoConLai.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    BoNhoConLai.Cursor = Cursors.Hand;
                    BoNhoConLai.Show();
                }

                //Thẻ nhớ ngoài
                {
                    Label TheNhoNgoai = new Label();
                    this.Controls.Add(TheNhoNgoai);
                    TheNhoNgoai.Location = new Point(500, label24.Location.Y);
                    TheNhoNgoai.AutoSize = true;
                    TheNhoNgoai.Text = Phone.TheNhoNgoai + " GB";
                    TheNhoNgoai.ForeColor = Color.FromArgb(0, 192, 192);
                    TheNhoNgoai.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    TheNhoNgoai.Cursor = Cursors.Hand;
                    TheNhoNgoai.Show();
                }
            }

            //Kết nối
            {
                //Mạng di động
                {
                    Label[] MangDiDong = new Label[Phone.MangDiDong.Length];
                    int i = 0;
                    foreach (String str in Phone.MangDiDong)
                    {
                        MangDiDong[i] = new Label();
                        this.Controls.Add(MangDiDong[i]);
                        if (i == 0)
                        {
                            MangDiDong[i].Location = new Point(500, label31.Location.Y);
                        }
                        else
                        {
                            int X = MangDiDong[i - 1].Location.X + MangDiDong[i - 1].Width + 2;
                            MangDiDong[i].Location = new Point(X, label31.Location.Y);
                        }
                        MangDiDong[i].AutoSize = true;
                        if (i != Phone.MangDiDong.Length - 1)
                        {
                            MangDiDong[i].Text = str + ",";
                        }
                        else
                        {
                            MangDiDong[i].Text = str;
                        }
                        MangDiDong[i].ForeColor = Color.FromArgb(0, 192, 192);
                        MangDiDong[i].Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                        MangDiDong[i].Cursor = Cursors.Hand;
                        MangDiDong[i].Show();
                        i++;
                    }
                }

                //Sim
                {
                    Label Sim = new Label();
                    this.Controls.Add(Sim);
                    Sim.Location = new Point(500, label30.Location.Y);
                    Sim.AutoSize = true;
                    Sim.Text = Phone.Sim + " Nano Sim";
                    Sim.ForeColor = Color.FromArgb(0, 192, 192);
                    Sim.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    Sim.Cursor = Cursors.Hand;
                    Sim.Show();
                }

                //Wifi
                {
                    Label[] Wifi = new Label[Phone.Wifi.Length];
                    int i = 0;
                    foreach (String str in Phone.Wifi)
                    {
                        Wifi[i] = new Label();
                        this.Controls.Add(Wifi[i]);
                        if (i == 0)
                        {
                            Wifi[i].Location = new Point(500, label28.Location.Y);
                        }
                        else
                        {
                            int X = Wifi[i - 1].Location.X + Wifi[i - 1].Width + 2;
                            Wifi[i].Location = new Point(X, label28.Location.Y);
                        }
                        Wifi[i].AutoSize = true;
                        if (i != Phone.Wifi.Length - 1)
                        {
                            Wifi[i].Text = str + ",";
                        }
                        else
                        {
                            Wifi[i].Text = str;
                        }
                        Wifi[i].ForeColor = Color.FromArgb(0, 192, 192);
                        Wifi[i].Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                        Wifi[i].Cursor = Cursors.Hand;
                        Wifi[i].Show();
                        i++;
                    }
                }

                //GPS
                {
                    Label[] GPS = new Label[Phone.GPS.Length];
                    int i = 0;
                    foreach (String str in Phone.GPS)
                    {
                        GPS[i] = new Label();
                        this.Controls.Add(GPS[i]);
                        if (i == 0)
                        {
                            GPS[i].Location = new Point(500, label29.Location.Y);
                        }
                        else
                        {
                            int X = GPS[i - 1].Location.X + GPS[i - 1].Width + 2;
                            GPS[i].Location = new Point(X, label29.Location.Y);
                        }
                        GPS[i].AutoSize = true;
                        if (i != Phone.GPS.Length - 1)
                        {
                            GPS[i].Text = str + ",";
                        }
                        else
                        {
                            GPS[i].Text = str;
                        }
                        GPS[i].ForeColor = Color.FromArgb(0, 192, 192);
                        GPS[i].Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                        GPS[i].Cursor = Cursors.Hand;
                        GPS[i].Show();
                        i++;
                    }
                }

                //Bluetooth
                {
                    Label[] Bluetooth = new Label[Phone.Bluetooth.Length];
                    int i = 0;
                    foreach (String str in Phone.Bluetooth)
                    {
                        Bluetooth[i] = new Label();
                        this.Controls.Add(Bluetooth[i]);
                        if (i == 0)
                        {
                            Bluetooth[i].Location = new Point(500, label36.Location.Y);
                        }
                        else
                        {
                            int X = Bluetooth[i - 1].Location.X + Bluetooth[i - 1].Width + 2;
                            Bluetooth[i].Location = new Point(X, label36.Location.Y);
                        }
                        Bluetooth[i].AutoSize = true;
                        if (i != Phone.Bluetooth.Length - 1)
                        {
                            Bluetooth[i].Text = str + ",";
                        }
                        else
                        {
                            Bluetooth[i].Text = str;
                        }
                        Bluetooth[i].ForeColor = Color.FromArgb(0, 192, 192);
                        Bluetooth[i].Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                        Bluetooth[i].Cursor = Cursors.Hand;
                        Bluetooth[i].Show();
                        i++;
                    }
                }

                //Cổng thiết kế/ sạc
                {
                    Label CongKetNoi_Sac = new Label();
                    this.Controls.Add(CongKetNoi_Sac);
                    CongKetNoi_Sac.Location = new Point(500, label35.Location.Y);
                    CongKetNoi_Sac.AutoSize = true;
                    CongKetNoi_Sac.Text = Phone.CongKetNoi_Sac;
                    CongKetNoi_Sac.ForeColor = Color.FromArgb(0, 192, 192);
                    CongKetNoi_Sac.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    CongKetNoi_Sac.Cursor = Cursors.Hand;
                    CongKetNoi_Sac.Show();
                }

                //Jack tai nghe
                {
                    Label JackTaiNghe = new Label();
                    this.Controls.Add(JackTaiNghe);
                    JackTaiNghe.Location = new Point(500, label33.Location.Y);
                    JackTaiNghe.AutoSize = true;
                    JackTaiNghe.Text = Phone.JackTaiNghe;
                    JackTaiNghe.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    JackTaiNghe.Cursor = Cursors.Hand;
                    JackTaiNghe.Show();
                }

                //Kết nối khác
                {
                    Label[] KetNoiKhac = new Label[Phone.KetNoiKhac.Length];
                    int i = 0;
                    foreach (String str in Phone.KetNoiKhac)
                    {
                        KetNoiKhac[i] = new Label();
                        this.Controls.Add(KetNoiKhac[i]);
                        if (i == 0)
                        {
                            KetNoiKhac[i].Location = new Point(500, label34.Location.Y);
                        }
                        else
                        {
                            int X = KetNoiKhac[i - 1].Location.X + KetNoiKhac[i - 1].Width + 2;
                            KetNoiKhac[i].Location = new Point(X, label34.Location.Y);
                        }
                        KetNoiKhac[i].AutoSize = true;
                        if (i != Phone.KetNoiKhac.Length - 1)
                        {
                            KetNoiKhac[i].Text = str + ",";
                        }
                        else
                        {
                            KetNoiKhac[i].Text = str;
                        }
                        KetNoiKhac[i].ForeColor = Color.FromArgb(0, 192, 192);
                        KetNoiKhac[i].Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                        KetNoiKhac[i].Cursor = Cursors.Hand;
                        KetNoiKhac[i].Show();
                        i++;
                    }
                }
            }

            //Thiết kế & Trọng lượng
            {
                //Thiết kế
                {
                    Label[] ThietKe = new Label[Phone.ThietKe.Length];
                    int i = 0;
                    foreach (String str in Phone.ThietKe)
                    {
                        ThietKe[i] = new Label();
                        this.Controls.Add(ThietKe[i]);
                        if (i == 0)
                        {
                            ThietKe[i].Location = new Point(500, label40.Location.Y);
                        }
                        else
                        {
                            int X = ThietKe[i - 1].Location.X + ThietKe[i - 1].Width + 2;
                            ThietKe[i].Location = new Point(X, label40.Location.Y);
                        }
                        ThietKe[i].AutoSize = true;
                        if (i != Phone.ThietKe.Length - 1)
                        {
                            ThietKe[i].Text = str + ",";
                        }
                        else
                        {
                            ThietKe[i].Text = str;
                        }
                        ThietKe[i].ForeColor = Color.FromArgb(0, 192, 192);
                        ThietKe[i].Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                        ThietKe[i].Cursor = Cursors.Hand;
                        ThietKe[i].Show();
                        i++;
                    }
                }

                //chất liệu
                {
                    Label ChatLieu = new Label();
                    this.Controls.Add(ChatLieu);
                    ChatLieu.Location = new Point(500, label39.Location.Y);
                    ChatLieu.AutoSize = true;
                    ChatLieu.Text = string.Join(",", Phone.ChatLieu);
                    ChatLieu.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    ChatLieu.Cursor = Cursors.Hand;
                    ChatLieu.Show();
                }

                //kích thước
                {
                    Label KichThuoc = new Label();
                    this.Controls.Add(KichThuoc);
                    KichThuoc.Location = new Point(500, label37.Location.Y);
                    KichThuoc.AutoSize = true;
                    KichThuoc.Text = Phone.KichThuoc;
                    KichThuoc.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    KichThuoc.Cursor = Cursors.Hand;
                    KichThuoc.Show();
                }

                //Trọng lượng
                {
                    Label TrongLuong = new Label();
                    this.Controls.Add(TrongLuong);
                    TrongLuong.Location = new Point(500, label38.Location.Y);
                    TrongLuong.AutoSize = true;
                    TrongLuong.Text = Phone.TrongLuong;
                    TrongLuong.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    TrongLuong.Cursor = Cursors.Hand;
                    TrongLuong.Show();
                }
            }

            //Thông tin pin & sạc
            {
                //Dung lượng pin
                {
                    Label DungLuongPin = new Label();
                    this.Controls.Add(DungLuongPin);
                    DungLuongPin.Location = new Point(500, label44.Location.Y);
                    DungLuongPin.AutoSize = true;
                    DungLuongPin.Text = Phone.DungLuongPin;
                    DungLuongPin.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    DungLuongPin.Cursor = Cursors.Hand;
                    DungLuongPin.Show();
                }

                //Loại pin
                {
                    Label LoaiPin = new Label();
                    this.Controls.Add(LoaiPin);
                    LoaiPin.Location = new Point(500, label43.Location.Y);
                    LoaiPin.AutoSize = true;
                    LoaiPin.Text = Phone.LoaiPin;
                    LoaiPin.ForeColor = Color.FromArgb(0, 192, 192);
                    LoaiPin.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    LoaiPin.Cursor = Cursors.Hand;
                    LoaiPin.Show();
                }

                //Công nghệ pin
                {
                    Label[] CongNghePin = new Label[Phone.CongNghePin.Length];
                    int i = 0;
                    foreach (String str in Phone.CongNghePin)
                    {
                        CongNghePin[i] = new Label();
                        this.Controls.Add(CongNghePin[i]);
                        if (i == 0)
                        {
                            CongNghePin[i].Location = new Point(500, label42.Location.Y);
                        }
                        else
                        {
                            int X = CongNghePin[i - 1].Location.X + CongNghePin[i - 1].Width + 2;
                            CongNghePin[i].Location = new Point(X, label42.Location.Y);
                        }
                        CongNghePin[i].AutoSize = true;
                        if (i != Phone.CongNghePin.Length - 1)
                        {
                            CongNghePin[i].Text = str + ",";
                        }
                        else
                        {
                            CongNghePin[i].Text = str;
                        }
                        CongNghePin[i].ForeColor = Color.FromArgb(0, 192, 192);
                        CongNghePin[i].Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                        CongNghePin[i].Cursor = Cursors.Hand;
                        CongNghePin[i].Show();
                        i++;
                    }
                }
            }

            //Tiện ích
            {
                //bảo mật nâng cao
                {
                    Label[] BaoMatNangCao = new Label[Phone.BaoMatNangCao.Length];
                    int i = 0;
                    foreach (String str in Phone.BaoMatNangCao)
                    {
                        BaoMatNangCao[i] = new Label();
                        this.Controls.Add(BaoMatNangCao[i]);
                        if (i == 0)
                        {
                            BaoMatNangCao[i].Location = new Point(500, label48.Location.Y);
                        }
                        else
                        {
                            int X = BaoMatNangCao[i - 1].Location.X + BaoMatNangCao[i - 1].Width + 2;
                            BaoMatNangCao[i].Location = new Point(X, label48.Location.Y);
                        }
                        BaoMatNangCao[i].AutoSize = true;
                        if (i != Phone.BaoMatNangCao.Length - 1)
                        {
                            BaoMatNangCao[i].Text = str + ",";
                        }
                        else
                        {
                            BaoMatNangCao[i].Text = str;
                        }
                        BaoMatNangCao[i].ForeColor = Color.FromArgb(0, 192, 192);
                        BaoMatNangCao[i].Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                        BaoMatNangCao[i].Cursor = Cursors.Hand;
                        BaoMatNangCao[i].Show();
                        i++;
                    }
                }

                //Tính năng đặc biết
                {
                    Label[] TinhNangDacBiet = new Label[Phone.TinhNangDacBiet.Length];
                    int i = 0;
                    foreach (String str in Phone.TinhNangDacBiet)
                    {
                        TinhNangDacBiet[i] = new Label();
                        this.Controls.Add(TinhNangDacBiet[i]);
                        if (i == 0)
                        {
                            TinhNangDacBiet[i].Location = new Point(500, label47.Location.Y);
                        }
                        else
                        {
                            int X = TinhNangDacBiet[i - 1].Location.X + TinhNangDacBiet[i - 1].Width + 2;
                            TinhNangDacBiet[i].Location = new Point(X, label47.Location.Y);
                        }
                        TinhNangDacBiet[i].AutoSize = true;
                        if (i != Phone.TinhNangDacBiet.Length - 1)
                        {
                            TinhNangDacBiet[i].Text = str + ",";
                        }
                        else
                        {
                            TinhNangDacBiet[i].Text = str;
                        }
                        TinhNangDacBiet[i].ForeColor = Color.FromArgb(0, 192, 192);
                        TinhNangDacBiet[i].Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                        TinhNangDacBiet[i].Cursor = Cursors.Hand;
                        TinhNangDacBiet[i].Show();
                        i++;
                    }
                }

                //Ghi âm
                {
                    Label[] GhiAm = new Label[Phone.GhiAm.Length];
                    int i = 0;
                    foreach (String str in Phone.GhiAm)
                    {
                        GhiAm[i] = new Label();
                        this.Controls.Add(GhiAm[i]);
                        if (i == 0)
                        {
                            GhiAm[i].Location = new Point(500, label46.Location.Y);
                        }
                        else
                        {
                            int X = GhiAm[i - 1].Location.X + GhiAm[i - 1].Width + 2;
                            GhiAm[i].Location = new Point(X, label46.Location.Y);
                        }
                        GhiAm[i].AutoSize = true;
                        if (i != Phone.GhiAm.Length - 1)
                        {
                            GhiAm[i].Text = str + ",";
                        }
                        else
                        {
                            GhiAm[i].Text = str;
                        }
                        GhiAm[i].ForeColor = Color.FromArgb(0, 192, 192);
                        GhiAm[i].Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                        GhiAm[i].Cursor = Cursors.Hand;
                        GhiAm[i].Show();
                        i++;
                    }
                }

                //Radio
                {
                    Label Radio = new Label();
                    this.Controls.Add(Radio);
                    Radio.Location = new Point(500, label52.Location.Y);
                    Radio.AutoSize = true;
                    Radio.Text = Phone.Radio;
                    Radio.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                    Radio.Cursor = Cursors.Hand;
                    Radio.Show();
                }

                //Xem Phim
                {
                    Label[] XemPhim = new Label[Phone.XemPhim.Length];
                    int i = 0;
                    foreach (String str in Phone.XemPhim)
                    {
                        XemPhim[i] = new Label();
                        this.Controls.Add(XemPhim[i]);
                        if (i == 0)
                        {
                            XemPhim[i].Location = new Point(500, label51.Location.Y);
                        }
                        else
                        {
                            int X = XemPhim[i - 1].Location.X + XemPhim[i - 1].Width + 2;
                            XemPhim[i].Location = new Point(X, label51.Location.Y);
                        }
                        XemPhim[i].AutoSize = true;
                        if (i != Phone.XemPhim.Length - 1)
                        {
                            XemPhim[i].Text = str + ",";
                        }
                        else
                        {
                            XemPhim[i].Text = str;
                        }
                        XemPhim[i].ForeColor = Color.FromArgb(0, 192, 192);
                        XemPhim[i].Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                        XemPhim[i].Cursor = Cursors.Hand;
                        XemPhim[i].Show();
                        i++;
                    }
                }

                //Nghe nhạc
                {
                    Label[] NgheNhac = new Label[Phone.NgheNhac.Length];
                    int i = 0;
                    foreach (String str in Phone.NgheNhac)
                    {
                        NgheNhac[i] = new Label();
                        this.Controls.Add(NgheNhac[i]);
                        if (i == 0)
                        {
                            NgheNhac[i].Location = new Point(500, label50.Location.Y);
                        }
                        else
                        {
                            int X = NgheNhac[i - 1].Location.X + NgheNhac[i - 1].Width + 2;
                            NgheNhac[i].Location = new Point(X, label50.Location.Y);
                        }
                        NgheNhac[i].AutoSize = true;
                        if (i != Phone.NgheNhac.Length - 1)
                        {
                            NgheNhac[i].Text = str + ",";
                        }
                        else
                        {
                            NgheNhac[i].Text = str;
                        }
                        NgheNhac[i].ForeColor = Color.FromArgb(0, 192, 192);
                        NgheNhac[i].Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                        NgheNhac[i].Cursor = Cursors.Hand;
                        NgheNhac[i].Show();
                        i++;
                    }
                }

                
            }

            //Thời điểm ra mắt
            {
                Label ThoiDiemRaMat = new Label();
                this.Controls.Add(ThoiDiemRaMat);
                ThoiDiemRaMat.Location = new Point(500, label54.Location.Y);
                ThoiDiemRaMat.AutoSize = true;
                ThoiDiemRaMat.Text = Phone.ThoiDiemRaMat;
                ThoiDiemRaMat.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                ThoiDiemRaMat.Cursor = Cursors.Hand;
                ThoiDiemRaMat.Show();
            }
        }
    }
}
