/// <reference path="../app.js" />

'use strict';

app.controller("bannerController", ($scope, urlService, httpRequestService, messageService, baseService) =>
{
    //server controller name
    var controllerName = "banner";
    $scope.dataTableName = "Banners";
    var FormPopUp = "FormPopUp";
    var entityNameToPerform = "banner";
    $scope.isResponseComplete = false;
    $scope.action = "Save";
    $scope.dataSource = [];
    $scope.products = [];
    $scope.productsModel = [];
    $scope.addEntityTitle = "Add " + entityNameToPerform;
    $scope.formTitle = "Create a " + entityNameToPerform;
    $scope.records = [];

    //#region pagination
    $scope.searchText = "";
    $scope.itemsPerpage = 10;
    $scope.currentPage = 1;
    $scope.sortBy = function (column) {
        $scope.sortColumn = column;
        $scope.reverse = !$scope.reverse;
    }
    
    $scope.columns = [
        { title: 'Id', key: 'id', isSortable: true },
        { title: 'Title', key: 'title', isSortable: true },
        { title: 'Display Order', key: 'displayOrder', isSortable: true },
        { title: 'Active', key: 'isActive', isSortable: true },
        { title: 'Action', key: 'action', isSortable: false }
    ];
    //#endregion pagination 

    var defaultModel = {
        id: 0,
        title: null,
        isActive: true,
        displayOrder: 0
    };
    var product = {
        id: 0,
        product: null,
        publisher: null,
        price: 0,
        quantity: 0,
        image: null,
        bannerId: 0,
        isRegisterToBanner: false
    }
    $scope.model = angular.copy(defaultModel);
    $scope.productModel = angular.copy(product);

    var addToDataSource = (data) => {
        $scope.dataSource.push(data);
    }
    var updateDataSource = (data) => {
        for (var i = 0; i < $scope.dataSource.length; i++) {
            if ($scope.dataSource[i].id == data.id) {
                $scope.dataSource.splice(i, 1, data);
            }
        }
    }
    var removeFromDataSource = (data) => {
        for (var i = 0; i < $scope.dataSource.length; i++) {
            if ($scope.dataSource[i].id == data.id) {
                $scope.dataSource.splice(i, 1);
            }
        }
    }
    $scope.isExist = false;
    $scope.isExistName = () => {
        if ($scope.model.title == undefined) {
            $scope.isExist = false;
            return;
        }

        if ($scope.dataSource.length == 0) {
            $scope.isExist = false;
            return;
        }

        for (var i = 0; i < $scope.dataSource.length; i++) {
            if ($scope.model.id == 0 && $scope.dataSource[i].title.toLowerCase() == $scope.model.title.toLowerCase()) {
                $scope.isExist = true;
                return;
            }


            else if ($scope.model.id > 0) {
                if ($scope.model.id == $scope.dataSource[i].id && $scope.dataSource[i].title.toLowerCase() == $scope.model.title.toLowerCase()) {
                    $scope.isExist = false;
                    return;
                }
                else {
                    for (var j = 0; j < $scope.dataSource.length; j++) {
                        if ($scope.model.id == $scope.dataSource[j].id)
                            continue;
                        if ($scope.dataSource[j].title.toLowerCase() == $scope.model.title.toLowerCase()) {
                            $scope.isExist = true;
                            return;
                        }
                    }
                }
            }

        }
        $scope.isExist = false;
        return;
    }
    $scope.getAll = () => {
        httpRequestService.getHttpRequestService(controllerName).getAll()
            .then(
                (response) => {
                    $scope.isResponseComplete = true;
                    $scope.dataSource = response.data;
            },
                (err) => {
                    $scope.isResponseComplete = true;
                    messageService.error(err.status);
            });
    };
    $scope.getAll();
    $scope.formSubmit = ()=> {
        if (!$scope.form.$valid)
            return;

        if ($scope.action === "Save") {
            httpRequestService.getHttpRequestService(controllerName).createEntity($scope.model)
                .then(
                    (response) => {
                        $scope.reverse = true;
                        messageService.added(response.data.title);
                        addToDataSource(response.data);
                        $scope.productModel.bannerId = response.data.id;
                    }, (error) => {
                        messageService.error(error.status);
                    });
        }
        else if ($scope.action === "Update") {
            httpRequestService.getHttpRequestService(controllerName).updateEntity($scope.model)
                .then(
                    (response) => {
                        messageService.updated(response.data.title);
                        updateDataSource(response.data);
                    }, (error) => {
                        messageService.error(error.status);
                    });
        }
            
    };
    $scope.delete = (entity)=> {
        bootbox.confirm({
            message: "Are you sure? You want to delete " + "<b><i>" + entity.title + "</i></b>" + " permanently?",
            buttons: {
                confirm: {
                    label: '<i class="fa fa-check"></i> Confirm',
                    className: 'btn-success'
                },
                cancel: {
                    label: '<i class="fa fa-times"></i> No',
                    className: 'btn-danger'
                }
            },
            callback: (result)=>  {
                if (result) {
                    httpRequestService.getHttpRequestService(controllerName).deleteEntity(entity)
                        .then(
                            (result) => {
                                removeFromDataSource(result.data);
                                messageService.deleted(entity.title);
                            },
                            (error) => { messageService.error(error.status); }
                     );
                }
            }
        });
    };
    $scope.maxOrderBy = 0;
    $scope.getMaxOrderBy = () => {
        if ($scope.dataSource.length == 0)
            return;
        var max = $scope.dataSource[0].displayOrder;
        for (var i = 0; i < $scope.dataSource.length; i++) {
            if (max < $scope.dataSource[i].displayOrder) {
                max = $scope.dataSource[i].displayOrder;
            }
        }
        $scope.model.displayOrder = max + 1;
    }
    $scope.showFormPopUpForSave = () => {
        $scope.reset();
        $scope.getMaxOrderBy();
        $scope.action = "Save";
        baseService.showPopUpByPopId(FormPopUp);
    }
    $scope.showFormPopUp = (entity) => {
        $scope.reset();
        baseService.showPopUpByPopId(FormPopUp);
        $scope.model = angular.copy(entity);
        $scope.productModel.bannerId = $scope.model.id;
        $scope.action = "Update";
        $scope.formTitle = "Update the " + entityNameToPerform;
    }
    $scope.reset = () => {
        $scope.model = angular.copy(defaultModel);
        $scope.form.$setPristine();
        $scope.form.$setUntouched();
    };

    $scope.loadProducts = () => {
        if ($scope.model.id === 0)
            return;
       
        httpRequestService.getHttpRequestService(controllerName).getAllProvidingDataUrl($scope.productModel.bannerId,"getProducts")
            .then(
                (response) => {
                    $scope.products = response.data;
                    createImagePath();
                },
                (err) => {
                    messageService.error(err.status);
                });
    };

    var fileServiceUrl = urlService.getUrlService("banner");
    var createImagePath = () => {
        if ($scope.products.length > 0) {
            for (var i = 0; i < $scope.products.length; i++) {
                $scope.products[i].image = fileServiceUrl.rootUrl + "uploads/" + $scope.products[i].image;
                if ($scope.products[i].bannerId > 0 && $scope.products[i].bannerId === $scope.productModel.bannerId) {
                    $scope.products[i].isRegisterToBanner = true;
                }
            }
        }

    }

    //#region product pagination
    $scope.ProductsearchText = "";
    $scope.ProductitemsPerpage = 10;
    $scope.ProductcurrentPage = 1;
    $scope.ProductsortBy = function (column) {
        $scope.ProductsortColumn = column;
        $scope.Productreverse = !$scope.Productreverse;
    }

    $scope.productTableColumns = [
        { title: 'Id', key: 'id', isSortable: true },
        { title: 'Product', key: 'product', isSortable: true },
        { title: 'Publisher', key: 'publisher', isSortable: true },
        { title: 'Stock Quantity', key: 'quantity', isSortable: true },
        { title: 'Price', key: 'price', isSortable: true },
        { title: 'Photo', key: 'image', isSortable: true }
    ];
    //#endregion product pagination1

    var data = {
        bannerId: 0,
        productIds: []
    };

    $scope.registerProducts = () => {
        console.log($scope.products);
        data.bannerId = $scope.model.id;
        if ($scope.products.length > 0) {
            for (var i = 0; i < $scope.products.length; i++) {
                if ($scope.products[i].isRegisterToBanner == true) {
                    data.productIds.push($scope.products[i].id);
                }
            }
        }
        httpRequestService.getHttpRequestService(controllerName).createEntityProvidingDataUrl(data,"RegisterProducts")
            .then(
                (response) => {
                    messageService.added("Data is changed");
                }, (error) => {
                    messageService.error(error.status);
                });
    };
});
