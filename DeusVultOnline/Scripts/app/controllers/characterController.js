define(['app'], function (app) {
    app.controller("characterController", function ($scope) {


        let response = {
            "Name": "string",
            "Birthday": "2017-06-10T14:34:45.261Z",
            "Gender": "Male",
            "Id": "string",

            "Religion": {
                "SpellLevel": 0,
                "DivinePoints": 13,
                "SpentPoints": {
                    "total": 3,
                    "spellLevel": 1,
                    "inspiration": 0,
                    "combat": 0,
                    "knowledge": [{
                    }]
                },
                "RankName": "",
                "Faith": {},
                "God": "string"
            },
            "Genetics": {
                "Size": 0,
                "Intelligence": 0,
                "Beauty": 0,
                "Strength": 0,
                "Toughness": 0,
                "Magic": 0,
            },
            "Focus": "Marshall",
            "Attributes": {
                "Marshall": {
                    "Base": 0,
                    "Gen": 0,
                    "Edu": 0,
                    "Faith": 0,
                    "Lifest": 0,
                    "Temp": 0,
                    "Bonus": 0,
                    "Skill": 0,
                    "Equip": 0,
                    "Total": 0
                },
                "Diplomacy": {
                    "Base": 0,
                    "Gen": 0,
                    "Edu": 0,
                    "Faith": 0,
                    "Lifest": 0,
                    "Temp": 0,
                    "Bonus": 0,
                    "Skill": 0,
                    "Equip": 0,
                    "Total": 0
                },
                "Stewardship": {
                    "Base": 0,
                    "Gen": 0,
                    "Edu": 0,
                    "Faith": 0,
                    "Lifest": 0,
                    "Temp": 0,
                    "Bonus": 0,
                    "Skill": 0,
                    "Equip": 0,
                    "Total": 0
                },
                "Intrigue": {
                    "Base": 0,
                    "Gen": 0,
                    "Edu": 0,
                    "Faith": 0,
                    "Lifest": 0,
                    "Temp": 0,
                    "Bonus": 0,
                    "Skill": 0,
                    "Equip": 0,
                    "Total": 0
                },
                "Learning": {
                    "Base": 0,
                    "Gen": 0,
                    "Edu": 0,
                    "Faith": 0,
                    "Lifest": 0,
                    "Temp": 0,
                    "Bonus": 0,
                    "Skill": 0,
                    "Equip": 0,
                    "Total": 0
                },
                "Arts": {
                    "Base": 0,
                    "Gen": 0,
                    "Edu": 0,
                    "Faith": 0,
                    "Lifest": 0,
                    "Temp": 0,
                    "Bonus": 0,
                    "Skill": 0,
                    "Equip": 0,
                    "Total": 0
                },
                "Magic": {
                    "Base": 0,
                    "Gen": 0,
                    "Edu": 0,
                    "Faith": 0,
                    "Lifest": 0,
                    "Temp": 0,
                    "Bonus": 0,
                    "Skill": 0,
                    "Equip": 0,
                    "Total": 0
                },
                "Attraction": {
                    "Base": 0,
                    "Gen": 0,
                    "Edu": 0,
                    "Faith": 0,
                    "Lifest": 0,
                    "Temp": 0,
                    "Bonus": 0,
                    "Skill": 0,
                    "Equip": 0,
                    "Total": 0
                },
            },
            
            "Combat": {
                "XP": 5,
                "Skillpoints": 3,

                "Health": {
                    "Base": 0,
                    "Gen": 0,
                    "Lifest": 0,
                    "Skill": 0,
                    "Equip": 0,
                    "Total": 0
                },
                "Attack": {
                    "Base": 0,
                    "Gen": 0,
                    "Lifest": 0,
                    "Skill": 0,
                    "Equip": 0,
                    "Total": 0
                },
                "Dualwield": {
                    "Base": 0,
                    "Gen": 0,
                    "Lifest": 0,
                    "Skill": 0,
                    "Equip": 0,
                    "Total": 0
                },
                "Technique": {
                    "Base": 0,
                    "Gen": 0,
                    "Lifest": 0,
                    "Skill": 0,
                    "Equip": 0,
                    "Total": 0
                },
                "Armor": {
                    "Base": 0,
                    "Gen": 0,
                    "Lifest": 0,
                    "Skill": 0,
                    "Equip": 0,
                    "Total": 0
                },
                "Carry": {
                    "Base": 0,
                    "Gen": 0,
                    "Lifest": 0,
                    "Skill": 0,
                    "Equip": 0,
                    "Total": 0
                }
            }
        };

        $scope.resources = [
            {
                name: "gold",
                amount: 100
            },
            {
                name: "prestige",
                amount: 10
            },
            {
                name: "piety",
                amount: 5
            }
        ];

        troopsService.ArmyGroup.get({ id: "asdf" }, processArmyGroupRequest);

        $scope.clicked = function (province) {
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
        $scope.go = function (url) {
            $location.path(url);
        }

    });
});