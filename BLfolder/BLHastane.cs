using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEROK_WPF.BLfolder
{
    public class BLHastane
    {
        public int hastaneID { get; set; }
        public string hastaneIsim { get; set; }
        public int ilceID { get; set; }
        public BLIlce ilce { get; set; }
        public List<BLHastanePoli> hastane_polis { get; set; }
    }
}
