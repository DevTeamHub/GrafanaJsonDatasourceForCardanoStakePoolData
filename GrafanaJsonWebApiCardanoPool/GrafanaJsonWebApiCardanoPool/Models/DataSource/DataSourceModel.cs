using System.ComponentModel;
using Newtonsoft.Json;

namespace GrafanaJsonWebApiCardanoPool.Models.DataSource
{
    public class DataSourceModel
    {
        [JsonProperty("pool_id")]
        [Description("pool.pool_id")]
        public string PoolId { get; set; }

        [JsonProperty("name")]
        [Description("pool.name")]
        public string PoolName { get; set; }

        [JsonProperty("stake")]
        [Description("pool.stake")]
        public string Stake { get; set; }

        [JsonProperty("stake_active")]
        [Description("pool.stake_active")]
        public string StakeActive { get; set; }

        [JsonProperty("pool_id_hash")]
        [Description("pool.pool_id_hash")]
        public string PoolIdHash { get; set; }

        [JsonProperty("tax_fix")]
        [Description("pool.tax_fix")]
        public string TaxFix { get; set; }

        [JsonProperty("blocks_epoch")]
        [Description("pool.blocks_epoch")]
        public string BlocksEpoch { get; set; }

        [JsonProperty("blocks_lifetime")]
        [Description("pool.blocks_lifetime")]
        public string BlocksLifetime { get; set; }

        [JsonProperty("roa_short")]
        [Description("pool.roa_short")]
        public string RoaShort { get; set; }

        [JsonProperty("roa_lifetime")]
        [Description("pool.roa_lifetime")]
        public string RoaLifetime { get; set; }

        [JsonProperty("pledge")]
        [Description("pool.pledge")]
        public string Pledge { get; set; }

        [JsonProperty("delegators")]
        [Description("pool.delegators")]
        public string Delegators { get; set; }

        [JsonProperty("position")]
        [Description("pool.position")]
        public string Position { get; set; }

        [JsonProperty("blocks_est_epoch")]
        [Description("pool.blocks_est_epoch")]
        public string BlocksEstEpoch { get; set; }

        [JsonProperty("luck_lifetime")]
        [Description("pool.luck_lifetime")]
        public string LuckLifetime { get; set; }

        [JsonProperty("saturation")]
        [Description("pool.saturation")]
        public string Saturation { get; set; }
    }
}