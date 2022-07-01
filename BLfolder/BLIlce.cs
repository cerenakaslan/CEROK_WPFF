using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEROK_WPF.BLfolder
{
    public class BLIlce
    {
        public int ilceID { get; set; }
        public string ilceIsmi { get; set; }
        public int ilKodu { get; set; }
        public BLIl il { get; set; }
        public List<BLHastane> hastanes { get; set; }
    }
}
