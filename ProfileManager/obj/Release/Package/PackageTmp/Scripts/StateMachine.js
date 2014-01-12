var rootUrl = window.location.href.replace(window.location.hash, '');

var metadataManager = angular.module('metadataManager', ['ngResource', 'ui.router'])
    .run(['$rootScope', '$state', '$stateParams',
        function($rootScope, $state, $stateParams) {
            $rootScope.$state = $state;
            $rootScope.$stateParams = $stateParams;
        }
    ]);


metadataManager.config(function ($stateProvider, $urlRouterProvider) {
    $stateProvider
        .state('profiles', {
            url: '/profiles',
            abstract: true,
            templateUrl: rootUrl + 'Partials/profile.html'
        })
        .state('profiles.list', {
            url: '',
            templateUrl: rootUrl + 'Partials/profileList.html',
            controller: 'profileController'
        })
        .state('profiles.details', {
            url: '/{profileId:[0-9]{1,4}}',
            templateUrl: rootUrl + 'Partials/profileDetail.html',
            controller: 'profileDetailController'
        })
        .state('profiles.details.mapServices', {
            url: '/mapServices',
            templateUrl: rootUrl + 'Partials/profileMapServices.html',
            controller: 'profileDetailMapServiceController'
        })
        .state('profiles.details.ad', {
            url: '/ad',
            templateUrl: rootUrl + 'Partials/profileAdGroups.html',
            controller: 'profileDetailAdController'
        })
        .state('profiles.details.entities', {
            url: '/entities',
            templateUrl: rootUrl + 'Partials/profilePermissions.html',
            controller: 'profileEntitiesController'
        })
        .state('profiles.details.menus', {
            url: '/menus',
            templateUrl: rootUrl + 'Partials/profileMenus.html',
            controller: 'profileDetailMenuController'
        })
        .state('profiles.details.menus.items', {
            url: '/{menuId:[0-9]{1,4}}',
            templateUrl: rootUrl + 'Partials/menuItem.html',
            controller: 'profileDetailMenuItemController'
        })
        .state('services', {
            url: '/services',
            abstract: true,
            templateUrl: rootUrl + 'Partials/services.html'
        })
        .state('services.list', {
            url: '',
            templateUrl: rootUrl + 'Partials/serviceList.html',
            controller: 'serviceController'
        })
        .state('services.details', {
            url: '/{serviceId:[0-9]{1,4}}',
            templateUrl: rootUrl + 'Partials/serviceDetail.html',
            controller: 'serviceDetailController'
        })
        .state('services.details.liveServer', {
            url: '/arcgisServer',
            templateUrl: rootUrl + 'Partials/serviceArcgisServer.html',
            controller: 'serviceDetailArcgisController'
        })
        .state('services.details.layers', {
            url: '/layers',
            templateUrl: rootUrl + 'Partials/serviceLayers.html',
            controller: 'serviceDetailLayersController'
        })
        .state('services.details.layers.details', {
            url: '/{layerId:[0-9]{1-4}}',
            templateUrl: rootUrl + 'Partials/serviceLayerDetails.html',
            controller: 'serviceDetailLayersDetailsController'
        })
        .state('services.details.parseArcgis', {
            url: '/parseArcgisServer',
            templateUrl: rootUrl + 'Partials/serviceArcgisServerParser.html',
            controller: 'serviceDetailParseArcgisController'
        });


});

