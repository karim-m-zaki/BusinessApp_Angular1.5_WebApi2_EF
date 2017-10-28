(function () {
    'use strict'
    angular.module('commonService')
        .factory('roleService',
        ['$resource', 'appSettings', roleService]);
    function roleService($resource, appSettings) {
        
        return {
            createRole: $resource(appSettings.serverPath + 'users/adduserroles'),
            getAllRoles: $resource(appSettings.serverPath + 'roles/getallroles')
        }
    }
})();