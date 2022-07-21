using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace KOG.Intergration.Models.Common
{
    public class ResponseModel<T>
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("data")]
        public T? Data { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("errorDetails")]
        public IDictionary<string, string>? ErrorDetails { get; set; }

        public int HttpStatusCode { get; set; }
    }
}
