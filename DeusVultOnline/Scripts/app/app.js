define(['angularAMD', 'angularRoute'], function (angularAMD) {
    var app = angular.module('app', ['ngRoute']);
    var interceptor = function ($q, $location) {
        return {
            request: function (req) {
                return req;
            },
            responseError: function (rejection) {
                if (rejection.status === 401) {
                    $location.path('/login');
                }

                return $q.reject(rejection);
            }
        }
    };

    app.config(function ($routeProvider, $httpProvider) {
        $routeProvider.when("/home", angularAMD.route({
            templateUrl: 'Pages/Home.html',
            controller: 'homeController'
        }));
        $routeProvider.when("/login", angularAMD.route({
            templateUrl: 'Pages/Login.html',
            controller: 'loginController'
        }));
        $routeProvider.when("/military", angularAMD.route({
            templateUrl: 'Pages/MilitaryConfiguration.html',
            controller: 'militaryConfigurationController'
        }));
        $routeProvider.otherwise("/home");
        $httpProvider.interceptors.push(interceptor);
    });

    app.run(['$rootScope', function ($rootScope) {
        $rootScope.$on('$locationChangeStart', function (evt, absNewUrl, absOldUrl) {
            $rootScope.previousPage = absOldUrl;
        });
    }]);

    //... // Setup app here. E.g.: run .config with $routeProvider
    return angularAMD.bootstrap(app);
});