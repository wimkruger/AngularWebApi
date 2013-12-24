namespace DataAccess.Dtos
{
    public class MapLayerDto :BaseDto
    {
        public string Name { get; set; }
        public int LayerId { get; set; }
        public int LayerOrder { get; set; }
        public bool VisibleByDefault { get; set; }
        public decimal? MinimumResolution { get; set; }
        public decimal? MaximumResoultuion { get; set; }
        public decimal? Opacity { get; set; }
        public bool IsFeatureLayer { get; set; }
        public string FeatureWhereClause { get; set; }
        public string JavaObjectName { get; set; }
        public string MapKeyFieldName { get; set; }
        public string MapDisplayFieldName { get; set; }
        public string FeatureRenderer { get; set; }
        public bool? FeatureClusteredEnabled { get; set; }
        public string FeatureClusteredForegroundSymbol { get; set; }
        public string FeatureClusteredBackgroundSymbol { get; set; }
        public bool? MapTipsEnabled { get; set; }
        public string MapTipsText { get; set; }
        public string JavascriptClickAction { get; set; }
        public bool? DisableClientCache { get; set; }
    }
}