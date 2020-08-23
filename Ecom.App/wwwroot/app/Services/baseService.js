/// <reference path="../app.js" />
'use strict';

var showPopUpByPopId = (id) => {
    angular.element(document.querySelector("#" + id)).modal("show");
}
var hidePopUpByPopId = (id) => {
    angular.element(document.querySelector("#" + id)).modal("hide");
}
var baseService = () => {
    var service = {};
    service.showPopUpByPopId = showPopUpByPopId;
    service.hidePopUpByPopId = hidePopUpByPopId;

    return service;
}
app.factory('baseService', baseService);