/// <reference path="../app.js" />
'use strict';

var urlService = ($rootScope) => {
    return {
        getUrlService: function (controllerName) {
            const ROOT_URL = "http://mh809971-001-site1.btempurl.com/"
            const ROOT_URL_WITH_CONTROLLER = "http://mh809971-001-site1.btempurl.com/" + controllerName + "/";
            const POST_URL = ROOT_URL + controllerName + "/" + "create";
            const PUT_URL = ROOT_URL + controllerName + "/" + "edit/";
            const GET_URL = ROOT_URL + controllerName + "/" + "getall";
            const DETAILS_URL = ROOT_URL + controllerName + "/" + "details/";
            const DELETE_URL = ROOT_URL + controllerName + "/" + "delete/";

            return {
                rootUrl: ROOT_URL,
                rootUrlWithController: ROOT_URL_WITH_CONTROLLER,
                postUrl: POST_URL,
                putUrl: PUT_URL,
                getUrl: GET_URL,
                detailsUrl: DETAILS_URL,
                rootUrl: ROOT_URL,
                deleteUrl: DELETE_URL
            }
        }
    }
};

app.factory('urlService', urlService);
