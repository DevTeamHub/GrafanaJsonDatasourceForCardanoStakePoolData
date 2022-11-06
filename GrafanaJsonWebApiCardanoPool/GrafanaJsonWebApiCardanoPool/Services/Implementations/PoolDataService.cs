using System.Reflection;
using GrafanaJsonWebApiCardanoPool.Controllers;
using GrafanaJsonWebApiCardanoPool.Models.DataSource;
using GrafanaJsonWebApiCardanoPool.Models.Metrics;
using GrafanaJsonWebApiCardanoPool.Services.Interfaces;
using GrafanaJsonWebApiCardanoPool.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using GrafanaJsonWebApiCardanoPool.Attributes;
using Microsoft.Extensions.Caching.Memory;

namespace GrafanaJsonWebApiCardanoPool.Services.Implementations
{
    public class PoolDataService : IPoolDataService
    {
        private readonly ILogger<PoolDataController> _logger;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        private const string PoolDataCacheKey = "PoolData";

        public PoolDataService(
            ILogger<PoolDataController> logger,
            IOptions<AppSettings> appSettings,
            HttpClient httpClient,
            IMemoryCache memoryCache)
        {
            _logger = logger;
            _appSettings = appSettings;
            _httpClient = httpClient;
            _memoryCache = memoryCache;
        }

        public async Task<List<MetricQueryModel>> QueryMetrics(string? metricPropertyName)
        {
            _logger.LogInformation($"The request for metrics: {metricPropertyName}");

            if(!_memoryCache.TryGetValue(PoolDataCacheKey, out DataSourceModel poolData))
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(_appSettings.Value.DataSourceUrl),
                    Method = HttpMethod.Get
                };
                var response = await _httpClient.SendAsync(request);
                var body = await response.Content.ReadAsStringAsync();
                var responseContent = JsonConvert.DeserializeObject<DataSourceResponse>(body);

                poolData = responseContent.Data;

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(_appSettings.Value.PoolDataCachePeriod));

                _memoryCache.Set(PoolDataCacheKey, poolData, cacheEntryOptions);
            }

            if (metricPropertyName != null)
            {

                var metricValueProperty = poolData.GetType().GetProperty(metricPropertyName);

                return new List<MetricQueryModel> { new MetricQueryModel(
                    metricValueProperty.GetValue(poolData, null),
                    metricValueProperty.GetCustomAttribute<MetricNameAttribute>().MetricName) };
            }

            return poolData.GetType().GetProperties().Select(x =>
                new MetricQueryModel(x.GetValue(poolData, null), x.GetCustomAttribute<MetricNameAttribute>().MetricName)).ToList();

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
