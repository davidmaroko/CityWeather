using System.Web.Http;

namespace CityWeather.Controllers
{
    public class DefaultController : ApiController
    {
        [HttpGet]
        [Route("{*path:regex(^(?!api).*$)}")]
        public IHttpActionResult HandleDefaultRoute(string path = null)
        {
            var response = new
            {
                Message = "The resource you are looking for does not exist.",
                RequestPath = path ?? "Root (default path)",
                AvailableEndpoints = new[]
                {
                    "/api/weather?city={city}"
                }
            };
            return Ok(response);
        }
    }
}
