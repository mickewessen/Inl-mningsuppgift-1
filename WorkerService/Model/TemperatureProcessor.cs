using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService.Model
{
    public class WeatherApi
    {
    
        public static async Task<WeatherModel> LoadWeatherInformation()
        {
            string url = "https://api.openweathermap.org/data/2.5/onecall?lat=59.2752626&lon=15.213410500000009&units=metric&lang=se&exclude=minutely&appid=72c0422cad37f54157cc7ab4fe2e5c71";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    WeatherModel result = await response.Content.ReadAsAsync<WeatherModel>();

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
