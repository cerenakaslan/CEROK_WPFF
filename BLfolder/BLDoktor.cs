using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CEROK_WPF;

namespace CEROK_WPF.BLfolder
{
    public class BLDoktor
    {
        public int doktorID { get; set; }
        public string doktorpassword { get; set; }
        public string doktorismi { get; set; }
        public string doktorsoyismi { get; set; }
        //public List<BLDoktorPoli> doktor_Polis { get; set; }
        //public List<BLRandevuKismi> randevuKismis { get; set; }
        //public List<BLRecete> recetes { get; set; }
        //public List<BLTani> tanis { get; set; }
        //public List<BLTetkik> tetkiks { get; set; }

        public async Task<bool> BLDoktorLogin(int id, string password)
        {         
            HttpClient doktor = new HttpClient();
            doktor.BaseAddress = new Uri("https://localhost:7086/");
            

            doktor.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            //Headera paramtereleri ekle

            using (HttpClient httpClient = new HttpClient() { BaseAddress = doktor.BaseAddress })
            {
                HttpResponseMessage request = await doktor.GetAsync($"api/Doktor/{id}");
                var content = await request.Content.ReadAsStringAsync();
                BLDoktor bldoktor = JsonConvert.DeserializeObject<BLDoktor>(content);

                if (bldoktor != null && bldoktor.doktorID != 0)
                {
                    
                    if (bldoktor.doktorID == id && bldoktor.doktorpassword == password)
                    {
                        App.DoktorId = id;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;

                }
            }
        }
    }
}








