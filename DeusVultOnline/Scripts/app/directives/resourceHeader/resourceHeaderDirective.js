define(['angularAMD', 'resourceHeaderController'], function (angularAMD) {
    angularAMD.directive("resourceHeader", function () {
        return {
            controller: "resourceHeaderController",
            templateUrl: "Scripts/app/directives/resourceHeader/resourceHeaderTemplate.html",
            scope: {
                first: '@',
                amount: '@',
                icon: '@'
            }
        }
    });
});