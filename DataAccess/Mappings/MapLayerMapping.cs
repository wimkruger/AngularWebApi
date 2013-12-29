using Domain;
using FluentNHibernate.Mapping;

namespace DataAccess.Mappings
{
    public class MapLayerMapping : EntityMapping<MapLayer>
    {
         public MapLayerMapping() : base()
         {
             Table("MAP_LAYER");
             Map(x => x.DisableClientCache, "FEAT_DISABLE_CLIENT_CACHE");
             Map(x => x.FeatureClusteredBackgroundSymbol, "FEAT_CLUSTER_BG_COLOR");
             Map(x => x.FeatureClusteredEnabled, "FEAT_ENABLE_CLUSTERER");
             Map(x => x.FeatureClusteredForegroundSymbol, "FEAT_CLUSTER_FG_COLOR");
             Map(x => x.MapServiceId, "MAP_SERVICE_ID");
             Map(x => x.FeatureRenderer, "FEAT_RENDERER");
             Map(x => x.FeatureWhereClause, "FEAT_WHERE_CLAUSE");
             Map(x => x.IsFeatureLayer, "FEAT_LAYER_ENABLED");
             Map(x => x.JavaObjectName, "BUSINESS_OBJECT_NAME");
             Map(x => x.JavascriptClickAction, "FEAT_CLICK_ACTION_JS");
             Map(x => x.LayerId, "LAYER_ID");
             Map(x => x.LayerOrder, "LAYER_ORDER");
             Map(x => x.MapDisplayFieldName, "MAP_ID_DISP_FIELD_NAME");
             Map(x => x.MapKeyFieldName, "MAP_KEY_FIELD_NAME");
             Map(x => x.MapTipsEnabled, "FEAT_ENABLE_MAPTIPS");
             Map(x => x.MapTipsText, "FEAT_MAPTIP_TEXT");
             Map(x => x.MaximumResoultuion, "MAX_RESOLUTION");
             Map(x => x.MinimumResolution, "MIN_RESOLUTION");
             Map(x => x.Name, "LAYER_NAME");
             Map(x => x.Opacity, "OPACITY");
             Map(x => x.VisibleByDefault, "VISIBLE_BY_DEFAULT");
         }
    }
}