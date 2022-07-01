using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;


namespace CEROK_WPF.BLfolder
{
    public class BLTetkik
    {
        public int tetkikID { get; set; }
        public string tetkikAyrinti { get; set; }
        public int hastaID { get; set; }
        public int doktorID { get; set; }
        public int randevuID { get; set; }
        public string tetkikSonuc { get; set; }
        public BLDoktor doktor { get; set; }
        public BLHasta hasta { get; set; }
        public BLRandevuKismi randevu { get; set; }

        public async Task<List<BLTetkik>> LoadTETKIK(int hastaID)
        {
            HttpClient tetkik = new HttpClient();
            tetkik.BaseAddress = new Uri("https://localhost:7086/");

            tetkik.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await tetkik.GetAsync($"api/Tetkik/{App.HastaId}");
            var content = await response.Content.ReadAsStringAsync();
            List<BLTetkik> tetkikListesi = JsonConvert.DeserializeObject<List<BLTetkik>>(content);
            return tetkikListesi;
        }
    }
}
