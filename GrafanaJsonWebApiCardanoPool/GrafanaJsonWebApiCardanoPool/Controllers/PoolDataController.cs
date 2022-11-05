using GrafanaJsonWebApiCardanoPool.Models.Grafana;
using GrafanaJsonWebApiCardanoPool.Models.Metrics;
using GrafanaJsonWebApiCardanoPool.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GrafanaJsonWebApiCardanoPool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PoolDataController : ControllerBase
    {
        private readonly IPoolDataService _poolDataService;

        public PoolDataController(IPoolDataService poolDataService)
        {
            _poolDataService = poolDataService;
        }


        /// <summary>
        /// Is used for "Test connection" on the datasource config page.
        /// </summary>
        /// <returns>200 OK</returns>
        [HttpGet]
        public IActionResult Get() => Ok();

        /// <summary>
        /// Return metrics based on input
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("query")]
        public async Task<List<QueryResponseItem>> Query([FromBody] QueryRequest query)
        {
            var metricPropertyName = query.Targets.FirstOrDefault()?.Target;
            var metricItems = await _poolDataService.QueryMetrics(metricPropertyName);

            return new List<QueryResponseItem>(metricItems.Select(x => new QueryResponseItem
            {
                Target = x.Target,
                DataPoints = new List<string> { x.Value }
            }));
        }

        /// <summary>
        /// Return available metrics
        /// </summary>
        /// <returns>List of metrics</returns>
        [HttpPost("search")]
        public async Task<List<MetricModel>> Search()
        {
            return await _poolDataService.GetMetrics();
        }
    }
}