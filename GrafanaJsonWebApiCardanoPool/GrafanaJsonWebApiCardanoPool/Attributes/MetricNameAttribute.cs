namespace GrafanaJsonWebApiCardanoPool.Attributes
{
    public class MetricNameAttribute: Attribute
    {
        public MetricNameAttribute(string metricName)
        {
            MetricName = metricName;
        }
        public string MetricName { get; set; }
    }
}