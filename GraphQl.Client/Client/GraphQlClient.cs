using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace GraphQl.Client.Client
{
    public class GraphQlClient
    {
        private readonly RestClient restClient;
        private readonly RestRequest request;

        #region Constructors

        public GraphQlClient()
        {
            restClient = new RestClient();
            request = new RestRequest() { Method = Method.Post };
        }

        public GraphQlClient(RestClientOptions options)
        {
            restClient = new RestClient(options);
            request = new RestRequest() { Method = Method.Post };
        }

        public GraphQlClient(string baseUrl)
        {
            var options = new RestClientOptions(baseUrl);
            restClient = new RestClient(options);
            request = new RestRequest() { Method = Method.Post };
        }

        #endregion

        #region Headers

        public GraphQlClient AddHeader(KeyValuePair<string, string> header)
        {
            restClient.AddDefaultHeader(header.Key, header.Value);
            return this;
        }

        public GraphQlClient AddHeader(string key, string value)
        {
            restClient.AddDefaultHeader(key, value);
            return this;
        }

        public GraphQlClient AddHeaders(Dictionary<string, string> headers)
        {
            restClient.AddDefaultHeaders(headers); 
            return this;
        }

        #endregion

        #region Cookies

        public GraphQlClient AddCookie(string name, string value, string path, string domain)
        {
            request.AddCookie(name, value, path, domain);
            return this;
        }

        public GraphQlClient AddCookies(CookieContainer cookieContainer) 
        {
            request.CookieContainer = cookieContainer;
            return this; 
        }

        #endregion

        #region Method

        public GraphQlClient AddMethod(Method method)
        {
            request.Method = method;
            return this;
        }

        #endregion

        #region Body

        public GraphQlClient AddBody(string queryString)
        {
            request.AddBody(new { query = queryString });
            return this;
        }

        public GraphQlClient AddBody<T>(T query)
        {
            string jsonBody = JsonConvert.SerializeObject(query);
            request.AddBody(jsonBody, "application/json");
            return this;
        }

        #endregion

        #region Send request

        public RestResponse SendQueryRequest()
        {
            RestResponse response = restClient.Post(request);
            return response;
        }

        public RestResponse SendQueryRequest(string queryString)
        {

            var request = new RestRequest()
            {
                Method = Method.Post
            }
            .AddBody(new { query = queryString });

            RestResponse response = restClient.Post(request);
            return response;
        }

        #endregion
    }
}
