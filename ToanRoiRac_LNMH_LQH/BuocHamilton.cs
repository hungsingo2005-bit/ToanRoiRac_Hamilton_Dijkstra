using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToanRoiRac_LNMH_LQH
{
    public class BuocHamilton
    {
        public string MoTa { get; set; }

        public Dinh? TuDinh { get; set; }

        public Dinh? DenDinh { get; set; }

        public bool LaQuayLui { get; set; }
        public bool TamDungLauHon{ get; set; }
        public bool LaKhepChuTrinh { get; set; }
    }
}
