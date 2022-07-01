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
    public class BLBolum
    {
        public int bolumID { get; set; }
        public string bolumIsmi { get; set; }
        public List<BLDoktorPoli> doktor_Polis { get; set; }
        public List<BLHastanePoli> hastane_polis { get; set; }

        public async Task<BLBolum> LoadHastane(int hastaneid)
        {
            HttpClient bolum = new HttpClient();
            bolum.BaseAddress = new Uri("https://localhost:7086/");

            bolum.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await bolum.GetAsync($"api/Poliklinik/{App.BolumId}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BLBolum>(content);

        }
    }
}
