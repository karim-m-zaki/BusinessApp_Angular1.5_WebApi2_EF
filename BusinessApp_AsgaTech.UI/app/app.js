(function () {
    'use strict';

    var app = angular.module('app', ['ngResource', 'commonService', 'ngRoute',
        'ui.grid',
        'ui.grid.resizeColumns',
        'ui.grid.edit',
        'ui.grid.moveColumns',
        'ui.grid.selection',
        'ui.grid.pagination',
        'ui.grid.autoResize',
        'ui.grid.pinning',
        'ui.grid.cellNav',
        'ui.grid.rowEdit'
    ]);
    app.config(function ($routeProvider, $locationProvider) {
        $routeProvider
            .when('/home', {
                template: '<home-page></home-page>'
            })
            .when('/user/', {
                template: '<user-page></user-page>'
            })
            .when('/role/:id', {
                template: '<role-page></role-page>'
            })
            .otherwise({ redirectTo: '/home' })
    })
})();