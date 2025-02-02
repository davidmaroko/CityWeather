using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CityWeather.Models;  

namespace CityWeather.Classes
{
    public class WeatherService
    {
        private readonly string apiKey = "840696b07ae84e5e96a140638253001";

        public async Task<WeatherApiResponse> GetWeatherAsync(string city)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&aqi=no";

                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    //take the error content from the remote API service
                    string errorJson = await response.Content.ReadAsStringAsync();
                    dynamic errorData = JsonConvert.DeserializeObject(errorJson);

                    if (errorData.error != null)
                    {
                        throw new HttpRequestException((string)errorData.error.message);
                    }
                    //if no error message, throw a generic exception
                    throw new HttpRequestException("Failed to retrieve weather data.");
                }
                //parse the JSON response
                string jsonData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeatherApiResponse>(jsonData);
            }
        }
    }
}


