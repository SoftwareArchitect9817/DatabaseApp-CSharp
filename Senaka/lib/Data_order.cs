using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senaka.lib
{
    public class Data_order
    {
        public Data_order(string status, string order_number, int cs_f, int cs_s, int sm_f, int lg_f, int sl_f, int sl_s, int bmd, int bmd_done, int cs_f_done, int cs_s_done, int sm_f_done, int lg_f_done, int sl_f_done, int sl_s_done, string bmd_info, string cs_f_info, string cs_s_info, string sm_f_info, string lg_f_info, string sl_f_info, string sl_s_info, double info)
        {
            Status = status;
            Order_numb = order_number;
            Cs_F = cs_f;
            Cs_S = cs_s;
            Sm_F = sm_f;
            Lg_F = lg_f;

            Sl_F = sl_f;
            Sl_S = sl_s;
            Bmd = bmd;
            Cs_F_done = cs_f_done;
            Cs_S_done = cs_s_done;
            Sm_F_done = sm_f_done;
            Lg_F_done = lg_f_done;

            Sl_F_done = sl_f_done;
            Sl_S_done = sl_s_done;
            Bmd_done = bmd_done;

            Cs_F_info = cs_f_info;
            Cs_S_info = cs_s_info;
            Sm_F_info = sm_f_info;
            Lg_F_info = lg_f_info;

            Sl_F_info = sl_f_info;
            Sl_S_info = sl_s_info;
            Bmd_info = bmd_info;
            Info = info;
        }
        public string Status { get; set; }
        public string Order_numb { get; set; }
        public int Cs_F { get; set; }
        public int Cs_S { get; set; }
        public int Sm_F { get; set; }
        public int Lg_F { get; set; }
        public int S_F { get; set; }
        public int Sl_F { get; set; }
        public int Sl_S { get; set; }
        public int L_F { get; set; }
        public int Bmd { get; set; }
        public int Bmd_done { get; set; }
        public int Cs_F_done { get; set; }
        public int Cs_S_done { get; set; }
        public int Sm_F_done { get; set; }
        public int Lg_F_done { get; set; }
        public int S_F_done { get; set; }
        public int Sl_F_done { get; set; }
        public int Sl_S_done { get; set; }
        public int L_F_done { get; set; }
        public string Bmd_info { get; set; }
        public string Cs_F_info { get; set; }
        public string Cs_S_info { get; set; }
        public string Sm_F_info { get; set; }
        public string Lg_F_info { get; set; }

        public string Sl_F_info { get; set; }
        public string Sl_S_info { get; set; }
        public string L_F_info { get; set; }
        public double Info { get; set; }

    }
}
