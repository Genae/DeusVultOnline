define(['app', 'accountService'], function (app) {
    app.controller("loginController", function ($scope, accountService) {
        $scope.username = "";
        $scope.password = "";
        $scope.message = "";

        $scope.login = function () {
            $scope.message = "";
            accountService.Account.login({
                username: $scope.username,
                password: $scope.password
            }, function(result) {
                $scope.message = result.Message;
            });
        }
    });
});