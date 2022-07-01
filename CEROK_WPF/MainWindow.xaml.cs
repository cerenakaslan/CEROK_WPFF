using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CEROK_WPF.BLfolder;

namespace CEROK_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Definitions
        private BLRandevuKismi blrd = new BLRandevuKismi();
        
        #endregion Definitions
        public MainWindow()
        {

            InitializeComponent();
            GetRandevusByDoctorId();
           
        }
        /// <summary>
        /// Fill the randevuuuu grid
        /// </summary>
        public async void GetRandevusByDoctorId()
        {     
            List<BLRandevuKismi> randevuListesi = await blrd.LoadRandevuListesi();
            gridullah.ItemsSource = randevuListesi;
            App.Randevular = randevuListesi;        
        }

        private void bunyamin_Click(object sender, RoutedEventArgs e)
        {
            BLRandevuKismi rdv= ((FrameworkElement)sender).DataContext as BLRandevuKismi;
            HastanınHerseyi hastanınHerseyi = new HastanınHerseyi(rdv.randevuID);
            hastanınHerseyi.Show();

        }

        private void gridullah_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
    /* public void GetRandevusByDoctorId()
        {
            // blrd.LoadRDV(this,App.DoktorId);
            List<BLRandevuKismi> asd = blrd.GetRandevusByDoktorId();
            gridullah.ItemsSource = asd;
        }
*/