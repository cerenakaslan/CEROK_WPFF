using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEROK_WPF.BLfolder
{
    public class BLRapor
    {
        public int raporID { get; set; }
        public string gunsaat { get; set; }
        public int gecerlilikGunu { get; set; }
        public int taniID { get; set; }
        public BLTani tani { get; set; }
    }
}
