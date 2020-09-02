/// <reference path="../app.js" />

'use strict';

app.controller("productController", ($scope, $http, $rootScope, httpRequestService, messageService, baseService) =>
{
    //server controller name
    var controllerName = "product";
    $scope.dataTableName = "Products";
    var FormPopUp = "FormPopUp";
    var entityNameToPerform = "product";
    $scope.isExist = false;
    $scope.isResponseComplete = false;
    $scope.action = "Save";
    $scope.dataSource = [];
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
        { title: 'Name', key: 'name', isSortable: true },
        { title: 'Title', key: 'title', isSortable: true },
        { title: 'ISBN', key: 'ISBN', isSortable: true },
        { title: 'Edition', key: 'edition', isSortable: true },
        { title: 'Country', key: 'country', isSortable: true },
        { title: 'Language', key: 'language', isSortable: true },
        { title: 'Display Order', key: 'displayOrder', isSortable: true },
        { title: 'Price', key: 'price', isSortable: true },
        { title: 'OldPrice', key: 'oldPrice', isSortable: true },
        { title: 'CostPrice', key: 'costPrice', isSortable: true },
        { title: 'Quantity', key: 'stockQuantity', isSortable: true }
    ];
    //#endregion pagination 

    var defaultModel = {
        id: 0,
        name: null,
        title: null,
        ISBN: null,
        
        edition: null,
        country : null,
        language: null,
        description : null,
        displayOrder: 0,
        price : 0,
        oldPrice  : 0,
        costPrice: 0,
        numberOfPage: 0,
        stockQuantity: 0,
        orderMinimumQuantity : 0,
        orderMaximumQuantity : 0,
        notifyForMinimumQuantityBellow : 0,

        isNewProduct: true,
        isPublished: true,
        isAproved : true,
        isReturnAble : true,
        isShippingChargeApplicable : true,
        isLimitedToStore : true,
    };

    $scope.model = angular.copy(defaultModel);

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
                        baseService.hidePopUpByPopId(FormPopUp);
                        messageService.added(response.data.name);
                        addToDataSource(response.data);
                        $scope.reset();
                    }, (error) => {
                        messageService.error(error.status);
                    });
        }
        else if ($scope.action === "Update"){
            httpRequestService.getHttpRequestService(controllerName).updateEntity($scope.model)
                .then(
                    (response) => {
                        baseService.hidePopUpByPopId(FormPopUp);
                        messageService.updated(response.data.name);
                        updateDataSource(response.data);
                        $scope.reset();
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
                            (error) => { messageService.error(err.status); }
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
        $scope.model = angular.copy(entity);
        baseService.showPopUpByPopId(FormPopUp);
        $scope.action = "Update";
        $scope.formTitle = "Update the " + entityNameToPerform;
    }
    $scope.reset = () => {
        $scope.model = angular.copy(defaultModel);
        $scope.form.$setPristine();
        $scope.form.$setUntouched();
    };
});
