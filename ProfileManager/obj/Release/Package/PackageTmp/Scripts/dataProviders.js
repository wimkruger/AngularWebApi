

metadataManager.service('profileFactory', function ($resource) {
    return $resource(rootUrl + "api/profiles/:Id", { Id: "@Id" }, { "update": { method: "PUT" } });
});

metadataManager.service('mapServiceFactory', function ($resource) {
    return $resource(rootUrl + "api/services/:Id", { Id: "@Id" }, { "update": { method: "PUT" } });
});


metadataManager.service('profileServiceFactory', function ($resource) {
    return $resource(rootUrl + "api/profiles/:Id/mapServices", { Id: "@Id" }, { "update": { method: "PUT" } });
});

metadataManager.service('profileAdFactory', function ($resource) {
    return $resource(rootUrl + "api/profiles/:Id/adGroups", { Id: "@Id" }, { "update": { method: "PUT" } });
});

metadataManager.service('profileEntitiesFactory', function ($resource) {
    return $resource(rootUrl + "api/profiles/:Id/permissions", { Id: "@Id" }, { "update": { method: "PUT" } });
});


metadataManager.service('serviceLayerFactory', function ($resource) {
    return $resource(rootUrl + "api/services/:Id/layers", { Id: "@Id" }, { "update": { method: "PUT" } });
});


metadataManager.service('profileMenuFactory', function ($resource) {
    return $resource(rootUrl + "api/profiles/:Id/menus", { Id: "@Id" }, { "update": { method: "PUT" } });
});


metadataManager.service('profileMenuItemFactory', function ($resource) {
    return $resource(rootUrl + "api/menu/:Id", { Id: "@Id" }, { "update": { method: "PUT" } });
});



metadataManager.service('serviceLayerDetailFactory', function($resource) {
    return $resource(rootUrl + "api/maplayer/:Id", { Id: "@Id" }, { "update": { method: "PUT" } });
});

metadataManager.service('serviceParserFactory', function ($resource) {
    return $resource("http://dapp03080/arcgis/rest/services/:foldername/:servicename/MapServer?f=pjson", { foldername: "@foldername", servicename: "@servicename" }, { "GET": { withCredentials: true, responseType : 'json' } });
});