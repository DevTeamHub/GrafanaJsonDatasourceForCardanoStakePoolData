using Newtonsoft.Json;

namespace GrafanaJsonWebApiCardanoPool.Models.DataSource
{
    public class DataSourceResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("data")]
        public DataSourceModel Data { get; set; }

        [JsonProperty("terms")]
        public string Terms { get; set; }
    }
}
