using AQuzduotis.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQuzduotis.Tasks
{
    public class SetCalculations
    {
        public List<HarnessSet> GenerateSets(List<Harness> harnes, List<Wires> wires)
        {
            List<HarnessSet> Sets = new List<HarnessSet>();
            if (harnes.Count < 3)
            {
                //sukurt triju skirtingu setu neimanoma, per mazai pyniu
                return null;
            }
            for (int i = 0; i<3; i++)
            {
                Sets.Add(GenSet(harnes, Sets, wires));
            }
            return Sets;
        }

        private HarnessSet GenSet(List<Harness> harnes, List<HarnessSet> Sets, List<Wires> wires)
        {
            int size = harnes.Count;
            Random rand = new Random();
            Harness h1 = harnes[rand.Next(size)];
            Harness h2 = harnes[rand.Next(size)];
            while (h1.Equals(h2))
            {
                h2 = harnes[rand.Next(size)];
            }
            if(CheckIfUnique(h1, h2, Sets))
            {
                bool correct = CheckColidingWires(h1, h2, wires);
                return new HarnessSet(h1, h2, correct);
            }

            return GenSet(harnes, Sets, wires);
        }

        private bool CheckIfUnique(Harness h1, Harness h2, List<HarnessSet> Sets)
        {
            foreach (var set in Sets)
            {
                if(set.Harness1.Equals(h1) || set.Harness2.Equals(h1))
                {
                    if (set.Harness1.Equals(h2) || set.Harness2.Equals(h2))
                        return false;
                }
            }
            return true;
        }

        private bool CheckColidingWires(Harness h1, Harness h2, List<Wires> wires)
        {
            List<Wires> h1Wires = FindHarnessWires(h1, wires);
            List<Wires> h2Wires = FindHarnessWires(h2, wires);
            foreach (var w1 in h1Wires)
            {
                foreach(var w2 in h2Wires)
                {
                    if (w1.Housing1 == w2.Housing1 || w1.Housing1 == w2.Housing2 || w1.Housing2 == w2.Housing1 || w1.Housing2 == w2.Housing2)
                        return false;
                }
            }
            return true;
        }

        public List<Wires> FindHarnessWires(Harness h, List<Wires> wires)
        {
            List<Wires> foundWires = new List<Wires>();
            foreach (var w in wires)
            {
                if (w.HarnessID == h.ID)
                {
                    foundWires.Add(w);
                }
            }
            return foundWires;
        }
    }
}
