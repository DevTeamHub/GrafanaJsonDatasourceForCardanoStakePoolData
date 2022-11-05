using System.ComponentModel;
using GrafanaJsonWebApiCardanoPool.Attributes;
using Newtonsoft.Json;

namespace GrafanaJsonWebApiCardanoPool.Models.DataSource
{
    public class DataSourceModel
    {
        [JsonProperty("pool_id")]
        [MetricName("pool.pool_id")]
        public string PoolId { get; set; }

        [JsonProperty("name")]
        [MetricName("pool.name")]
        public string PoolName { get; set; }

        [JsonProperty("stake")]
        [MetricName("pool.stake")]
        public string Stake { get; set; }

        [JsonProperty("stake_active")]
        [MetricName("pool.stake_active")]
        public string StakeActive { get; set; }

        [JsonProperty("pool_id_hash")]
        [MetricName("pool.pool_id_hash")]
        public string PoolIdHash { get; set; }

        [JsonProperty("tax_fix")]
        [MetricName("pool.tax_fix")]
        public string TaxFix { get; set; }

        [JsonProperty("blocks_epoch")]
        [MetricName("pool.blocks_epoch")]
        public string BlocksEpoch { get; set; }

        [JsonProperty("blocks_lifetime")]
        [MetricName("pool.blocks_lifetime")]
        public string BlocksLifetime { get; set; }

        [JsonProperty("roa_short")]
        [MetricName("pool.roa_short")]
        public string RoaShort { get; set; }

        [JsonProperty("roa_lifetime")]
        [MetricName("pool.roa_lifetime")]
        public string RoaLifetime { get; set; }

        [JsonProperty("pledge")]
        [MetricName("pool.pledge")]
        public string Pledge { get; set; }

        [JsonProperty("delegators")]
        [MetricName("pool.delegators")]
        public string Delegators { get; set; }

        [JsonProperty("position")]
        [MetricName("pool.position")]
        public string Position { get; set; }

        [JsonProperty("blocks_est_epoch")]
        [MetricName("pool.blocks_est_epoch")]
        public string BlocksEstEpoch { get; set; }

        [JsonProperty("luck_lifetime")]
        [MetricName("pool.luck_lifetime")]
        public string LuckLifetime { get; set; }

        [JsonProperty("saturation")]
        [MetricName("pool.saturation")]
        public string Saturation { get; set; }
    }
}