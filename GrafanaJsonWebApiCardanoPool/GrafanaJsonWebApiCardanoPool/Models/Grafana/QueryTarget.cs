using Newtonsoft.Json;

namespace GrafanaJsonWebApiCardanoPool.Models.Grafana
{
    public class QueryTarget
    {
        public QueryTarget(string target)
        {
            Target = target;
        }

        [JsonProperty("target")]
        public string Target { get; }
    }
}
