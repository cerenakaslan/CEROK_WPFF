using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for HastanınHerseyi.xaml
    /// </summary>
    public partial class HastanınHerseyi : Window
    {
        #region Definitions
        private BLHasta blhs = new BLHasta();
        private int randevuID;    
        private BLRandevuKismi blrd = new BLRandevuKismi();
        #endregion
        public HastanınHerseyi(int randevuid)
        {
            InitializeComponent();
            GetRandevusTablo();
            randevuID = randevuid;
            blhs= App.Randevular.Where(x => x.randevuID == randevuid).Select(y => y.hasta).FirstOrDefault();
            this.DataContext = blhs;
            //  blhs = App.Randevular.Where(x => x.randevuID == randevuid).Select(y => y.hasta).FirstOrDefault();
            this.gridullah_randevular.DataContext = blhs;

        }
        public async void GetRandevusTablo()
        {
            List<BLRandevuKismi> randevuListesi = await blrd.LoadRandevuListesi();
            gridullah_randevular.ItemsSource = randevuListesi;
            App.Randevular = randevuListesi;
        }
        private void BTNYeniTetkik_Click(object sender, RoutedEventArgs e)
        {
            CancelBTN.Visibility = Visibility.Visible;
            BTNYeniTetkik.Visibility = Visibility.Hidden;
            EditBTN.Visibility = Visibility.Hidden;
            YeniTetkik.Visibility = Visibility.Visible;
            YeniTetkikBar.Visibility = Visibility.Visible;
        }

        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            CancelBTN.Visibility = Visibility.Hidden;
            BTNYeniTetkik.Visibility = Visibility.Visible;
            EditBTN.Visibility = Visibility.Visible;
            YeniTetkik.Visibility = Visibility.Hidden;
            YeniTetkikBar.Visibility = Visibility.Hidden;
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}

// txtHastaTC.Text = App.HastaId.ToString();
// blhasta.LoadHASTA(this);
// txtHastaTC.Text = App.HastaId.ToString(kaynak.tc);
//txtHastaTC.Text.Contains(kaynak.tc);
//txtHastaTC.Text = kaynak.tc;

/*public void HastaVerileriniGir(int randevuId)
{
    List<BLRandevuKismi> randevuList = new List<BLRandevuKismi>();
    //   blhs.LoadHASTA(this, App.HastaId);
    BLHasta hasta = randevuList.Where(x => x.randevuID == randevuId).Select(y => y.hasta).FirstOrDefault();
    txtHastaTC.Text = hasta.isim;

...........

    public void HastaVerileriniGir(BLHasta hasta)
        {
            List<BLRandevuKismi> randevuList = new List<BLRandevuKismi>();
            //   blhs.LoadHASTA(this, App.HastaId);
            BLHasta hasta = randevuList.Where(x => x.randevuID == randevuID).Select(y => y.hasta).FirstOrDefault();
            txtHastaTC.Text = hasta.isim;             
        }
}

................

 //public void HastaVerileriniGir(int randevuID)
        //{
        //    // List<BLRandevuKismi> randevuList = new List<BLRandevuKismi>();
        //    //   blhs.LoadHASTA(this, App.HastaId);
        //    BLHasta hasta = App.Randevular.Where(x => x.randevuID == randevuID).Select(y => y.hasta).FirstOrDefault();
        //    txtHastaTC.Text = hasta.tc;
        //    //  txtHastaTC.Text = ShowDialog(hasta.tc);
        //}
*/