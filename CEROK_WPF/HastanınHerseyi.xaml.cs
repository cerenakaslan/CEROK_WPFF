using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private BLTetkik BlTetkik = new BLTetkik();
        private BLRandevuKismi rdv = new BLRandevuKismi();
        private BLRandevuTetkik BLRandevuTetkik = new BLRandevuTetkik();
        private  List<BLRandevuKismi> HastaninTumRandevular = new List<BLRandevuKismi>();
        private List<BLRandevuTetkik> HastaninRDVTetkikler = new List<BLRandevuTetkik>();

        #endregion

        public HastanınHerseyi(int randevuid)
        {
            InitializeComponent();
            randevuID = randevuid;
            rdv = App.Randevular.Where(x => x.randevuID == randevuID).Select(x => x).FirstOrDefault();
            blhs = rdv.hasta;
            Bilgiler.DataContext = blhs;
            TetkikKisimiVeriler();
            
        }
        public async void TetkikKisimiVeriler()
        {
            App.Tetkikler = await BlTetkik.LoadTetkiks();
            foreach (BLTetkik item in App.Tetkikler)
            {
                ListBoxItem listItem = new ListBoxItem();
                listItem.Content = item.tetkikAyrinti;
                listItem.Tag = item.tetkikID;
                TetkikListesi.Items.Add(listItem);
            }
            
            
        }



        private void BTNYeniTetkik_Click(object sender, RoutedEventArgs e)
        {
            CancelBTN.Visibility = Visibility.Visible;
            BTNYeniTetkik.Visibility = Visibility.Hidden;
            EditBTN.Visibility = Visibility.Hidden;
            TetkikListesi.Visibility = Visibility.Visible;
            YeniTetkikBar.Visibility = Visibility.Visible;
            SaveBTN.Visibility = Visibility.Visible;
        }

        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            CancelBTN.Visibility = Visibility.Hidden;
            BTNYeniTetkik.Visibility = Visibility.Visible;
            EditBTN.Visibility = Visibility.Visible;
            TetkikListesi.Visibility = Visibility.Hidden;
            YeniTetkikBar.Visibility = Visibility.Hidden;
            SaveBTN.Visibility = Visibility.Hidden;
        }

        private async void SaveBTN_Click(object sender, RoutedEventArgs e)
        {


            List<BLRandevuTetkik> liste = new List<BLRandevuTetkik>();
            foreach (ListBoxItem item in TetkikListesi.Items)
            {
                BLRandevuTetkik bl = new BLRandevuTetkik();

                bl.RandevuID = rdv.randevuID;
                bl.TetkikID = Convert.ToInt32(item.Tag.ToString());
                bl.IsChecked = item.IsSelected;
                //listeye BLRANDEVUTETKİK gir 
                liste.Add(bl);

            }
            BLRandevuTetkik.AddTETKIK(liste);
            Thread.Sleep(50);
            VarOlanTetkikler.ItemsSource=await BLRandevuTetkik.LoadTetkiksToVarolanTetkikler(rdv.randevuID);




            //FİNAL
            CancelBTN.Visibility = Visibility.Hidden;
            BTNYeniTetkik.Visibility = Visibility.Visible;
            EditBTN.Visibility = Visibility.Visible;
            TetkikListesi.Visibility = Visibility.Hidden;
            YeniTetkikBar.Visibility = Visibility.Hidden;
            SaveBTN.Visibility = Visibility.Hidden;
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