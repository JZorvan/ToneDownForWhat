'use strict';
app.factory('entryService', ['$http', 'localStorageService', '$rootScope', function ($http, localStorageService, $rootScope) {

    var serviceBase = 'http://localhost:51278/';
    var entryServiceFactory = {};

    var _getEntries = function () {

        console.log($rootScope.userToken);

        return $http({
            method: 'GET',
            url: serviceBase + 'api/entry',
            headers: {
                "authorization": 'Bearer ' + $rootScope.userToken
            }
        }).then(function successCallback(response) {
            return response;
        });
    };

    var _getSingleEntry = function (id) {

        return $http({
            method: 'GET',
            url: serviceBase + 'api/entry/' + id,
            headers: {
                "authorization": 'Bearer' + $rootScope.userToken
            }
        }).then(function successCallback(response) {
            return response;
        });
    };

    var _addNewEntry = function (entry) {

        var data = entry;

        return $http({
            method: 'POST',
            url: serviceBase + 'api/entry', data,
            headers: {
                "authorization": 'Bearer' + $rootScope.userToken
            }
        }).then(function successCallback(response) {
            return response;
        });
    };

    var _removeSingleEntry = function (id) {

        return $http({
            method: 'DELETE',
            url: serviceBase + 'api/entry/' + id,
            headers: {
                "authorization": 'Bearer' + $rootScope.userToken
            }
        }).then(function successCallback(response) {
            return response;
        });
    };

    entryServiceFactory.getEntries = _getEntries;
    entryServiceFactory.getSingleEntry = _getSingleEntry;
    entryServiceFactory.removeSingleEntry = _removeSingleEntry;
    entryServiceFactory.addNewEntry = _addNewEntry;

    return entryServiceFactory;
}]);