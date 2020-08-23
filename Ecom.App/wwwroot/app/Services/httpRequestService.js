/// <reference path="../app.js" />

'use strict';

var httpRequestService = ($http, urlService, $rootScope) => {
    return {
        getHttpRequestService: function (controllerName) {

            var service = urlService.getUrlService(controllerName);

            let getAll = () => {
                return $http.get(service.getUrl);
            }

            let getById = (id) => {
                return $http.get(service.detailsUrl + id);
            }

            let createEntity = (data) => {
                return $http.post(service.postUrl, JSON.stringify(data));
            }

            let updateEntity = (data) => {
                return $http.post(service.putUrl + data.id, JSON.stringify(data));
            }

            let deleteEntity = (data) => {
                return $http.post(service.deleteUrl + data.id, JSON.stringify(data));
            }

            return {
                getAll: getAll,
                getById: getById,
                createEntity: createEntity,
                updateEntity: updateEntity,
                deleteEntity: deleteEntity,
            }
        }
    }
    

    
};

app.factory('httpRequestService', httpRequestService);