/// <reference path="../app.js" />

'use strict';

//controllerName is the server controller name that want to request 

var categoryService = ($http, urlService) => {

    const controllerName = "category";
    const service = urlService.getUrlService(controllerName);

    let getCategories = ()=> {
        return $http.get(service.getUrl);
    }

    let getCategoryById = (id)=> {
        return $http.get(service.detailsUrl + id);
    }

    let createCategory = (data)=> {
        return $http.post(service.postUrl, JSON.stringify(data));
    }

    let updateCategory = (id,data)=>
    {
        return $http.post(service.postUrl + id, JSON.stringify(data));
    }

    let deleteCategory = (data) => {
        return $http.post(service.deleteUrl + data.id, JSON.stringify(data));
    }

    return {
        getCategories: getCategories,
        getCategoryById: getCategoryById,
        createCategory: createCategory,
        updateCategory: updateCategory,
        deleteCategory: deleteCategory
    }
}

app.factory('categoryService', categoryService);