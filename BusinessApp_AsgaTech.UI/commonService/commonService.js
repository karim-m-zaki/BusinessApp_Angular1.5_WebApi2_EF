(function () {
    'use strict'
    angular.module('commonService',
        ['ngResource'])
        .constant('appSettings', {
            serverPath: 'http://localhost:65125/api/'
        });
})();