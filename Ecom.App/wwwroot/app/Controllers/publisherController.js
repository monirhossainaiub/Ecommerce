﻿/// <reference path="../app.js" />

'use strict';

app.controller("publisherController", ($scope, $http, $rootScope, httpRequestService, messageService, baseService) =>
{
    //server controller name
    var controllerName = "publisher";
    $scope.dataTableName = "publishers";
    var FormPopUp = "FormPopUp";
    var entityNameToPerform = "publisher";

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
        { title: 'Description', key: 'description', isSortable: true },
        { title: 'Display Order', key: 'displayOrder', isSortable: true },
        { title: 'isPublished', key: 'isPublished', isSortable: true },
        { title: 'Address', key: 'address', isSortable: true },
        { title: 'Action', key: 'action', isSortable: false }
    ];
    //#endregion pagination 

    var defaultModel = {
        id: 0,
        name: null,
        Description: null,
        displayOrder: 0,
        isPublished: true,
        address : null
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
    $scope.isExist = false;
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
                    $scope.dataSource = response.data;
            },
                (err) => {
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
    $scope.showFormPopUpForSave = () => {
        $scope.action = "Save";
        $scope.reset();
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