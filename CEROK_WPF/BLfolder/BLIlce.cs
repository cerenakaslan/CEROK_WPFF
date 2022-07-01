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
    public class BLIlce
    {
        public int ilceID { get; set; }
        public string ilceIsmi { get; set; }
        public int ilKodu { get; set; }
        public BLIl il { get; set; }
        public List<BLHastane> hastanes { get; set; }

        public async Task<BLIlce> LoadILce(int ilceid)
        {
            HttpClient ilce = new HttpClient();
            ilce.BaseAddress = new Uri("https://localhost:7086/");

            ilce.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await ilce.GetAsync($"api/Ilce/{App.IlceId}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BLIlce>(content);

        }
    }
}
