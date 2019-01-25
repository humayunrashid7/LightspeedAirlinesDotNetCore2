using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LightspeedAirlinesDotNetCore2.Infrastructure
{
    public class SingaporeClient
    {
        public HttpClient Client { get; private set; }

        public SingaporeClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://apigw.singaporeair.com/api/v3/flightstatus/getbyroute");
            httpClient.DefaultRequestHeaders.Add("accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("apikey", "amgpaswg6qnvs8qh5exrrcsd");
//            httpClient.BaseAddress = new Uri("https://my-json-server.typicode.com/typicode/demo/posts");
            this.Client = httpClient;
        }
    }
}
