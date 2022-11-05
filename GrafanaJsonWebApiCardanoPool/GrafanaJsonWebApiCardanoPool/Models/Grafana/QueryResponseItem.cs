using Newtonsoft.Json;

namespace GrafanaJsonWebApiCardanoPool.Models.Grafana
{
    public class QueryResponseItem
    {
        [JsonProperty("target")]
        public string Target { get; set; }
        [JsonProperty("datapoints")]
        public List<string> DataPoints { get; set; }
    }
}
