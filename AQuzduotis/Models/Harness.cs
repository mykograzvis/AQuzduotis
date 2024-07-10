using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace AQuzduotis.Models
{
    public class Harness
    {
        public int ID { get; set; }
        public string Harnes { get; set; }
        public string HarnessVersion { get; set; }
        public string Drawing { get; set; }
        public string DrawingVersion { get; set; }

        public Harness() { }

        public Harness(int iD, string harness, string harnessVersion, string drawing, string drawingVersion)
        {
            ID = iD;
            Harnes = harness;
            HarnessVersion = harnessVersion;
            Drawing = drawing;
            DrawingVersion = drawingVersion;
        }

        public override bool Equals(object obj)
        {
            if (obj == null|| !(obj is Harness))
            {
                return false;
            }
            Harness h = (Harness)obj;
            return ID == h.ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID);
        }

        public override string ToString()
        {
            return $"(Pynė: {Harnes}, Versija: {HarnessVersion}, Brėžinys: {Drawing}, Brėž. Versija: {DrawingVersion})";
        }
    }
}
