using System.Net.Http;

namespace CarRentalLogicServer.APIConsumer.ClientFactory
{
    public class HttpClientFactory : IHttpClientFactory
    {
        private HttpClient client;
        private string uri = "https://carrental-springboot-rest-api.herokuapp.com/api";
        
        public HttpClient GetHttpClient()
        {
            if (client == null)
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                {
                    return true;
                };

                client = new HttpClient(clientHandler);
            }
            return client;
        }

        public string GetUri()
        {
            return uri;
        }
    }
}