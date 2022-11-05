namespace GrafanaJsonWebApiCardanoPool.Models.Metrics
{
    public class MetricQueryModel
    {
        public MetricQueryModel(object? value, string target)
        {
            Value = value;
            Target = target;
        }

        public string Target { get; set; }
        public object? Value { get; set; }
    }
}
