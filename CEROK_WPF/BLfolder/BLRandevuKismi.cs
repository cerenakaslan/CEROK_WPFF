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
    public class BLRandevuKismi
    {
        public int doktorID { get; set; }
        public int hastaID { get; set; }
        public int randevuID { get; set; }
        public DateTime gunsaat { get; set; }
        public BLDoktor doktor { get; set; }
        public BLHasta hasta { get; set; }
        public List<BLRecete> recetes { get; set; }
        public List<BLTani> tanis { get; set; }
        public List<BLTetkik> tetkiks { get; set; }

       public async Task<List<BLRandevuKismi>> LoadRandevuListesi()
        {
            
            HttpClient doktor = new HttpClient();
            doktor.BaseAddress = new Uri("https://localhost:7086/");

            doktor.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            
            HttpResponseMessage response = await doktor.GetAsync($"api/RandevuKismi/byDoc/{App.DoktorId}");
            var content = await response.Content.ReadAsStringAsync();
            List<BLRandevuKismi> randevuListesi = 
                JsonConvert.DeserializeObject<List<BLRandevuKismi>>(content);
            return randevuListesi;
           

        }
        

    }
}
