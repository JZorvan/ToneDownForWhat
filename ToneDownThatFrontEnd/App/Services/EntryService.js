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

        //return $http.get(serviceBase + 'api/entry').then(function (results) {
        //    return results;
        //});
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

        //return $http.get(serviceBase + 'api/entry/' + id).then(function (results) {
        //    return results;
        //});
    };

    var _addNewEntry = function (entry) {

        var data = entry;

        // new
        return $http({
            method: 'POST',
            url: serviceBase + 'api/entry', data,
            headers: {
                "authorization": 'Bearer' + $rootScope.userToken
            }
        }).then(function successCallback(response) {
            return response;
        });

        // old
        //$http.post(serviceBase + 'api/entry', data).then(function (results) {
        //    console.log(results);
        //});
    };

    var _removeSingleEntry = function (id) {

        //new
        return $http({
            method: 'DELETE',
            url: serviceBase + 'api/entry/' + id,
            headers: {
                "authorization": 'Bearer' + $rootScope.userToken
            }
        }).then(function successCallback(response) {
            return response;
        });

        // old
        //return $http.delete(serviceBase + 'api/entry/' + id).then(function (results) {
        //    return results;
        //});
    };

    entryServiceFactory.getEntries = _getEntries;
    entryServiceFactory.getSingleEntry = _getSingleEntry;
    entryServiceFactory.removeSingleEntry = _removeSingleEntry;
    entryServiceFactory.addNewEntry = _addNewEntry;

    return entryServiceFactory;
}]);