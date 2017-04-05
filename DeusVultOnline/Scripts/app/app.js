define(['angularAMD', 'angularRoute'], function (angularAMD) {
    var app = angular.module('app', ['ngRoute']);
    app.config(function ($routeProvider) {
        $routeProvider.when("/home", angularAMD.route({
                templateUrl: 'Pages/Home.html',
                controller: 'mainController'
            })
        );
        $routeProvider.when("/login", angularAMD.route({
            templateUrl: 'Pages/Login.html',
            controller: 'loginController'
        })
       );
    });
    //... // Setup app here. E.g.: run .config with $routeProvider
    return angularAMD.bootstrap(app);
});