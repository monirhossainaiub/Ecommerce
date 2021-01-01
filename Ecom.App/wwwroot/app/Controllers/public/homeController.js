/// <reference path="../../app.js" />
'use strict';
app.controller("homeController", ($scope, $http, urlService) => {

    var rootUrl = urlService.getUrlService().rootUrl;
    $scope.isResponseComplete = false;
    $scope.slides = 2;

    var products = {
        productPublisherId: 0,
        image: '',
        productName: '',
        productTitle: '',
        stockQuantity: 0,
        price: 0,
        oldPrice: 0,
        publisherId: 0,
        publisher: '',
        writerId: 0,
        writer: ''

    };
    var banner = {
        id: 0,
        title: '',
        displayOrder: 0,
        isActive: false,
        products: []
    };

    $scope.banners = [];
    
    var getBannersWithProducts = () => {
        try {
            $http.get(rootUrl + "Banner/GetBannersWithProducts").then(
                (response) => {
                    console.log(response.data);
                    $scope.banners = response.data;
                },
                (err) => {
                });
        } catch (e) {


        }

    }
    getBannersWithProducts();








});
