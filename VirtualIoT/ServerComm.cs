using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace VirtualIoT
{
    public enum ServerResponse { NotConnected, Connected, ServerFailure };
    class ServerComm
    {
        private static readonly Lazy<ServerComm> lazy =
            new Lazy<ServerComm>(() => new ServerComm());
        public static ServerComm Instance { get { return lazy.Value; } }
        private HttpClient client;

        public string Root = @"https://iot.duality.co.nz/api/1";

        private ServerComm()
        {
            client = new HttpClient();
        }
        public async Task<Tuple<ServerResponse, HttpResponseMessage>> GetAsync(string url, 
            string email=null, string password=null)
        {
            ServerResponse result = ServerResponse.NotConnected;
            HttpResponseMessage getResponse = null;
            client.DefaultRequestHeaders.Clear();

            if (email != null)
                client.DefaultRequestHeaders.Add("email", email);
            if (password != null)
                client.DefaultRequestHeaders.Add("password", password);

            try
            {
                getResponse = await client.GetAsync(url);
                result = getResponse.IsSuccessStatusCode ? ServerResponse.Connected : ServerResponse.ServerFailure;
            }
            catch
            {
                result = ServerResponse.NotConnected;
            }
            //result:  0 = Not Connected,  1 = Connected,  2 = Server Failure.
            return Tuple.Create(result, getResponse);
        }
        public async Task<Tuple<ServerResponse, HttpResponseMessage>> PutAsync(string url, 
            HttpContent body, string contentType = null)
        {
            ServerResponse result = ServerResponse.NotConnected;
            HttpResponseMessage putResponse = null;
            client.DefaultRequestHeaders.Clear();
            if (contentType != null)
                body.Headers.ContentType = new MediaTypeHeaderValue(contentType);

            try
            {
                putResponse = await client.PutAsync(url, body);
                result = putResponse.IsSuccessStatusCode ? ServerResponse.Connected : ServerResponse.ServerFailure;
            }
            catch
            {
                result = ServerResponse.NotConnected;
            }
            //result:  0 = Not Connected,  1 = Connected,  2 = Server Failure.
            return Tuple.Create(result, putResponse);
        }
    }
}
