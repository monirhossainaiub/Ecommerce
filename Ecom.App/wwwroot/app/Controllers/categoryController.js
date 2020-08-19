/// <reference path="../app.js" />

'use strict';

app.controller("categoryController", function ($scope, $http, $rootScope, categoryService, messageService) {
    $scope.message = "Categories";  
    $scope.action = "Save";
    $scope.categories = [];
    $scope.addEntityTitle = "Add Category";
    $scope.dataTableName = "Categories";
 
    //#region pagination
    $scope.searchText = "";
    $scope.itemsPerpage = 2;
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
        { title: 'parentCategoryId', key: 'parentCategoryId', isSortable: true },
        { title: 'Action', key: 'action', isSortable: false }

    ];

    //#endregion pagination 

    var modelDefault = {
        Id: 0,
        Name: null,
        ParentCategoryId : 0,
        Description: null,
        DisplayOrder: 0,
        IsPublished: true
    };

    $scope.model = angular.copy(modelDefault);

    $scope.getCategories = ()=> {
        categoryService.getCategories()
            .then(
                (response) => {
                    
                    
                $scope.categories = response.data;
            },
                (err) => {
                    messageService.error(err.message);
            });
    };
    $scope.getCategories();

    $scope.formSubmit = function () {
        console.log($scope.model);
        if (!$scope.formCategory.$valid)
            return;

        if ($scope.action === "Save") {
            $http({
                method: 'POST',
                url: $scope.saveUrl,
                data: $scope.model,
                dataType: 'JSON'
            }).then(function successCallback(response) {
                console.log(response);
                Clear();
                //toastr.success('Data saved successfully', 'Success');
            }, function errorCallBack(response) {

            });
        }
        else if ($scope.action === "Update") {

        }
    };
    $scope.delete = function (category) {

        bootbox.confirm({
            message: "Are you sure? You want to delete " + category.name + " permanently?",
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
            callback: function (result) {
                if (result) {
                    categoryService.deleteCategory(category)
                        .then(
                            (result) => {
                                $scope.getCategories();
                                messageService.deleted(category.name);
                            },
                            (error) => { messageService.error(err.message); }
                     );
                }
            }
        });
    };

    var Clear = () => {
        $scope.model = angular.copy(modelDefault);
        $scope.formCategory.$setPristine();
        $scope.formCategory.$setUntouched();
    };

});
