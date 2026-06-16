using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using Timer = System.Windows.Forms.Timer;

namespace ToanRoiRac_LNMH_LQH
{
    public partial class Form1 : Form
    {
        enum CheDo
        {
            KhongCo,
            ThemDinh,
            ThemCanh,
            ChonDinhBatDau
        }

        CheDo cheDoHienTai = CheDo.KhongCo;

        List<Dinh> danhSachDinh = new List<Dinh>();
        List<Canh> danhSachCanh = new List<Canh>();
        List<BuocHamilton> danhSachBuocHamilton = new List<BuocHamilton>();
        Timer timerHamilton = new Timer();

        int chiSoBuocHamilton = 0;
        int chuTrinhDangXem = -1;

        bool dangTimHamilton = false;
        bool daKetThucHamilton = false;

        List<List<Dinh>> danhSachChuTrinhTimDuoc = new List<List<Dinh>>();

        Dinh? dinhDangChon = null;
        Dinh? dinhThuHai = null;
        Dinh? dinhBatDau = null;
        Dinh? dinhDangXetHamilton = null;
        List<Dinh> duongDiHienTai = new List<Dinh>();
        private string LayTenDinhMoi()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                bool daTonTai =
                    danhSachDinh.Any(
                        d => d.Ten == c.ToString());

                if (!daTonTai)
                {
                    return c.ToString();
                }
            }

