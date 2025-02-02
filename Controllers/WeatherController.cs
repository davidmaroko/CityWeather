using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CityWeather.Classes;
using CityWeather.Models;

namespace CityWeather.Controllers
{
    public class WeatherController : ApiController
    {
        private readonly WeatherService weatherService = new WeatherService();
        private bool IsValidCityName(string city)
        {
            return !string.IsNullOrEmpty(city) && System.Text.RegularExpressions.Regex.IsMatch(city, @"^[a-zA-Z\u0590-\u05FF\s]+$");
        }

        [HttpGet]
        [Route("api/weather")]
        public async Task<IHttpActionResult> GetWeather([FromUri] string city = "Tel Aviv")
        {
            if (!IsValidCityName(city))
            {
                return BadRequest("Invalid city name. Please provide a valid city name using only letters and spaces.");
            }

            try
            {
                // get the weather data from the API
                WeatherApiResponse weatherData = await weatherService.GetWeatherAsync(city);

                // if the weather data is null or the location is null
                if (weatherData == null || weatherData.location == null)
                {
                    return NotFound();  // return 404 - the city was not found
                }

                // create a new object with the data we want to return
                var result = new
                {
                    Temperature_c = weatherData.current.temp_c,
                    Temperature_f = weatherData.current.temp_f,
                    WindSpeed_kph = weatherData.current.wind_kph,
                    Country = weatherData.location.country,
                    City = weatherData.location.name
                };

                return Ok(result);
            }
            catch (HttpRequestException ex)
            {
                return BadRequest($"Error fetching weather data: {ex.Message}");
            }
        }
    }
}
