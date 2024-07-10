using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQuzduotis.Models
{
    public class Wires
    {
        public int ID { get; set; }
        public int HarnessID { get; set; }
        public float Length { get; set; }
        public string Color { get; set; }
        public string Housing1 { get; set; }
        public string Housing2 { get; set; }

        public Wires() { }
        public Wires(int iD, int harnessID, float length, string color, string housing1, string housing2)
        {
            ID = iD;
            HarnessID = harnessID;
            Length = length;
            Color = color;
            Housing1 = housing1;
            Housing2 = housing2;
        }
    }
}
