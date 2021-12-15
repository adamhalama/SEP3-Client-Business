using System.Net.Http;

namespace CarRentalLogicServer.Factories
{
    public interface IHttpClientFactory
    {
        HttpClient GetHttpClient();
        string GetUri();
    }
}