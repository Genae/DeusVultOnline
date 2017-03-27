define(['angularAMD', 'angularRoute'], function (angularAMD) {
    var app = angular.module('app', ['ngRoute']);
    app.config(function ($routeProvider) {
        $routeProvider.when("/", angularAMD.route({
                templateUrl: 'Pages/Home.html',
                controller: 'mainController'
            })
        );
    });
    //... // Setup app here. E.g.: run .config with $routeProvider
    return angularAMD.bootstrap(app);
});