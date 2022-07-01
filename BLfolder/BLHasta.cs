using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CEROK_WPF.BLfolder
{
    public class BLHasta
    {
        public int hastaID { get; set; }
        public string tc { get; set; }
        public string sifre { get; set; }
        public string isim { get; set; }
        public string soyad { get; set; }
        public string cinsiyet { get; set; }
        public DateTime dogumTarihi { get; set; }
        public string telefonNo { get; set; }
        public string email { get; set; }
        public string kanGrubu { get; set; }
        public int? yas { get; set; }
        public int? boy { get; set; }
        public int? kilo { get; set; }
        public List<BLRandevuKismi> randevuKismis { get; set; }
        public List<BLRecete> recetes { get; set; }
        public List<BLTani> tanis { get; set; }
        


        public async Task<BLHasta> LoadHASTA(int randevuID)
        {
            HttpClient hasta = new HttpClient();
            hasta.BaseAddress = new Uri("https://localhost:7086/");

            hasta.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await hasta.GetAsync($"api/Hasta/{App.HastaId}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BLHasta>(content);

        }
       
    }
}
/* 

    protected async void LoadHasta(BLHasta hastaa)
        {
            HttpClient hasta = new HttpClient();
            hasta.BaseAddress = new Uri("https://localhost:7086/");

            hasta.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await hasta.GetAsync($"api/Hasta/{hastaID}");
            var content = await response.Content.ReadAsStringAsync();
            hastaa = JsonConvert.DeserializeObject<BLHasta>(content);

        }
        public BLHasta GetHasta()
        {
            BLHasta hastaa = new BLHasta();
            LoadHasta(hastaa);
            return hastaa;
        }
    }

 ................................

  public async void LoadHASTA(HastanınHerseyi hh)
        {
            HttpClient hasta = new HttpClient();
            hasta.BaseAddress = new Uri("https://localhost:7086/");

            hasta.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await hasta.GetAsync($"api/Hasta/{App.HastaId}");
            var content = await response.Content.ReadAsStringAsync();
            BLHasta res = JsonConvert.DeserializeObject<BLHasta>(content);
            hh.txtHastaTC.Text.Contains(res.tc);
        }*/
