window.$ = window.jQuery = require(['vendors/jquery/jquery-3.2.0.min']);
require.config({
    paths: {
        //vendors
        "angular": 'vendors/angular/angular.min',

        //app
        "app": 'app/app',

        //controllers
        "mainController": 'app/controllers/mainController'
    },
    shim: {
        "angular": {
            exports: "angular"
        }
    }
});

require(['angular', 'app'],
    function () {
        angular.bootstrap(document, ['app']);
    }
);
