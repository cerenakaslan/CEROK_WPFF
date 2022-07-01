using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEROK_WPF.BLfolder
{
    public class BLDoktorPoli
    {
        public int doktorID { get; set; }
        public int bolumID { get; set; }
        public int id { get; set; }
        public BLBolum bolum { get; set; }
        public string doktor { get; set; }
    }
}
