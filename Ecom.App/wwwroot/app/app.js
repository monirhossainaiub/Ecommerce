/// <reference path="../assets/vendor/angular/angular.js" />
/// <reference path="../assets/vendor/angular/angular-route.js" />


'use strict';
var app = angular.module("app", [
    'ui.bootstrap'
]);

app.directive("selectNgFiles", function() {
return {
    require: "ngModel",
    link: function postLink(scope, elem, attrs, ngModel) {
        elem.on("change", function (e) {
            var files = elem[0].files;
            ngModel.$setViewValue(files);
        })
    }
}
});


