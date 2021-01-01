/// <reference path="../app.js" />

'use strict';

app.controller("sliderController", ($scope, $http, httpRequestService, messageService, baseService, urlService) => {
    //server controller name
    var controllerName = "slider";
    $scope.dataTableName = "Sliders";
    var FormPopUp = "FormPopUp";
    var entityNameToPerform = "slider";
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
        { title: 'Photo', key: 'photo', isSortable: false },
        { title: 'Controller Name', key: 'controllerName', isSortable: true },
        { title: 'Action Name', key: 'actionName', isSortable: true },
        { title: 'Display Order', key: 'displayOrder', isSortable: true },
        { title: 'Active', key: 'isActive', isSortable: true },
        { title: 'Action', key: 'action', isSortable: false }
    ];
    //#endregion pagination 

    var defaultModel = {
        id: 0,
        controllerName: null,
        actionName: null,
        photo: null,
        photId: 0,
        isActive: true,
        displayOrder: 0
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


    $scope.getAll = () => {
        httpRequestService.getHttpRequestService(controllerName).getAll()
            .then(
                (response) => {
                    $scope.isResponseComplete = true;
                    $scope.dataSource = response.data;
                },
                (err) => {
                    $scope.isResponseComplete = true;

                    //toastr.error("status code:" + err.message + ", The resource could not be found", 'Error', { timeOut: 5000 });
                    messageService.error(err.status);
                });
    };
    $scope.getAll();

    $scope.imagePaths = [];
    var rootUrlWithController = urlService.getUrlService("slider").rootUrlWithController;
    var fileServiceUrl = urlService.getUrlService("File");
    $scope.imageRootDirectory = fileServiceUrl.rootUrl + "uploads/";
    $scope.uploadPhoto = () => {
        var url = rootUrlWithController + "Upload";

        var formData = new FormData();
        formData.append("file", $scope.fileList[0]);
        formData.append("isActive", $scope.model.isActive);
        formData.append("controllerName", $scope.model.controllerName);
        formData.append("actionName", $scope.model.actionName);
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

    $scope.formSubmit = () => {
        if (!$scope.form.$valid)
            return;

        httpRequestService.getHttpRequestService(controllerName).updateEntity($scope.model)
            .then(
                (response) => {
                    baseService.hidePopUpByPopId(FormPopUp);
                    messageService.updated("Data ");
                    updateDataSource(response.data);
                    $scope.reset();
                }, (error) => {
                    messageService.error(error.status);
                });
    };
    //$scope.delete = (entity)=> {
    //    bootbox.confirm({
    //        message: "Are you sure? You want to delete " + "<b><i>" + entity.name + "</i></b>" + " permanently?",
    //        buttons: {
    //            confirm: {
    //                label: '<i class="fa fa-check"></i> Confirm',
    //                className: 'btn-success'
    //            },
    //            cancel: {
    //                label: '<i class="fa fa-times"></i> No',
    //                className: 'btn-danger'
    //            }
    //        },
    //        callback: (result)=>  {
    //            if (result) {
    //                httpRequestService.getHttpRequestService(controllerName).deleteEntity(entity)
    //                    .then(
    //                        (result) => {
    //                            removeFromDataSource(result.data);
    //                            messageService.deleted(entity.name);
    //                        },
    //                        (error) => { messageService.error(error.status); }
    //                 );
    //            }
    //        }
    //    });
    //};
    //$scope.maxOrderBy = 0;
    //$scope.getMaxOrderBy = () => {
    //    if ($scope.dataSource.length == 0)
    //        return;
    //    var max = $scope.dataSource[0].displayOrder;
    //    for (var i = 0; i < $scope.dataSource.length; i++) {
    //        if (max < $scope.dataSource[i].displayOrder) {
    //            max = $scope.dataSource[i].displayOrder;
    //        }
    //    }
    //    $scope.model.displayOrder = max + 1;
    //}

    $scope.showFormPopUpForSave = () => {
        //$scope.reset();
        $scope.model = angular.copy(defaultModel);
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
