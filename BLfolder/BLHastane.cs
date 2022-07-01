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
    public class BLHastane
    {
        public int hastaneID { get; set; }
        public string hastaneIsim { get; set; }
        public int ilceID { get; set; }
        public BLIlce ilce { get; set; }
        public List<BLHastanePoli> hastane_polis { get; set; }

        public async Task<BLHastane> LoadHastane(int hastaneid)
        {
            HttpClient hastane = new HttpClient();
            hastane.BaseAddress = new Uri("https://localhost:7086/");

            hastane.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await hastane.GetAsync($"api/Hastane/{App.HastaneId}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BLHastane>(content);

        }
    }
}

