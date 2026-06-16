using System.Collections.Generic;
using System.Linq;

namespace ToanRoiRac_LNMH_LQH
{
    public class HamiltonSolver
    {
        private List<Dinh> danhSachDinh;
        private List<Canh> danhSachCanh;

        public List<BuocHamilton> DanhSachBuoc = new List<BuocHamilton>();
        public List<List<Dinh>> DanhSachChuTrinh = new List<List<Dinh>>();

        public HamiltonSolver(List<Dinh> dsDinh,List<Canh> dsCanh)
        {
            danhSachDinh = dsDinh;
            danhSachCanh = dsCanh;
        }
        private bool CoCanh(Dinh a, Dinh b)
        {
            return danhSachCanh.Any(c =>(c.DinhDau == a &&c.DinhCuoi == b)||(c.DinhDau == b &&c.DinhCuoi == a));
        }
        public void TimTatCaChuTrinhHamilton(Dinh dinhBatDau)
        {
            List<Dinh> duongDi =new List<Dinh>();

            duongDi.Add(dinhBatDau);
            DanhSachBuoc.Add(new BuocHamilton{MoTa ="Bắt đầu từ đỉnh "+ dinhBatDau.Ten});
            TimHamiltonDeQuy(dinhBatDau,duongDi);
        }

        private void TimHamiltonDeQuy(Dinh dinhHienTai,List<Dinh> duongDi)
        {
            if (duongDi.Count ==danhSachDinh.Count)
            {
                if (CoCanh(dinhHienTai,duongDi[0]))
                {
                    List<Dinh> chuTrinhMoi =new List<Dinh>(duongDi);

                    DanhSachChuTrinh.Add(chuTrinhMoi);

                    string chuTrinh =string.Join(" -> ",chuTrinhMoi.Select(d => d.Ten));
                    chuTrinh +=" -> " +chuTrinhMoi[0].Ten;
                    DanhSachBuoc.Add(new BuocHamilton
                    {
                        TuDinh =dinhHienTai,

                        DenDinh =duongDi[0],

                        MoTa ="Khép chu trình về "+ duongDi[0].Ten
                    });
                    
                    DanhSachBuoc.Add(new BuocHamilton
                    {
                        MoTa =
                            "✓ Tìm thấy chu trình Hamilton số "
                            + DanhSachChuTrinh.Count,

                        TamDungLauHon = true
                    });

                    DanhSachBuoc.Add(new BuocHamilton
                    {
                        TuDinh =    
                            dinhHienTai,

                        DenDinh =
                            duongDi[0],

                        LaQuayLui = true,

                        MoTa =
                            "↩ Rời chu trình vừa tìm được"
                    });

                }
                return;
            }
            bool timDuocHuongDi = false;
            foreach (Dinh dinhKe in danhSachDinh)
            {
                if (duongDi.Contains(dinhKe))
                {
                    continue;
                }
                if (!CoCanh(dinhHienTai, dinhKe))
                {
                    continue;
                }
                timDuocHuongDi = true;
                DanhSachBuoc.Add(new BuocHamilton
                {
                    MoTa =
                        "▶ Đang xét đỉnh "
                        + dinhKe.Ten,

                    DenDinh =
                        dinhKe
                });

                duongDi.Add(dinhKe);
                DanhSachBuoc.Add(new BuocHamilton
                {
                    MoTa =
                        "→ Chọn đỉnh "
                        + dinhKe.Ten,

                    TuDinh =
                        dinhHienTai,

                    DenDinh =
                        dinhKe,

                    LaQuayLui = false
                });

                TimHamiltonDeQuy(dinhKe,duongDi);

                DanhSachBuoc.Add(new BuocHamilton
                {
                    MoTa =
                        "↩ Quay lui khỏi đỉnh "
                        + dinhKe.Ten,

                    TuDinh =
                        dinhHienTai,

                    DenDinh =
                        dinhKe,

                    LaQuayLui = true
                });
                duongDi.RemoveAt(duongDi.Count - 1);
            }
            if (!timDuocHuongDi)
            {
                DanhSachBuoc.Add(new BuocHamilton
                {
                    MoTa ="⚠ Không thể đi tiếp từ đỉnh "+ dinhHienTai.Ten
                });
            }

        }

    }

}