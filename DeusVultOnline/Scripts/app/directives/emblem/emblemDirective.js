define(['angularAMD', 'emblemController'], function (angularAMD) {
    angularAMD.directive("emblem", function () {
        return {
            controller: "emblemController",
            templateUrl: "Scripts/app/directives/emblem/emblemTemplate.html",
            scope: {
                emblemNum: '@',
                backgroundColor: '@',
                color1: '@',
                color2: '@'
            }
        }
    });
});