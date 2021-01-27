/// <reference path="../app.js" />

'use strict';

app.controller("productController", ($scope, $http, httpRequestService, messageService, baseService, urlService) =>
{
    //server controller name
    var controllerName = "product";
    $scope.dataTableName = "Products";
    var FormPopUp = "FormPopUp";
    var entityNameToPerform = "product";
    $scope.isExist = false;
    $scope.isIsbnExist = false;
    $scope.isResponseComplete = false;
    $scope.action = "Save";
    $scope.ppAction = "Save";
    

    $scope.dataSource = [];
    $scope.countries = [];
    $scope.languages = [];
    $scope.writers = [];
    $scope.categories = [];
    $scope.publishers = [];
    $scope.photos = [];

    $scope.addEntityTitle = "Add " + entityNameToPerform;
    $scope.formTitle = "Create a " + entityNameToPerform;
 
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
        { title: 'Photo', key: 'photo', isSortable: false },
        { title: 'Name', key: 'name', isSortable: true },
        //{ title: 'Language', key: 'language', isSortable: true },
        { title: 'Category', key: 'category', isSortable: true },
        { title: 'Writer', key: 'writer', isSortable: true },
        { title: 'Publisher', key: 'publisher', isSortable: true },
        { title: 'SKU', key: 'sku', isSortable: true },
        { title: 'Price', key: 'price', isSortable: true },
        { title: 'Qnt.', key: 'quantity', isSortable: true },
        { title: 'Action', key: 'action', isSortable: false }
    ];
    //#endregion pagination 
    ////$scope.getId = function (id) {
    ////    $http.get(httpRequestService.getHttpRequestService(controllerName).getByIdProvidingUrl(id, "GetDetails/")).then(
    ////        (response) => {
    ////            console.log('product:');
    ////            console.log(response.data);
    ////            $scope.publishers = response.data;
    ////        },
    ////        (err) => {
    ////            console.log('err'+ err);
    ////        });
    ////}

    var defaultModel = {
        id: 0,
        name: null,
        title: null,
        country: null,
        countryId: 0,
        categoryId: 0,
        categoryId: 0,
        languageId: 0,
        publisherId: 0,
        //language: null,
        //description : null,
        displayOrder: 0,
        sku:null,
        publisher: null,
        photo:null,
        price: 0,
        costPrice: 0,
        oldPrice: 0,
        stockQuantity: 0
    };

    var productPublisher = {
        id: 0,
        publisherId: 0,
        productId: 0,
        isbn: null,
        edition: null,
        sku: null,
        countryId: 0,
        price: 0,
        oldPrice: 0,
        costPrice: 0,
        numberOfPage: 0,
        stockQuantity: 0,
        orderMinimumQuantity: 1,
        orderMaximumQuantity: 0,
        notifyForMinimumQuantityBellow: 0,
        languageId: 0,
        description : null,

        isNewProduct: true,
        isPublished: true,
        isAproved: true,
        isReturnAble: true,
        isShippingChargeApplicable: true,
        isLimitedToStore: true,
    };

    $scope.model = angular.copy(defaultModel);
    $scope.productPublisherModel = angular.copy(productPublisher);

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

    $scope.isExistISBN = () => {
        if ($scope.model.name == undefined) {
            $scope.isIsbnExist = false;
            return;
        }

        if ($scope.dataSource.length == 0) {
            $scope.isIsbnExist = false;
            return;
        }

        for (var i = 0; i < $scope.dataSource.length; i++) {
            if ($scope.model.id == 0 && $scope.dataSource[i].name.toLowerCase() == $scope.model.name.toLowerCase()) {
                $scope.isIsbnExist = true;
                return;
            }


            else if ($scope.model.id > 0) {
                if ($scope.model.id == $scope.dataSource[i].id && $scope.dataSource[i].name.toLowerCase() == $scope.model.name.toLowerCase()) {
                    $scope.isIsbnExist = false;
                    return;
                }
                else {
                    for (var j = 0; j < $scope.dataSource.length; j++) {
                        if ($scope.model.id == $scope.dataSource[j].id)
                            continue;
                        if ($scope.dataSource[j].name.toLowerCase() == $scope.model.name.toLowerCase()) {
                            $scope.isIsbnExist = true;
                            return;
                        }
                    }
                }


            }

        }
        $scope.isIsbnExist = false;
        return;
    }
    $scope.isExistName = () => {
        if ($scope.model.name == undefined) {
            $scope.isExist = false;
            return;
        }
            
        if ($scope.dataSource.length == 0) {
            $scope.isExist = false;
            return;
        }
        
        for (var i = 0; i < $scope.dataSource.length; i++) {
            if ($scope.model.id == 0 && $scope.dataSource[i].name.toLowerCase() == $scope.model.name.toLowerCase()) {
                $scope.isExist = true;
                return;
            }
                

            else if ($scope.model.id > 0) {
                if ($scope.model.id == $scope.dataSource[i].id && $scope.dataSource[i].name.toLowerCase() == $scope.model.name.toLowerCase()) {
                    $scope.isExist = false;
                    return;
                }
                else {
                    for (var j = 0; j < $scope.dataSource.length; j++) {
                        if ($scope.model.id == $scope.dataSource[j].id)
                            continue;
                        if ($scope.dataSource[j].name.toLowerCase() == $scope.model.name.toLowerCase()) {
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

    $scope.getCountries = () => {
        httpRequestService.getHttpRequestService("country").getAll()
            .then(
                (response) => {
                    
                    $scope.countries = response.data;
                },
                (err) => {
                    messageService.error(err.status);
                });
    };
    $scope.getLanguages = () => {
        httpRequestService.getHttpRequestService("language").getAll()
            .then(
                (response) => {

                    $scope.languages = response.data;
                },
                (err) => {
                    messageService.error(err.status);
                });
    };
    $scope.getWriters = () => {
        httpRequestService.getHttpRequestService("writer").getAll()
            .then(
                (response) => {

                    $scope.writers = response.data;
                },
                (err) => {
                    messageService.error(err.status);
                });
    };
    $scope.getPublishers = () => {
        httpRequestService.getHttpRequestService("publisher").getAll()
            .then(
                (response) => {

                    $scope.publishers = response.data;
                },
                (err) => {
                    messageService.error(err.status);
                });
    };
    $scope.getCategories = () => {
        httpRequestService.getHttpRequestService("category").getAll()
            .then(
                (response) => {

                    $scope.categories = response.data;
                },
                (err) => {
                    messageService.error(err.status);
                });
    };
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
    
    $scope.getCountries();
    $scope.getLanguages();
    $scope.getWriters();
    $scope.getPublishers();
    $scope.getCategories();
    $scope.getAll();

    $scope.formSubmit = ()=> {
        if (!$scope.form.$valid)
            return;
        
        if ($scope.action === "Save") {
            httpRequestService.getHttpRequestService(controllerName).createEntity($scope.model)
                .then(
                    (response) => {
                        $scope.reverse = true;
                        $scope.action = "Update";
                        $scope.model = angular.copy(response.data);
                        productPublisher.productId = response.data.id;
                        addToDataSource(response.data);
                        messageService.added(response.data.name);
                    }, (error) => {
                        messageService.error(error.status);
                    });
        }
        else if ($scope.action === "Update"){
            httpRequestService.getHttpRequestService(controllerName).updateEntity($scope.model)
                .then(
                    (response) => {
                        messageService.updated(response.data.name);
                        updateDataSource(response.data);
                        $scope.getAll();
                    }, (error) => {
                        messageService.error(error.status);
                    });
        }
            
    };
    $scope.delete = (entity)=> {

        bootbox.confirm({
            message: "Are you sure? You want to delete " + "<b><i>" + entity.name + "</i></b>" + " permanently?",
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
                                messageService.deleted(entity.name);
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
        $scope.productPublisherModel = angular.copy(productPublisher);
        baseService.showPopUpByPopId(FormPopUp);
    }
    $scope.showFormPopUp = (entity) => {
        $scope.model = angular.copy(entity);
        productPublisher.productId = $scope.model.id;
        $scope.productPublisherModel.publisherId = entity.publisherId;
        getProductPublisher();
        baseService.showPopUpByPopId(FormPopUp);
        $scope.action = "Update";
        $scope.formTitle = "Update the " + entityNameToPerform;
    }
    $scope.reset = () => {
        $scope.model = angular.copy(defaultModel);
        $scope.action = "Save";
        $scope.form.$setPristine();
        $scope.form.$setUntouched();
    };

    // #region product publisher 
    $scope.ppFormSubmit = () => {
        if (!$scope.form.$valid)
            return;

        if ($scope.ppAction === "Save") {
            $scope.productPublisherModel.productId = productPublisher.productId;
            httpRequestService.getHttpRequestService(controllerName).createEntityProvidingDataUrl($scope.productPublisherModel,"CreateProductPublisher")
                .then(
                    (response) => {
                        $scope.productPublisherModel = angular.copy(response.data);
                        $scope.ppAction = "Update";
                        messageService.added("Data");
                    }, (error) => {
                        messageService.error(error.status);
                    });
        }
        else if ($scope.ppAction === "Update") {
            httpRequestService.getHttpRequestService(controllerName).updateEntityProvidingDataUrl($scope.productPublisherModel, "UpdateProductPublisher")
                .then(
                    (response) => {
                        messageService.updated("Data");
                        $scope.productPublisherModel = angular.copy(response.data);

                    }, (error) => {
                        messageService.error(error.status);
                    });
        }

    };

    var getProductPublisher = () => {
        
        if (productPublisher.productId && $scope.productPublisherModel.publisherId) {
            var data = {
                productId: productPublisher.productId,
                publisherId: $scope.productPublisherModel.publisherId
            }
            httpRequestService.getHttpRequestService(controllerName).getAllProvidingDataUrl(data, "getProductPublisher")
                .then(
                    (response) => {
                        if (response.status === 200) {
                            $scope.productPublisherModel = angular.copy(response.data);
                            $scope.ppAction = "Update";
                            
                        }
                        
                    },
                    (error) => {
                        if (error.status === 404) {
                            $scope.productPublisherModel = angular.copy(productPublisher);
                            $scope.productPublisherModel.publisherId = data.publisherId;
                            $scope.ppAction = "Save";
                        }
                        else
                            messageService.error(error.status);
                    });
        }
        else {
            $scope.productPublisherModel = angular.copy(productPublisher);
        }
    };
    $scope.checkPublisher = () => {
        getProductPublisher();
    };
    $scope.ppReset = () => {
        $scope.productPublisherModel = angular.copy(productPublisher);
        $scope.ppAction = "Save";
        $scope.ppform.$setPristine();
        $scope.ppform.$setUntouched();
    };
    // #endregion 

    // #region  photo
    
    $scope.imagePaths = [];
    var fileServiceUrl = urlService.getUrlService("File");
    $scope.imageRootDirectory = fileServiceUrl.rootUrl + "uploads/";
    $scope.loadPhotos = () => {
        $scope.photos = [];
        $scope.imagePaths = [];
        if ($scope.model.id === 0) {
            messageService.error("Save a product first");
            return;
        }
        if ($scope.productPublisherModel.publisherId === 0) {
            messageService.error("Please select a publisher first");
            return;
        }
        $scope.getPhotos();
    }
    
    $scope.getPhotos = () => {
        let data = { productId: productPublisher.productId, publisherId: $scope.productPublisherModel.publisherId };
        $http.post(fileServiceUrl.rootUrlWithController + "getAllByProductPublisher", data)
            .then(
                (response) => {
                    $scope.photos = response.data;
                },
                (err) => {
                    messageService.error(err.status);
                });
    };
    
    $scope.uploadPhoto = () => {
        
        var url = fileServiceUrl.rootUrlWithController + "Upload";

        var formData = new FormData();
        formData.append("file", $scope.fileList[0]);
        formData.append("productId", productPublisher.productId);
        formData.append("publisherId", $scope.productPublisherModel.publisherId);
        $http({
            url: url,
            method: "POST",
            data: formData,
            headers: { 'Content-Type': undefined },
            transformResponse: angular.identity
        }).then(
            (response) => {
                $scope.photos.push(JSON.parse(response.data));
            }, (error) => {
                messageService.error(error.status);
            });
    };

    $scope.removePhoto = (photo) => {
        var data = { id: photo.id, fileName: photo.fileName };
        $http.post(fileServiceUrl.rootUrlWithController + "delete", data)
            .then(
                (response) => {
                    messageService.deleted("Photo");
                    $scope.getPhotos();
                },
                (err) => {
                    messageService.error(err.status);
                });
    };
    // #endregion
});
