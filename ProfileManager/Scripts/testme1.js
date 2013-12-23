var myApp = angular.module('myApp', ['ui.router']);
myApp.config(function($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/profiles');

    $stateProvider
        .state('profiles', {
            url: '/profiles',
            templateUrl: 'partials/profileList.html'
        })
        .state('services', {
            url: '/services',
            templateUrl: 'partials/serviceList.html'
        });
});