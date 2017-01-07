'use strict';
app.factory('entryService', ['$http', function ($http) {

    var serviceBase = 'http://localhost:52380/';
    var entryServiceFactory = {};

    var _getEntries = function () {

        return $http.get(serviceBase + 'api/entry').then(function (results) {
            return results;
        });
    };

    var _getSingleEntry = function (id) {
        return $http.get(serviceBase + 'api/entry/' + id).then(function (results) {
            return results;
        });
    };

    var _addNewEntry = function (entry) {
        var data = entry;

        $http.post(serviceBase + 'api/entry', data).then(function (results) {
            console.log(results);
        });
    };

    var _removeSingleEntry = function (id) {
        return $http.delete(serviceBase + 'api/entry/' + id).then(function (results) {
            return results;
        });
    };

    entryServiceFactory.getEntries = _getEntry;
    entryServiceFactory.getSingleEntry = _getSingleEntry;
    entryServiceFactory.removeSingleEntry = _removeSingleEntry;
    entryServiceFactory.addNewEntry = _addNewEntry;

    return entryServiceFactory;
}]);