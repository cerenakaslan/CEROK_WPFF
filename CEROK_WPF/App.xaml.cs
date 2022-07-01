using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CEROK_WPF.BLfolder;



namespace CEROK_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static int DoktorId;//loginlenmiş doktorun randevularını gride girebilmek için
        public static int RandevuId; //şimdilik gerek yohdir
        public static int HastaId;
        public static int TetkikID;
        public static List<BLRandevuKismi> Randevular;
        public static List<BLTetkik> Tetkikler;

        public App()
        {
          
        }
        
    }
}
