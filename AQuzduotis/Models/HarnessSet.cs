using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQuzduotis.Models
{
    public class HarnessSet
    {
        public Harness Harness1 { get; set; }
        public Harness Harness2 { get; set; }
        public bool Valid {  get; set; }
        public HarnessSet() { }
        public HarnessSet(Harness harness1, Harness harness2, bool valid)
        {
            Harness1 = harness1;
            Harness2 = harness2;
            Valid = valid;
        }
    }
}
