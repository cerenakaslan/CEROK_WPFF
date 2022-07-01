using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEROK_WPF.BLfolder
{
    public class BLBolum
    {
        public int bolumID { get; set; }
        public string bolumIsmi { get; set; }
        public List<BLDoktorPoli> doktor_Polis { get; set; }
        public List<BLHastanePoli> hastane_polis { get; set; }
    }
}
