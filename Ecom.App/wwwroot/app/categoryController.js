/// <reference path="app.js" />


'use strict';

app.controller("categoryController", function ($scope, $http, $rootScope) {
    $scope.message = "Categories";  
    $scope.action = "Save";
    $scope.categories = [];
    

    //const ROOT_URL = "category";
    //const SAVE_URL = $rootScope.domainUrl + ROOT_URL + "/" + $rootScope.actions.save;
    //const EDIT_URL = $rootScope.domainUrl + ROOT_URL + "/" + $rootScope.actions.edit;
    //const DELETE_URL = $rootScope.domainUrl + ROOT_URL + "/" + $rootScope.actions.delete;

    $scope.saveUrl = "https://localhost:44317/" + "category" + "/" + "create";
    $scope.getUrl = "https://localhost:44317/" + "category/getall";
    $scope.tableName = "Categories";

    //#region pagination bootstrap
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

    //#endregion pagination with mosh 




    var modelDefault = {
        Id: 0,
        Name: null,
        ParentCategoryId : 0,
        Description: null,
        DisplayOrder: 0,
        IsPublished: true
    };

    $scope.model = angular.copy(modelDefault);

    $scope.getCategories = function () {
        $http.get($scope.getUrl)
            .then(function successCallback(response) {
                $scope.categories = response.data;
               
            },
            function errorCallBack(err) {

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
                toastr.success('Data saved successfully', 'Success', { timeOut: 5000 });
            }, function errorCallBack(response) {

            });
        }
        else if ($scope.action === "Update") {

        }
    };

    var Clear = () => {
        $scope.model = angular.copy(modelDefault);
        $scope.formCategory.$setPristine();
        $scope.formCategory.$setUntouched();
    };

    
});
