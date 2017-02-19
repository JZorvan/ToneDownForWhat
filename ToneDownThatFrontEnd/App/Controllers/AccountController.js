'use strict';
app.controller('accountController', ['$scope', '$location', 'authService', 'entryService', '$rootScope', function ($scope, $location, authService, entryService, $rootScope) {

    $scope.Entries = [];

    $scope.getUserEntries = function () {
        entryService.getEntries().then(function (results) {
            $scope.Entries.length = 0;
            $scope.Entries = results.data;
        }, function (error) {
            console.log(error);
        });
    };

    //$scope.getUserEntries();
}]);