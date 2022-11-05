namespace GrafanaJsonWebApiCardanoPool.Models.Metrics
{
    public class MetricQueryModel
    {
        public MetricQueryModel(string value, string target)
        {
            Value = value;
            Target = target;
        }

        public string Target { get; set; }
        public string Value { get; set; }
    }
}
