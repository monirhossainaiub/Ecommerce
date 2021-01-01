/// <reference path="../app.js" />

'use strict';

var httpRequestService = ($http, urlService, $rootScope) => {
    return {
        getHttpRequestService: function (controllerName) {

            var service = urlService.getUrlService(controllerName);
            
            let getAll = () => {
                return $http.get(service.getUrl);
            }
            let getAllByUrl = (url) => {
                return $http.get(service.rootUrlWithController + url);
            }
            let getAllProvidingUrl = (url) => {
                return $http.get(service.rootUrlWithController + url);
            }

            let getAllProvidingDataUrl = (data, url) => {
                return $http.post(service.rootUrlWithController + url, JSON.stringify(data));
            }

            let getById = (id) => {
                return $http.get(service.detailsUrl + id);
            }

            let getByIdProvidingUrl = (id,url) => {
                return $http.get(service.rootUrlWithController + url + id);
            }

            let createEntity = (data) => {
                return $http.post(service.postUrl, JSON.stringify(data));
            }

            let createEntityProvidingDataUrl = (data,url) => {
                return $http.post(service.rootUrlWithController + url, JSON.stringify(data));
            }

            let updateEntity = (data) => {
                return $http.post(service.putUrl + data.id, JSON.stringify(data));
            }

            let updateEntityProvidingDataUrl = (data,url) => {
                return $http.post(service.rootUrlWithController + url, JSON.stringify(data));
            }

            let deleteEntity = (data) => {
                return $http.post(service.deleteUrl + data.id, JSON.stringify(data));
            }

            let deleteEntityProvidingDataUrl = (data,url) => {
                return $http.post(service.rootUrlWithController + url + data.id, JSON.stringify(data));
            }

            return {
                getAll: getAll,
                getAllByUrl: getAllByUrl,
                getById: getById,
                createEntity: createEntity,
                updateEntity: updateEntity,
                deleteEntity: deleteEntity,

                getAllProvidingUrl: getAllProvidingUrl,
                getByIdProvidingUrl: getByIdProvidingUrl,
                getAllProvidingDataUrl: getAllProvidingDataUrl,
                createEntityProvidingDataUrl: createEntityProvidingDataUrl,
                updateEntityProvidingDataUrl: updateEntityProvidingDataUrl,
                deleteEntityProvidingDataUrl: deleteEntityProvidingDataUrl                

            }
        }
        
    }
    

    
};

app.factory('httpRequestService', httpRequestService);