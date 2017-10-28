(function () {
    'use strict'
    angular.module('commonService')
        .factory('homeService',
        ['$resource', 'appSettings', homeService]);
    function homeService($resource, appSettings) {
        return {
            getAllUsers: $resource(appSettings.serverPath + 'users/getallusers'),
            //getAllProjects: $resource(appSettings.serverPath + 'getallprojects'),
            //getMembersByProjectId: $resource(appSettings.serverPath + 'GetMemberByProjectId/:id'),
            createUser: $resource(appSettings.serverPath + 'users/createuser'),
            updateUser: $resource(appSettings.serverPath + 'users/editUser'),
        }
    }
})();