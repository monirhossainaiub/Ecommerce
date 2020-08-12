/// <reference path="angular/angular.js" />


'use strict';
var app = angular.module("app", []);

app.controller("myTestController", function myTestController($scope) {
    $scope.message = "Successfully added angularjs";
});