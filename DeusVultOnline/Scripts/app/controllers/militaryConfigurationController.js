define(['app', 'troopsService'], function (app) {
    app.controller("militaryConfigurationController", function ($scope, troopsService) {
        
        $scope.items = [];
        $scope.troopName = "";
        $scope.selectedItem = {};
        
        troopsService.Items.query(function (result) {
            $scope.items = result;
        });
    });
});