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
        
        
        
        public List<BLRandevuTetkik> RandevuTetkiks { get; set; }

        public async Task<List<BLTetkik>> LoadTetkiks()
        {
            HttpClient tetkik = new HttpClient();
            tetkik.BaseAddress = new Uri("https://localhost:7086/");

            tetkik.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await tetkik.GetAsync($"api/Tetkik");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<BLTetkik>>(content);

        }
        public async Task<int> GetTetkikId(string item)
        {
            HttpClient doktor = new HttpClient();
            doktor.BaseAddress = new Uri("https://localhost:7086/");

            doktor.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));


            HttpResponseMessage response = await doktor.GetAsync($"api/Tetkik/{item}");
            var content = await response.Content.ReadAsStringAsync();
            int TetkikID =
                JsonConvert.DeserializeObject<int>(content);
            return TetkikID;
        }
    }
}
