define(['angularAMD', 'angularResource'], function (angular) {
    angular.service('accountService', function ($resource) {
        var r = {
            Account: $resource("/api/account", {}, {
                register: { url: '/api/account/register', method: 'POST' },
                login: { url: '/api/account/signin', method: 'POST' }
            })
        }
        return r;
    });
});