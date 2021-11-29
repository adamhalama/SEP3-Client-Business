using System.Net.Http;

namespace CarRentalLogicServer.APIConsumer.ClientFactory
{
    public interface IHttpClientFactory
    {
        HttpClient GetHttpClient();
    }
}