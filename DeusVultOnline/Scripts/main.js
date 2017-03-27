window.$ = window.jQuery = require(['vendors/jquery/jquery-3.2.0.min']);
require.config({
    paths: {
        //vendors
        "angular": 'vendors/angular/angular.min',
        "angularRoute": 'vendors/angular/angular-route.min',
        "angularResource": 'vendors/angular/angular-resource.min',
        "angularAMD": 'vendors/angular/angularAMD.min',
        "uiBootstrap": 'vendors/uiBootstrap/ui-bootstrap.min',

        //app
        "app": 'app/app',

        //controllers
        "mainController": 'app/controllers/mainController',

        //services
        "troopsService": 'app/services/troopsService'
    },
    shim: {
        'angularAMD': ['angular'],
        'angularRoute': ['angular'],
        'angularResource': ['angular']
    },
    deps: ['app']
});