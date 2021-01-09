/// <reference path="../../app.js" />
'use strict';
app.controller("homeController", ($scope, $mdSidenav, $http, urlService) => {

    $scope.toggleSideNav = function (navID) {
        $mdSidenav(navID).toggle();
    }

    $scope.name = 'work';

    var urlService = urlService.getUrlService();
    var rootUrl = urlService.rootUrl;
    var publicUrl = urlService.rootUrl;
    $scope.imageRootDirectory = urlService.fileUrl;
    
    console.log('rooturl: ' + rootUrl);
    console.log('fileUrl: ' + $scope.imageRootDirectory);
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
    $scope.products = [];
    $scope.writers = [];
    $scope.publishers = [];

    var getPublishers = () => {
        $http.get(rootUrl + "publisher/GetAll").then(
            (response) => {
               // console.log(response.data);
                $scope.publishers = response.data;
            },
            (err) => {
            });
    }
    getPublishers();
    var getWriters = () => {
        $http.get(rootUrl + "Writer/GetAll").then(
            (response) => {
                //console.log(response.data);
                $scope.writers = response.data;
            },
            (err) => {
            });
    }
    getWriters();
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

    var getproductListByPublisher = (id) => {
        try {
            $http.get(rootUrl + "product/GetProductsByPublisher/"+id)
                .then(
                (response) => {
                    $scope.products = response.data;
                },
                (err) => {
                });
        } catch (e) {


        }

    }
    getproductListByPublisher(9);
   

    //#region slick carousel
   
        $scope.data = ["http://placehold.it/350x300?text=1", "http://placehold.it/350x300?text=2", "http://placehold.it/350x300?text=3", "http://placehold.it/350x300?text=4", "http://placehold.it/350x300?text=5", "http://placehold.it/350x300?text=6"];





    //#endregion

});
