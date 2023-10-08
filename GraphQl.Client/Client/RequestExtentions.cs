using Newtonsoft.Json;
using RestSharp;

namespace GraphQl.Client.Client
{
    public static class RequestExtentions
    {
        public static T? DeserializeResponse<T>(this RestResponse response)
        {
            string jsonResponse = response.Content!;
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
    }
}
