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
    public class BLIl
    {
        public int ilKodu { get; set; }
        public string ilIsmi { get; set; }
        public List<BLIl> ilces { get; set; }


        public async Task<BLIl> LoadIL(int ilid)
        {
            HttpClient il = new HttpClient();
            il.BaseAddress = new Uri("https://localhost:7086/");

            il.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await il.GetAsync($"api/Il/{App.IlId}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BLIl>(content);

        }
    }
}


