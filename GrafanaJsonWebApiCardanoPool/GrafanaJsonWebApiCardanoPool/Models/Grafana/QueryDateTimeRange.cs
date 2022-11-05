using Newtonsoft.Json;

namespace GrafanaJsonWebApiCardanoPool.Models.Grafana
{
    public class QueryDateTimeRange
    {
        public QueryDateTimeRange(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }

        [JsonProperty("from")]
        public DateTime From { get; }

        [JsonProperty("to")]
        public DateTime To { get; }
    }
}
