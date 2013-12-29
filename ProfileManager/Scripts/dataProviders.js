metadataManager.service('profileFactory', function ($resource) {
    return $resource("api/profiles/:Id", { Id: "@Id" }, { "update": { method: "PUT" } });
});

metadataManager.service('mapServiceFactory', function ($resource) {
    return $resource("api/services/:Id", { Id: "@Id" }, { "update": { method: "PUT" } });
});


metadataManager.service('profileServiceFactory', function ($resource) {
    return $resource("api/profiles/:Id/mapServices", { Id: "@Id" }, { "update": { method: "PUT" } });
});

metadataManager.service('profileAdFactory', function ($resource) {
    return $resource("api/profiles/:Id/adGroups", { Id: "@Id" }, { "update": { method: "PUT" } });
});

metadataManager.service('profileEntitiesFactory', function ($resource) {
    return $resource("api/profiles/:Id/searchEntities", { Id: "@Id" }, { "update": { method: "PUT" } });
});


metadataManager.service('serviceLayerFactory', function ($resource) {
    return $resource("api/services/:Id/layers", { Id: "@Id" }, { "update": { method: "PUT" } });
});

metadataManager.service('serviceLayerDetailFactory', function($resource) {
    return $resource("api/maplayer/:Id", { Id: "@Id" }, { "update": { method: "PUT" } });
});