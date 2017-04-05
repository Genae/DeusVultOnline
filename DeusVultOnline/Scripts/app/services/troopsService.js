define(['angularAMD', 'angularResource'], function (angular) {
    angular.service('troopsService', function ($resource) {
        var r = {
            Items: $resource('api/troops/items', {}),
            ArmyGroup: $resource('api/troops/armyGroup/:id', { id: "@id" })


        }
        return r;

    });
});