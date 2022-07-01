using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEROK_WPF.BLfolder
{
    public class BLRecete
    {
        public int doktorID { get; set; }
        public int hastaID { get; set; }
        public int receteID { get; set; }
        public string gunsaat { get; set; }
        public int randevuID { get; set; }
        public BLDoktor doktor { get; set; }
        public BLHasta hasta { get; set; }
        public BLRandevuKismi randevu { get; set; }
    }
}
