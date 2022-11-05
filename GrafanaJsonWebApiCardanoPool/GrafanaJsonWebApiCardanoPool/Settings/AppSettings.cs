namespace GrafanaJsonWebApiCardanoPool.Settings
{
    public class AppSettings
    {
        public string DataSourceUrlTemplate { get; set; }
        public string StakePoolId { get; set; }

        public string DataSourceUrl => DataSourceUrlTemplate.Replace("{StakePoolId}", StakePoolId);
    }
}