define(['app', 'troopsService'], function (app) {
    app.controller("mainController", function ($scope, troopsService) {
        $scope.items = [];
        $scope.troopName = "";
        $scope.selectedItem = {};

        $scope.provinces = [
            { polygon: "200,10 250,190 160,210", name: "Erzburg", color: "rgb(100,0,100)" },
            { polygon: "200,10 160,210 140,150 100,160", name: "Hotzewotz", color: "rgb(100,100,100)" }
        ];

        $scope.message = troopsService.Items.query(function(result) {
            $scope.items = result;
        });
        $scope.clicked = function(province) {
            console.log(province.name);
        }
    });
});