using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class NotFoundHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);

        // test if the response is a 404
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return request.CreateResponse(HttpStatusCode.NotFound, new
            {
                Message = "The resource you are looking for does not exist.",
                RequestUri = request.RequestUri.ToString(),
                AvailableEndpoints = new[]
                {
                    "/api/weather?city={city}"
                }
            });
        }

        return response;
    }
}
