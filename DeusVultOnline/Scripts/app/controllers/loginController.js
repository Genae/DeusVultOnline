define(['app', 'accountService'], function (app) {
    app.controller("loginController", function ($scope, $rootScope, $location, accountService) {
        $scope.username = "";
        $scope.email = "";
        $scope.password = "";
        $scope.password2 = "";
        $scope.error = "";
        $scope.register = false;

        $scope.registerUser = function () {
            $scope.error = "";
            accountService.Account.register({
                username: $scope.username,
                emailAdress: $scope.email,
                password: $scope.password,
                passwordConfirm: $scope.password2
            }, function (result) {
                $scope.error = result.Message;
            });
        }
        $scope.login = function () {
            $scope.error = "";
            accountService.Account.login({
                username: $scope.username,
                password: $scope.password
            }, function(result) {
                $scope.error = result.Message;
                if (result.Success) {
                    var previousUrl = $rootScope.previousPage;
                    if (previousUrl.indexOf('/#/login') === -1) {
                        $location.path(path);
                    }
                    else {
                        $location.path('/');
                    }
                }
            });
        }
    });
});