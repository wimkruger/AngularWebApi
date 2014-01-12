var loadingIndicatorApp = angular.module("loadingIndicatorApp", []);

loadingIndicatorApp.config(function ($httpProvider) {

    $httpProvider.interceptors.push(function ($q, $rootScope) {
        return {
            'request': function (config) {
                $rootScope.$broadcast('loading-started');
                return config || $q.when(config);
            },
            'response': function (response) {
                $rootScope.$broadcast('loading-complete');
                return response || $q.when(response);
            }
        };
    });

});


loadingIndicatorApp.directive("loadingIndicator", function () {
    return {
        restrict: "A",
//        template: "<div>Loading...</div>",
        link: function (scope, element, attrs) {
            scope.$on("loading-started", function (e) {
                element.css({ "display": "" });
            });

            scope.$on("loading-complete", function (e) {
                element.css({ "display": "none" });
            });

        }
    };
});

