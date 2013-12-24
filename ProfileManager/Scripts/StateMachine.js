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

