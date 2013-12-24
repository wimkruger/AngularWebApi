namespace Domain
{
    public class MapLayer : Entity
    {
        public virtual string Name { get; set; }
        public virtual int LayerId { get; set; }
        public virtual int LayerOrder { get; set; }
        public virtual bool VisibleByDefault { get; set; }
        public virtual decimal? MinimumResolution { get; set; }
        public virtual decimal? MaximumResoultuion { get; set; }
        public virtual decimal? Opacity { get; set; }
        public virtual bool IsFeatureLayer { get; set; }
        public virtual string FeatureWhereClause { get; set; }
        public virtual string JavaObjectName { get; set; }
        public virtual string MapKeyFieldName { get; set; }
        public virtual string MapDisplayFieldName { get; set; }
        public virtual string FeatureRenderer { get; set; }
        public virtual bool? FeatureClusteredEnabled { get; set; }
        public virtual string FeatureClusteredForegroundSymbol { get; set; }
        public virtual string FeatureClusteredBackgroundSymbol { get; set; }
        public virtual bool? MapTipsEnabled { get; set; }
        public virtual string MapTipsText { get; set; }
        public virtual string JavascriptClickAction { get; set; }
        public virtual bool? DisableClientCache { get; set; }
    }
}