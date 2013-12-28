var profileModule = angular.module('profileModule', ['ngResource', 'ngRoute']);



profileModule.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/profiles', {
                controller: 'profileController',
                templateUrl: 'Partials/profileList.html'
        })
        .when('/profiles/:profileId', {
            templateUrl: 'Partials/profileDetail.html',
            controller: 'profileDetailController'
        })
        .when('/services', {
            controller: 'serviceController',
            templateUrl: 'Partials/serviceList.html'
        })
        .when('/services/:serviceId', {
            templateUrl: 'Partials/serviceDetail.html',
            controller: 'serviceDetailController'
        })
        .otherwise({ redirectTo: '/profiles' });

}]);

profileModule.controller('profileController', function($scope, profileFactory) {
    $scope.profiles = [];

    function init() {
        $scope.profiles = profileFactory.query();
    }

    init();
});


profileModule.controller('profileDetailController', function ($scope, $routeParams, profileFactory, profileServiceFactory) {
    $scope.currentProfile = {};
    $scope.mapServices = [];
    function init() {
        $scope.currentProfile = profileFactory.get({ Id: $routeParams.profileId });
        $scope.mapServices = profileServiceFactory.query({ Id: $routeParams.profileId });
    }

    init();
});

profileModule.service('profileFactory', function ($resource) {
    return $resource("api/profiles/:Id", { Id: "@Id" }, { "update": { method: "PUT" } });
});

profileModule.controller('serviceController', function ($scope, mapServiceFactory) {
    $scope.mapServices = [];

    function init() {
        $scope.mapServices = mapServiceFactory.query();
    }

    init();
});

profileModule.controller('serviceDetailController', function ($scope, $routeParams, mapServiceFactory) {
    $scope.currentService = {};
    function init() {
        $scope.currentService = mapServiceFactory.get({ Id: $routeParams.serviceId });
    }

    init();
});



profileModule.service('mapServiceFactory', function ($resource) {
    return $resource("api/services/:Id", { Id: "@Id" }, { "update": { method: "PUT" } });
});

profileModule.service('profileServiceFactory', function ($resource) {
    return $resource("api/profiles/:Id/mapServices", { Id: "@Id" }, { "update": { method: "PUT" } });
});