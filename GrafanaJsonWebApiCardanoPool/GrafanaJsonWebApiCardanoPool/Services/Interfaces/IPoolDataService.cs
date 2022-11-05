using GrafanaJsonWebApiCardanoPool.Models.Metrics;

namespace GrafanaJsonWebApiCardanoPool.Services.Interfaces
{
    public interface IPoolDataService
    {
        Task<List<MetricQueryModel>> QueryMetrics(string? metricPropertyName);
        public Task<List<MetricModel>> GetMetrics();
    }
}
