using Newtonsoft.Json;

namespace GrafanaJsonWebApiCardanoPool.Models.Metrics
{
    public class MetricModel
    {
        public MetricModel(string text, string value)
        {
            Text = text;
            Value = value;
        }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}