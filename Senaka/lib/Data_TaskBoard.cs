using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senaka.lib
{
    public class Data_TaskBoard
    {
        public Data_TaskBoard(int id,string ord_numb, string dateTime, string description, int frame, int color, int glass, int windows_assembly, int wrapping, int shipping, double p)
        {
            Id = id;
            Ord_numb = ord_numb;
            DateTime = dateTime;
            Description = description;
            Frame = frame;
            Color = color;
            Glass = glass;
            Windows_assembly = windows_assembly;
            Wrapping = wrapping;
            Shipping = shipping;
            P = p;


        }
        public int Id { get; set; }
        public string Ord_numb { get; set; }
        public string DateTime { get; set; }
        public string Description { get; set; }
        public int Frame { get; set; }
        public int Color { get; set; }
        public int Glass { get; set; }
        public int Windows_assembly { get; set; }
        public int Wrapping { get; set; }
        public int Shipping { get; set; }
        public double P { get; set; }


    }
}
