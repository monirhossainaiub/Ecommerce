﻿/// <reference path="../app.js" />
'use strict';

var urlService = ($rootScope) => {
    return {
        getUrlService: function (controllerName) {
            const ROOT_URL = "https://localhost:44317/";
            const PUBLIC_URL = "http://monirhost123-001-site1.dtempurl.com/";
            const FILE_URL = "https://localhost:44317/uploads/";
            const ROOT_URL_WITH_CONTROLLER = "https://localhost:44317/" + controllerName + "/";
            const POST_URL = ROOT_URL + controllerName + "/" + "create";
            const PUT_URL = ROOT_URL + controllerName + "/" + "edit/";
            const GET_URL = ROOT_URL + controllerName + "/" + "getall";
            const DETAILS_URL = ROOT_URL + controllerName + "/" + "details/";
            const DELETE_URL = ROOT_URL + controllerName + "/" + "delete/";

            return {
                rootUrl: ROOT_URL,
                fileUrl: FILE_URL,
                publicUrl: PUBLIC_URL,
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
