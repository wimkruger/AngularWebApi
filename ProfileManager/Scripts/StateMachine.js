var metadataManager = angular.module('metadataManager', ['ngResource', 'ngRoute', 'ui.router'])
    .run(['$rootScope', '$state', '$stateParams',
        function($rootScope, $state, $stateParams) {
            $rootScope.$state = $state;
            $rootScope.$stateParams = $stateParams;
        }
    ]);

metadataManager.config(function($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/profiles');

    $stateProvider
        .state('profiles', {
            url: '/profiles',
            abstract: true,
            templateUrl: 'Partials/profile.html'
        })
        .state('profiles.list', {
            url: '',
            templateUrl: 'Partials/profileList.html',
            controller: 'profileController'
        })
        .state('profiles.details', {
            url: '/{profileId:[0-9]{1,4}}',
            templateUrl: 'Partials/profileDetail.html',
            controller: 'profileDetailController'
        })
        .state('profiles.details.mapServices', {
            url: '/mapServices',
            templateUrl: 'Partials/profileMapServices.html',
            controller: 'profileDetailMapServiceController'
        })
        .state('profiles.details.ad', {
            url: '/ad',
            templateUrl: 'Partials/profileAdGroups.html',
            controller: 'profileDetailAdController'
        })
        .state('profiles.details.entities', {
            url: '/entities',
            templateUrl: 'Partials/profileEntities.html',
            controller: 'profileEntitiesController'
        })
        .state('services', {
            url: '/services',
            abstract: true,
            templateUrl: 'Partials/services.html'
        })
        .state('services.list', {
            url: '',
            templateUrl: 'Partials/serviceList.html',
            controller: 'serviceController'
        })
        .state('services.details', {
            url: '/{serviceId:[0-9]{1,4}}',
            templateUrl: 'Partials/serviceDetail.html',
            controller: 'serviceDetailController'
        })
        .state('services.details.liveServer', {
            url: '/arcgisServer',
            templateUrl: 'Partials/serviceArcgisServer.html',
            controller: 'serviceDetailArcgisController'
        })
        .state('services.details.layers', {
            url: '/layers',
            templateUrl: 'Partials/serviceLayers.html',
            controller: 'serviceDetailLayersController'
        });        


});

metadataManager.controller('profileController', function ($scope, profileFactory) {
    $scope.myProfiles = [];

    function init() {
        $scope.myProfiles = profileFactory.query();
    }

    init();
});

metadataManager.service('profileFactory', function ($resource) {
    return $resource("api/profiles/:Id", { Id: "@Id" }, { "update": { method: "PUT" } });
});

metadataManager.controller('serviceController', function ($scope, mapServiceFactory) {
    $scope.mapServices = [];

    function init() {
        $scope.mapServices = mapServiceFactory.query();
    }

    init();
});


metadataManager.service('mapServiceFactory', function ($resource) {
    return $resource("api/services/:Id", { Id: "@Id" }, { "update": { method: "PUT" } });
});

metadataManager.controller('profileDetailController', function ($scope, $stateParams, profileFactory) {
    $scope.currentProfile = {};
    function init() {
        $scope.currentProfile = profileFactory.get({ Id: $stateParams.profileId });
    }

    init();
});


metadataManager.controller('profileDetailMapServiceController', function ($scope, $stateParams, profileServiceFactory) {
    $scope.profileMapServices = [];
    function init() {
        $scope.profileMapServices = profileServiceFactory.query({ Id: $stateParams.profileId });
    }

    init();
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

    init();
});

metadataManager.controller('serviceDetailController', function ($scope, $stateParams, mapServiceFactory) {
    $scope.currentService = {};
    function init() {
        $scope.currentService = mapServiceFactory.get({ Id: $stateParams.serviceId });
    }

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

metadataManager.service('serviceLayerFactory', function ($resource) {
    return $resource("api/services/:Id/layers", { Id: "@Id" }, { "update": { method: "PUT" } });
});

metadataManager.controller('serviceDetailLayersController', function ($scope, $stateParams, serviceLayerFactory) {
    $scope.serviceLayers = [];
    function init() {
        $scope.serviceLayers = serviceLayerFactory.query({ Id: $stateParams.serviceId });
    }

    init();
});
