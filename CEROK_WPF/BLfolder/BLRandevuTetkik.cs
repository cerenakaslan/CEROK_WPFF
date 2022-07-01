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
    public class BLRandevuTetkik
    {
        public int ID { get; set; }
       
        public int TetkikID { get; set; }
        public int RandevuID { get; set; }
        public string Sonuc { get; set; }
        public bool IsChecked { get; set; }

        public virtual BLTetkik Tetkik { get; set; }
        public virtual BLRandevuKismi Randevu { get; set; }
        public async void AddTETKIK(List<BLRandevuTetkik> liste)
        {
            HttpClient randevuTetkik = new HttpClient();
            randevuTetkik.BaseAddress = new Uri("https://localhost:7086/");

            randevuTetkik.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await randevuTetkik.PostAsJsonAsync($"​/api​/Tetkik​/PostTetkik​/{liste}", liste);

            
            //var myContent = JsonConvert.SerializeObject(liste);

            //var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            //var byteContent = new ByteArrayContent(buffer);
            //byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //return randevuTetkik.PostAsync($"api/Tetkik/PostTetkik/{liste}", byteContent).Result;
          
        }
        public async Task<List<BLRandevuTetkik>> LoadTetkiksToVarolanTetkikler(int randevuId)
        {
            HttpClient tetkik = new HttpClient();
            tetkik.BaseAddress = new Uri("https://localhost:7086/");

            tetkik.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await tetkik.GetAsync($"api/Tetkik/GetRandevuTetkiksOfRandevu/{randevuId}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<BLRandevuTetkik>>(content);
        }
        
    }
}
