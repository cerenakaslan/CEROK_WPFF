using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using Newtonsoft.Json;
using CEROK_WPF.BLfolder;


namespace CEROK_WPF
{
    public partial class Login : Window
    {
        BLDoktor bldoktor = new BLDoktor();
        public Login()
        {
            InitializeComponent();
        }
        //public App a;

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            int id = Convert.ToInt32(txtId.Text);

            bool x = await bldoktor.BLDoktorLogin(id, txtSifre.Text);
            if(x)
            {               
                    MainWindow mainwindow = new MainWindow();
                    mainwindow.Show();
                }
            else
                {
                    MessageBox.Show("Hatalı Giriş Yaptınız, Lütfen Tekrar Deneyiniz!");
                    //string caption = "Word Processor";
                    MessageBoxButton button = MessageBoxButton.OK;
                    //MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult result;

                }
            }
        }
    }