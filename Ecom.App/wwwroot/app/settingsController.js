/// <reference path="../angular/angular.js" />
/// <reference path="app.js" />
'use strict';

app.controller("settingsController", function ($scope, $rootScope) {
    $rootScope.domainUrl = "https://localhost:44317/";
    $rootScope.actions = {save: "create", edit: "edit", delelte: "delete"};
});