            return "?";
        }

        private void ThemThongBao(string noiDung)
        {
            lstThongBao.Items.Add(noiDung);

            lstThongBao.TopIndex =
                lstThongBao.Items.Count - 1;
        }

        private void CapNhatDuongDi()
        {
            lstDuongDi.Items.Clear();

            if (duongDiHienTai.Count == 0)
            {
                lstDuongDi.Items.Add("∅");
                return;
            }

            const int SO_DINH_MOI_DONG = 100;

            for (int i = 0;
                 i < duongDiHienTai.Count;
                 i += SO_DINH_MOI_DONG)
            {
                string dong =
                    string.Join(" -> ", duongDiHienTai.Skip(i).Take(SO_DINH_MOI_DONG).Select(d => d.Ten));

                if (i > 0)
                {
                    dong = "-> " + dong;
                }

                lstDuongDi.Items.Add(dong);
            }
        }

        private void TaoPanelTron(Panel panel)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, panel.Width - 1, panel.Height - 1);
            panel.Region = new Region(path);
        }
        private void CapNhatThongTinDoThi()
        {
            string dsDinh = string.Join(", ", danhSachDinh.OrderBy(d => d.Ten).Select(d => d.Ten));

            string dsCanh = string.Join(", ", danhSachCanh.Select(c =>
            {
                string a = c.DinhDau.Ten;
                string b = c.DinhCuoi.Ten;

                return string.Compare(a, b) < 0
                    ? a + b
                    : b + a;
            })
            .OrderBy(c => c));

            lblThongTinDoThi.Text = "Đỉnh (" + danhSachDinh.Count + "): " + dsDinh + Environment.NewLine + "Cạnh (" + danhSachCanh.Count + "): " + dsCanh;
        }

        public Form1()
        {
            InitializeComponent();
            timerHamilton.Interval = 500;

            timerHamilton.Tick += TimerHamilton_Tick;

            btnThemDinh.Enabled = true;
            btnThemCanh.Enabled = true;
            btnChonDinhBatDau.Enabled = true;

            CapNhatDuongDi();
        }

        private void btnThemDinh_Click(object sender, EventArgs e)
        {
            ChuyenCheDo(CheDo.ThemDinh);

            dinhDangChon = null;
            dinhThuHai = null;

            ThemThongBao("🔧 Đã chọn chức năng thêm đỉnh");
        }

        private async void pnVeDoThi_MouseClick(object sender, MouseEventArgs e)
        {
            if (cheDoHienTai == CheDo.ThemDinh)
            {
                Dinh? dinhDaCo = TimDinhTaiViTri(e.Location);

                if (dinhDaCo != null)
                {
                    int soCanhBiXoa = danhSachCanh.Count(c => c.DinhDau == dinhDaCo || c.DinhCuoi == dinhDaCo);

                    danhSachCanh.RemoveAll(c => c.DinhDau == dinhDaCo || c.DinhCuoi == dinhDaCo);

                    danhSachDinh.Remove(dinhDaCo);
                    CapNhatThongTinDoThi();

                    ThemThongBao("❌ Đã xóa đỉnh " + dinhDaCo.Ten);

                    if (soCanhBiXoa > 0)
                    {
                        ThemThongBao("Đã xóa " + soCanhBiXoa + " cạnh liên quan");
                    }
                }
                else
                {
                    Dinh dinhMoi = new Dinh();

                    dinhMoi.Ten = LayTenDinhMoi();

                    dinhMoi.ViTri = e.Location;

                    danhSachDinh.Add(dinhMoi);
                    CapNhatThongTinDoThi();
                    ThemThongBao("➕ Đã thêm đỉnh " + dinhMoi.Ten);
                }
                pnVeDoThi.Invalidate();
            }

            if (cheDoHienTai == CheDo.ThemCanh)
            {
                Dinh? dinhDuocClick = TimDinhTaiViTri(e.Location);

                if (dinhDuocClick == null)
                    return;

                if (dinhDangChon == null)
                {
                    dinhDangChon = dinhDuocClick;

                    pnVeDoThi.Invalidate();
                }
                else
                {
                    if (dinhDangChon == dinhDuocClick)
                    {
                        dinhDangChon = null;
                        dinhThuHai = null;

                        pnVeDoThi.Invalidate();

                        return;
                    }
                    dinhThuHai = dinhDuocClick;

                    pnVeDoThi.Invalidate();

                    await Task.Delay(100);

                    Canh? canhTonTai = danhSachCanh.FirstOrDefault(c => (c.DinhDau == dinhDangChon && c.DinhCuoi == dinhDuocClick) || (c.DinhDau == dinhDuocClick && c.DinhCuoi == dinhDangChon));

                    if (canhTonTai != null)
                    {
                        danhSachCanh.Remove(canhTonTai);
                        CapNhatThongTinDoThi();

                        ThemThongBao("❌ Đã xóa cạnh " + canhTonTai.DinhDau.Ten + " - " + canhTonTai.DinhCuoi.Ten);
                    }
                    else
                    {
                        Canh canhMoi = new Canh();

                        canhMoi.DinhDau = dinhDangChon;
                        canhMoi.DinhCuoi = dinhDuocClick;

                        danhSachCanh.Add(canhMoi);
                        CapNhatThongTinDoThi();
                        ThemThongBao("🔗 Đã nối đỉnh " + canhMoi.DinhDau.Ten + " với " + canhMoi.DinhCuoi.Ten);

                    }

                    dinhDangChon = null;
                    dinhThuHai = null;

                    pnVeDoThi.Invalidate();
                }
            }
            if (cheDoHienTai == CheDo.ChonDinhBatDau)
            {
                Dinh? dinhDuocClick = TimDinhTaiViTri(e.Location);

                if (dinhDuocClick == null)
                    return;

                if (dinhBatDau == dinhDuocClick)
                {
                    dinhBatDau = null;
                }
                else
                {
                    dinhBatDau = dinhDuocClick;
                }

                pnVeDoThi.Invalidate();
                return;

            }
        }

        private void pnVeDoThi_Paint(object sender, PaintEventArgs e)
        {
            Graphics doHoa = e.Graphics;

            foreach (Canh canh in danhSachCanh)
            {
                Pen butVe = new Pen(Color.Black, 2);

                if (canh.DangDuocXet)
                {
                    butVe = new Pen(Color.DarkOrange, 5);
                }

                doHoa.DrawLine(butVe, canh.DinhDau.ViTri, canh.DinhCuoi.ViTri);
            }

            foreach (Dinh dinh in danhSachDinh)
            {
                Brush mauDinh = Brushes.LightBlue;

                if (duongDiHienTai.Contains(dinh))
                {
                    mauDinh = Brushes.DeepSkyBlue;
                }

                if (dinh == dinhDangChon || dinh == dinhThuHai)
                {
                    mauDinh = Brushes.Yellow;
                }

                if (dinh == dinhDangXetHamilton)
                {
                    mauDinh = Brushes.Red;
                }


                if (dinh == dinhBatDau)
                {
                    mauDinh = Brushes.LightGreen;
                }

                doHoa.FillEllipse(mauDinh, dinh.ViTri.X - 15, dinh.ViTri.Y - 15, 30, 30);

                doHoa.DrawEllipse(Pens.Black, dinh.ViTri.X - 15, dinh.ViTri.Y - 15, 30, 30);

                doHoa.DrawString(dinh.Ten, this.Font, Brushes.Black, dinh.ViTri.X - 6, dinh.ViTri.Y - 8);
            }
        }

        private void btnThemCanh_Click(object sender, EventArgs e)
        {

            if (danhSachDinh.Count < 2)
            {
                MessageBox.Show("Cần ít nhất 2 đỉnh để tạo cạnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ChuyenCheDo(CheDo.ThemCanh);

            dinhDangChon = null;
            dinhThuHai = null;

            ThemThongBao("🔧 Đã chọn chức năng thêm cạnh");
        }

        private Dinh? TimDinhTaiViTri(Point viTri)
        {
            foreach (Dinh dinh in danhSachDinh)
            {
                double khoangCach = Math.Sqrt(Math.Pow(viTri.X - dinh.ViTri.X, 2) + Math.Pow(viTri.Y - dinh.ViTri.Y, 2));
                if (khoangCach <= 15)
                {
                    return dinh;
                }
            }
            return null;
        }

        private bool DoThiLienThong()
        {
            if (danhSachDinh.Count == 0)
                return true;

            HashSet<Dinh> daTham = new HashSet<Dinh>();

            Queue<Dinh> hangDoi = new Queue<Dinh>();

            Dinh dinhDau = danhSachDinh[0];

            daTham.Add(dinhDau);
            hangDoi.Enqueue(dinhDau);

            while (hangDoi.Count > 0)
            {
                Dinh hienTai = hangDoi.Dequeue();

                foreach (Canh canh in danhSachCanh)
                {
                    Dinh? dinhKe = null;

                    if (canh.DinhDau == hienTai)
                        dinhKe = canh.DinhCuoi;
                    else if (canh.DinhCuoi == hienTai)
                        dinhKe = canh.DinhDau;

                    if (dinhKe != null && !daTham.Contains(dinhKe))
                    {
                        daTham.Add(dinhKe);
                        hangDoi.Enqueue(dinhKe);
                    }
                }
            }
            return daTham.Count == danhSachDinh.Count;
        }

        private bool CoDinhBacNhoHonHai()
        {
            foreach (Dinh dinh in danhSachDinh)
            {
                int bac = danhSachCanh.Count(c => c.DinhDau == dinh || c.DinhCuoi == dinh);

                if (bac < 2)
                {
                    return true;
                }
            }

            return false;
        }

        private void lstThongBao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            TaoPanelTron(pnStart);
            TaoPanelTron(pnDangXet);
            TaoPanelTron(pnDuongDi);
            TaoPanelTron(pnDangChon);
            TaoPanelTron(pnCanh);
        }

        private void btnChonDinhBatDau_Click(object sender, EventArgs e)
        {
            ChuyenCheDo(CheDo.ChonDinhBatDau);

            ThemThongBao("📍 Vui lòng chọn một đỉnh");
        }

        private void btnTimHamilton_Click(object sender, EventArgs e)
        {
            if (CoDinhBacNhoHonHai())
            {
                lstThongBao.Items.Clear();

                ThemThongBao("❌ Không tìm thấy chu trình Hamilton");

                ThemThongBao("Lý do: Có đỉnh bậc nhỏ hơn 2");

                return;
            }

            if (!DoThiLienThong())
            {
                lstThongBao.Items.Clear();

                ThemThongBao("❌ Không tìm thấy chu trình Hamilton");

                ThemThongBao("Lý do: Đồ thị không liên thông");

                return;
            }

            if (CoDinhCat())
            {
                lstThongBao.Items.Clear();

                ThemThongBao("❌ Không tìm thấy chu trình Hamilton");

                ThemThongBao("Lý do: Đồ thị chứa đỉnh cắt");

                return;
            }

            if (daKetThucHamilton)
            {
                HuyTrangThaiHamilton();

                danhSachBuocHamilton.Clear();
                danhSachChuTrinhTimDuoc.Clear();

                lstThongBao.Items.Clear();
                lstChuTrinh.Items.Clear();

                daKetThucHamilton = false;

                btnTimHamilton.Text = "Tìm Hamilton";

                btnThemDinh.Enabled = true;
                btnThemCanh.Enabled = true;
                btnChonDinhBatDau.Enabled = true;

                return;
            }
            if (dangTimHamilton)
            {
                timerHamilton.Stop();

                dangTimHamilton = false;

                btnTimHamilton.Text = "Tiếp tục";

                btnThemDinh.Enabled = true;
                btnThemCanh.Enabled = true;
                btnChonDinhBatDau.Enabled = true;

                ThemThongBao("⏸ Đã tạm dừng");

                return;
            }
            if (!dangTimHamilton &&
                danhSachBuocHamilton.Count > 0 &&
                chiSoBuocHamilton < danhSachBuocHamilton.Count)
            {
                timerHamilton.Start();

                dangTimHamilton = true;

                btnTimHamilton.Text = "Dừng";

                btnThemDinh.Enabled = false;
                btnThemCanh.Enabled = false;
                btnChonDinhBatDau.Enabled = false;

                ThemThongBao("▶ Tiếp tục tìm Hamilton");

                return;
            }

            XoaDanhDauHamilton();
            duongDiHienTai.Clear();
            danhSachChuTrinhTimDuoc.Clear();
            danhSachBuocHamilton.Clear();

            if (danhSachDinh.Count < 3)
            {
                MessageBox.Show("Chu trình Hamilton cần ít nhất 3 đỉnh");

                return;
            }

            if (dinhBatDau == null)
            {
                MessageBox.Show("Vui lòng chọn đỉnh bắt đầu");

                return;
            }

            ThemThongBao("🚀 Đang tìm chu trình Hamilton...");

            HamiltonSolver solver = new HamiltonSolver(danhSachDinh, danhSachCanh);

            solver.TimTatCaChuTrinhHamilton(dinhBatDau);

            danhSachBuocHamilton = solver.DanhSachBuoc;
            danhSachChuTrinhTimDuoc = solver.DanhSachChuTrinh;


            foreach (Canh canh in danhSachCanh)
            {
                canh.DangDuocXet = false;
            }
            dinhDangXetHamilton = null;

            chiSoBuocHamilton = 0;

            duongDiHienTai.Clear();

            duongDiHienTai.Add(dinhBatDau);

            CapNhatDuongDi();

            lstThongBao.Items.Clear();

            if (danhSachBuocHamilton.Count > 0)
            {
                ThemThongBao(danhSachBuocHamilton[0].MoTa);

                chiSoBuocHamilton = 1;
            }

            dangTimHamilton = true;

            btnTimHamilton.Text = "Dừng Hamilton";

            btnThemDinh.Enabled = false;
            btnThemCanh.Enabled = false;
            btnChonDinhBatDau.Enabled = false;

            timerHamilton.Start();


        }
        private void TimerHamilton_Tick(object? sender, EventArgs e)
        {
            if (chiSoBuocHamilton >= danhSachBuocHamilton.Count)
            {
                timerHamilton.Stop();

                dangTimHamilton = false;

                daKetThucHamilton = true;

                btnTimHamilton.Text = "Reset";

                XoaDanhDauHamilton();
                dinhDangXetHamilton = null;

                pnVeDoThi.Invalidate();

                if (danhSachChuTrinhTimDuoc.Count == 0)
                {
                    ThemThongBao("❌ Không tồn tại chu trình Hamilton");

                    lstChuTrinh.Items.Clear();

                    lstChuTrinh.Items.Add("∅");
                }
                else
                {
                    ThemThongBao("🏁🏁 Tổng cộng tìm được " + danhSachChuTrinhTimDuoc.Count + " chu trình 🏁🏁");

                    int stt = 1;

                    lstChuTrinh.Items.Clear();

                    foreach (List<Dinh> chuTrinh
                        in danhSachChuTrinhTimDuoc)
                    {
                        string chuoi = string.Join(" -> ", chuTrinh.Select(d => d.Ten));
                        chuoi += " -> " + chuTrinh[0].Ten;
                        lstChuTrinh.Items.Add(stt + ". " + chuoi);
                        stt++;
                    }
                }

                return;
            }

            BuocHamilton buoc = danhSachBuocHamilton[chiSoBuocHamilton];
            if (buoc.TamDungLauHon)
            {
                timerHamilton.Interval = 2000;
            }
            else
            {
                timerHamilton.Interval = 500;
            }

            if (buoc.DenDinh != null)
            {
                dinhDangXetHamilton = buoc.DenDinh;

                if (!buoc.LaQuayLui)
                {
                    if (buoc.MoTa.StartsWith("Khép chu trình"))
                    {
                        duongDiHienTai.Add(buoc.DenDinh);
                    }
                    else
                    {
                        if (!duongDiHienTai.Contains(buoc.DenDinh))
                        {
                            duongDiHienTai.Add(buoc.DenDinh);
                        }
                    }
                }
                else
                {
                    if (duongDiHienTai.Count > 1)
                    {
                        duongDiHienTai.RemoveAt(duongDiHienTai.Count - 1);
                    }
                }

                CapNhatDuongDi();
            }

            ThemThongBao(buoc.MoTa);

            if (buoc.TuDinh != null && buoc.DenDinh != null)
            {
                Canh? canh = danhSachCanh.FirstOrDefault(c => (c.DinhDau == buoc.TuDinh && c.DinhCuoi == buoc.DenDinh) || (c.DinhDau == buoc.DenDinh && c.DinhCuoi == buoc.TuDinh));

                if (canh != null)
                {
                    if (buoc.LaQuayLui)
                    {
                        canh.DangDuocXet = false;
                    }
                    else
                    {
                        canh.DangDuocXet = true;
                    }
                }
            }

            pnVeDoThi.Invalidate();

            chiSoBuocHamilton++;
        }

        private void XoaDanhDauHamilton()
        {
            foreach (Canh canh in danhSachCanh)
            {
                canh.DangDuocXet = false;
            }

            dinhDangXetHamilton = null;

            duongDiHienTai.Clear();

            CapNhatDuongDi();

            pnVeDoThi.Invalidate();
        }

        private void ChuyenCheDo(CheDo cheDoMoi)
        {
            timerHamilton.Stop();

            dangTimHamilton = false;

            daKetThucHamilton = false;

            chiSoBuocHamilton = 0;

            danhSachBuocHamilton.Clear();

            danhSachChuTrinhTimDuoc.Clear();

            lstChuTrinh.Items.Clear();

            XoaDanhDauHamilton();

            btnTimHamilton.Text = "Tìm Hamilton";

            cheDoHienTai = cheDoMoi;
        }

        private void HuyTrangThaiHamilton()
        {
            foreach (Canh canh in danhSachCanh)
            {
                canh.DangDuocXet = false;
            }

            dinhDangXetHamilton = null;

            duongDiHienTai.Clear();

            dinhBatDau = null;

            pnVeDoThi.Invalidate();
        }

        private void lstChuTrinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstChuTrinh.SelectedIndex < 0)
            {
                return;
            }

            XoaDanhDauHamilton();

            List<Dinh> chuTrinh = danhSachChuTrinhTimDuoc[lstChuTrinh.SelectedIndex];

            for (int i = 0; i < chuTrinh.Count; i++)
            {
                Dinh a = chuTrinh[i];

                Dinh b = (i == chuTrinh.Count - 1) ? chuTrinh[0] : chuTrinh[i + 1];

                Canh? canh = danhSachCanh.FirstOrDefault(c => (c.DinhDau == a && c.DinhCuoi == b) || (c.DinhDau == b && c.DinhCuoi == a));

                if (canh != null)
                {
                    canh.DangDuocXet = true;
                }
            }

            pnVeDoThi.Invalidate();
        }

        private bool DoThiLienThongKhiBoQua(Dinh dinhBoQua)
        {
            List<Dinh> cacDinhConLai = danhSachDinh.Where(d => d != dinhBoQua).ToList();

            if (cacDinhConLai.Count <= 1)
            {
                return true;
            }

            HashSet<Dinh> daTham = new HashSet<Dinh>();

            Queue<Dinh> hangDoi = new Queue<Dinh>();

            Dinh dinhDau = cacDinhConLai[0];

            daTham.Add(dinhDau);
            hangDoi.Enqueue(dinhDau);

            while (hangDoi.Count > 0)
            {
                Dinh hienTai = hangDoi.Dequeue();

                foreach (Canh canh in danhSachCanh)
                {
                    if (canh.DinhDau == dinhBoQua || canh.DinhCuoi == dinhBoQua)
                    {
                        continue;
                    }

                    Dinh? dinhKe = null;

                    if (canh.DinhDau == hienTai) dinhKe = canh.DinhCuoi;
                    else if (canh.DinhCuoi == hienTai) dinhKe = canh.DinhDau;

                    if (dinhKe != null && !daTham.Contains(dinhKe))
                    {
                        daTham.Add(dinhKe);
                        hangDoi.Enqueue(dinhKe);
                    }
                }
            }

            return daTham.Count == cacDinhConLai.Count;
        }

        private bool CoDinhCat()
        {
            foreach (Dinh dinh in danhSachDinh)
            {
                if (!DoThiLienThongKhiBoQua(dinh))
                {
                    return true;
                }
            }

            return false;
        }
        private void lblChuTrinh_Click(object sender, EventArgs e)
        {

        }

        private void lblThongTinDoThi_Click(object sender, EventArgs e)
        {

        }
    }
}
