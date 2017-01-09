'use strict';

var app = angular.module("ToneDown", ['ngRoute', 'LocalStorageModule']);

app.config(function ($routeProvider, $locationProvider) {

    $routeProvider.when("/", {
        controller: "homeController",
        templateUrl: "/App/Partials/Home.html"
    }).when("/register", {
        controller: "signupController",
        templateUrl: "/App/Partials/Register.html"
    }).when("/signin", {
        controller: "loginController",
        templateUrl: "/App/Partials/Signin.html"
    }).otherwise({ redirectTo: "/" });

    $locationProvider.html5Mode(true);
});

//app.config(function ($httpProvider) {
 //   $httpProvider.interceptors.push('authInterceptorService');
//});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);

app.controller('toneApiCtrl', function ($scope, $http, entryService) {

    $scope.userInput = "";

    $scope.userEntries = {};

    $scope.getUserEntries = function () {
        entryService.getEntries().then(function (response) {
            console.log(response);
        });
    };

    $scope.analyzeTone = function () {
        
        var userRequest = $scope.userInput;

        $http({
            url: "http://cors-anywhere.herokuapp.com/https://gateway.watsonplatform.net/tone-analyzer/api/v3/tone?version=2016-05-19&sentences=false",
            method: "POST",
            data: userRequest,
            headers: {
                "Content-Type": "text/plain",
                "authorization": "Basic ZDhmNmRlODYtMGIwZi00MzE1LTg5YTItOTk3OWYyYTMxZmVhOjI1dHFlTEpOVko4Qg=="
            }
        })
                   .then(function (response) {
                       $scope.analysis = response.data;
                       $scope.anger = Math.round(parseFloat($scope.analysis.document_tone.tone_categories[0].tones[0].score) * 100);
                       $scope.disgust = Math.round(parseFloat($scope.analysis.document_tone.tone_categories[0].tones[1].score) * 100);
                       $scope.fear = Math.round(parseFloat($scope.analysis.document_tone.tone_categories[0].tones[2].score) * 100);
                       $scope.joy = Math.round(parseFloat($scope.analysis.document_tone.tone_categories[0].tones[3].score) * 100);
                       $scope.sadness = Math.round(parseFloat($scope.analysis.document_tone.tone_categories[0].tones[4].score) * 100);
                       $scope.openness = Math.round(parseFloat($scope.analysis.document_tone.tone_categories[2].tones[0].score) * 100);
                       $scope.conscientiousness = Math.round(parseFloat($scope.analysis.document_tone.tone_categories[2].tones[1].score) * 100);
                       $scope.extraversion = Math.round(parseFloat($scope.analysis.document_tone.tone_categories[2].tones[2].score) * 100);
                       $scope.agreeableness = Math.round(parseFloat($scope.analysis.document_tone.tone_categories[2].tones[3].score) * 100);
                       $scope.emotionalrange = Math.round(parseFloat($scope.analysis.document_tone.tone_categories[2].tones[4].score) * 100);
                       console.log($scope.joy);
                   }
                   , function (error) {
                       console.log("Call failed!");
                       debugger
                   });
    }

    return $scope.analysis;
});