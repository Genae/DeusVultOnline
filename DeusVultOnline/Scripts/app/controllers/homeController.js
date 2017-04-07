define(['app', 'troopsService', 'emblemDirective'], function (app) {
    app.controller("homeController", function ($scope, troopsService) {

        $scope.provinces = [
            { polygon: "200,10 250,190 160,210", name: "Erzburg", color: "rgb(100,0,100)" },
            { polygon: "200,10 160,210 140,150 100,160", name: "Hotzewotz", color: "rgb(100,100,100)" }
        ];

        troopsService.ArmyGroup.get({ id: "asdf" }, processArmyGroupRequest);

        $scope.clicked = function(province) {
            console.log(province.name);
        }

        function processArmyGroupRequest(result) {
            $scope.leader = result.Leader;

            var baseArmies = [];

            if (result.Childs && result.Childs.length > 0) {
                result.Childs.forEach((child) => processChild(child, baseArmies));
                console.log('baseArmies: ' + JSON.stringify(baseArmies));
            }
            console.log('baseArmies: ' + JSON.stringify(baseArmies));
            $scope.baseArmies = baseArmies;
        }

        function processChild(child, armiesList) {

            if (child.Childs && child.Childs.length > 0) {
                console.log("child has still childs -> go on");
            } else {
                armiesList.push(child);
            }

        }

    });
});