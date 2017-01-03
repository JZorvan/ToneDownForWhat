﻿'use strict';

var app = angular.module("ToneDown", ['ngRoute', 'LocalStorageModule']);

app.config(function ($routeProvider, $locationProvider) {

    $routeProvider.when("/", {
        controller: "homeController",
        templateUrl: "App/Partials/home.html"
    }).otherwise({ redirectTo: "/" });

    $locationProvider.html5Mode(true);
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);

app.controller('toneApiCtrl', function ($scope, $http) {

    $scope.userInput = "";
    $scope.analysis = [];

    $scope.analyzeTone = function () {

        var req = {
            method: "POST",
            headers: {
                "Content-Type": "text/plain",
                "Authorization": "Basic ZDhmNmRlODYtMGIwZi00MzE1LTg5YTItOTk3OWYyYTMxZmVhOjI1dHFlTEpOVko4Qg=="
            },
            url: "https://gateway.watsonplatform.net/tone-analyzer/api/v3/tone?version=2016-05-19&sentences=false"
        }
        
        var dataVar = $scope.userInput;

        $http({
            url: "http://cors-anywhere.herokuapp.com/https://gateway.watsonplatform.net/tone-analyzer/api/v3/tone?version=2016-05-19&sentences=false",
            method: "POST",
            data: dataVar,
            headers: {
                "Content-Type": "text/plain",
                "authorization": "Basic ZDhmNmRlODYtMGIwZi00MzE1LTg5YTItOTk3OWYyYTMxZmVhOjI1dHFlTEpOVko4Qg=="
            }
        })
                   .then(function (response) {
                       console.log($scope.userInput)
                       $scope.analysis = response;
                       console.log($scope.analysis);
                   }
                   , function (error) {
                       console.log("Call failed!");
                       debugger
                   });
    }

    return $scope.analysis;
});