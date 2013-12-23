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
        .state('services', {
            url: '/services',
            templateUrl: 'Partials/serviceList.html',
            controller: 'serviceController'
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

metadataManager.controller('profileDetailController', function ($scope) {
    
});
