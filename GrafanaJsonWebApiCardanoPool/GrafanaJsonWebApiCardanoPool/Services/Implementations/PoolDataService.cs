using System.Reflection;
using GrafanaJsonWebApiCardanoPool.Controllers;
using GrafanaJsonWebApiCardanoPool.Models.DataSource;
using GrafanaJsonWebApiCardanoPool.Models.Metrics;
using GrafanaJsonWebApiCardanoPool.Services.Interfaces;
using GrafanaJsonWebApiCardanoPool.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using GrafanaJsonWebApiCardanoPool.Attributes;

namespace GrafanaJsonWebApiCardanoPool.Services.Implementations
{
    public class PoolDataService : IPoolDataService
    {
        private readonly ILogger<PoolDataController> _logger;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly HttpClient _httpClient;
        public PoolDataService(
            ILogger<PoolDataController> logger,
            IOptions<AppSettings> appSettings,
            HttpClient httpClient)
        {
            _logger = logger;
            _appSettings = appSettings;
            _httpClient = httpClient;
        }

        public async Task<List<MetricQueryModel>> QueryMetrics(string? metricPropertyName)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(_appSettings.Value.DataSourceUrl),
                Method = HttpMethod.Get
            };
            var response = await _httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();
            var responseContent = JsonConvert.DeserializeObject<DataSourceResponse>(body);

            var data = responseContent.Data;

            if (metricPropertyName != null)
            {

                var metricValueProperty = data.GetType().GetProperty(metricPropertyName);

                return new List<MetricQueryModel> { new MetricQueryModel(
                    metricValueProperty.GetValue(data, null),
                    metricValueProperty.GetCustomAttribute<MetricNameAttribute>().MetricName) };
            }

            return data.GetType().GetProperties().Select(x =>
                new MetricQueryModel(x.GetValue(data, null), x.GetCustomAttribute<MetricNameAttribute>().MetricName)).ToList();

        }

        public async Task<List<MetricModel>> GetMetrics()
        {
            var a = typeof(DataSourceModel).GetProperties();

            var metrics = new List<MetricModel>();
            foreach (var propertyInfo in typeof(DataSourceModel).GetProperties())
            {
                var metricName = propertyInfo.GetCustomAttribute<MetricNameAttribute>().MetricName;
                metrics.Add(new MetricModel(metricName, propertyInfo.Name));
            }

            return await Task.FromResult(metrics);
        }
    }
}
