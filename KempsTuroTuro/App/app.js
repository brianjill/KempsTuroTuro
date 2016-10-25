'use strict';
var kempsApp = angular.module('kempsApp', ['ngRoute','ngResource']);
kempsApp
    .config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/', {
        templateUrl: '/app/components/home/home.html',
        controller: 'homeCtrl'
    }).otherwise({
        redirectTo: '/'
    });
}]);