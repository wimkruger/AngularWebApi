metadataManager.controller('profileController', function ($scope, profileFactory) {
    $scope.myProfiles = [];

    function init() {
        $scope.myProfiles = profileFactory.query();
    }

    init();
});


metadataManager.controller('serviceController', function ($scope, mapServiceFactory) {
    $scope.mapServices = [];

    function init() {
        $scope.mapServices = mapServiceFactory.query();
    }

    init();
});



metadataManager.controller('profileDetailController', function ($scope, $stateParams, profileFactory) {
    $scope.currentProfile = {};
    function init() {
        $scope.currentProfile = profileFactory.get({ Id: $stateParams.profileId });
    }

    function save() {
        var ss = profileFactory.update($scope.currentProfile);
    }

    $scope.save = save;

    init();
});


metadataManager.controller('profileDetailMapServiceController', function ($scope, $stateParams, profileServiceFactory) {
    $scope.profileMapServices = [];
    function init() {
        $scope.profileMapServices = profileServiceFactory.query({ Id: $stateParams.profileId });
    }

    init();
});



metadataManager.controller('profileDetailAdController', function ($scope, $stateParams, profileAdFactory) {
    $scope.profileAdGroups = [];
    function init() {
        $scope.profileAdGroups = profileAdFactory.query({ Id: $stateParams.profileId });
    }

    init();
});


metadataManager.controller('profileEntitiesController', function ($scope, $stateParams, profileEntitiesFactory) {
    $scope.profileEntities = [];
    function init() {
        $scope.profileEntities = profileEntitiesFactory.query({ Id: $stateParams.profileId });
    }

    function save(id) {
        var result = jQuery.grep($scope.profileEntities, function (e) { return e.Id == id; })[0];
        deleteData = profileEntitiesFactory.update(result);
    }

    $scope.save = save;
    init();
});


metadataManager.controller('profileDetailMenuController', function ($scope, $stateParams, profileMenuFactory) {
    $scope.profileMenus = [];
    function init() {
        $scope.profileMenus = profileMenuFactory.query({ Id: $stateParams.profileId });
    }

    init();
});

metadataManager.controller('profileDetailMenuItemController', function ($scope, $stateParams, profileMenuItemFactory) {
    $scope.currentMenu = {};
    function init() {
        $scope.currentMenu = profileMenuItemFactory.get({ Id: $stateParams.menuId });
    }

    init();
});



metadataManager.controller('serviceDetailController', function ($scope, $stateParams, mapServiceFactory) {
    $scope.currentService = {};
    function init() {
        $scope.currentService = mapServiceFactory.get({ Id: $stateParams.serviceId });
    }
    
    function save() {
        var ss = mapServiceFactory.update($scope.currentService);
    }

    $scope.save = save;
    init();
});

metadataManager.controller('serviceDetailArcgisController', function ($scope, $stateParams, mapServiceFactory) {
    $scope.currentService = {};
    $scope.getLiveData = getLiveDataFunc;


    function getLiveDataFunc() {
        var url = "http://dapp03080/arcgis" + $scope.currentService.Url;
        window.open(url);
    }

    function init() {
        $scope.currentService = mapServiceFactory.get({ Id: $stateParams.serviceId });
    }

    init();

});


metadataManager.controller('serviceDetailParseArcgisController', function ($scope, $stateParams, serviceParserFactory, serviceLayerFactory) {

    $scope.parsedData = {};
    $scope.serviceLayers = [];

    function init() {
        var serviceParts = $scope.currentService.Url.split('/');
        $scope.parsedData = serviceParserFactory.get({ foldername: serviceParts[3], servicename: serviceParts[4] });
        $scope.serviceLayers = serviceLayerFactory.query({ Id: $stateParams.serviceId });
    }

    init();

});


metadataManager.controller('serviceDetailLayersController', function ($scope, $stateParams, serviceLayerFactory) {
    $scope.serviceLayers = [];
    function init() {
        $scope.serviceLayers = serviceLayerFactory.query({ Id: $stateParams.serviceId });
    }

    init();
});


metadataManager.controller('serviceDetailLayersDetailsController', function ($scope, $stateParams, serviceLayerDetailFactory) {
    $scope.currentLayer = {};

    function init() {
        $scope.currentLayer = serviceLayerDetailFactory.get({ Id: $stateParams.layerId });
    }
    
    function save() {
        var ss = serviceLayerDetailFactory.update($scope.currentLayer);
    }

    $scope.save = save;

    init();
});
