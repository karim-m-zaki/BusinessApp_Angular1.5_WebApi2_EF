(function () {
    'use strict'
    angular.module('commonService')
        .factory('roleService',
        ['$resource', 'appSettings', roleService]);
    function roleService($resource, appSettings) {
        
        return {
            
            createUser: $resource(appSettings.serverPath + 'users/createuser'),
            getAllRoles: $resource(appSettings.serverPath + 'roles/getallroles')
        }
    }
})();