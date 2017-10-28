(function () {
    'use strict'

    var app = angular.module('app');
    app.component('rolePage', {
        templateUrl: '/app/rolePage/rolePage.html',
        controllerAs: 'vm',
        controller: ['$location','appSettings', '$http', '$route', '$routeParams', '$resource', 'roleService', '$scope', controller]
    });
    function controller($location,appSettings, $http, $route, $routeParams, $resource, roleService, $scope) {
        var vm = this;
        //Get all members from database
        vm.getAllroles = function () {
            roleService.getAllRoles.query(
                function (data) {
                    vm.roles = data;
                });
        }
        vm.getAllroles();

        //get user by id
        vm.getUserById = function () {
            $http.get(appSettings.serverPath + 'users/getuser/' + $routeParams.id)
                .then(onSuccess, onError);
            function onSuccess(response) {

                if (response.data) {

                    vm.userName = response.data.userName;
                }
            };
            function onError(response) {
                alert(response.data.message)
            }
        }
        vm.getUserById();
        //create member
        vm.submit = function (data) {
            debugger
            vm.rolesInput = [];
            angular.forEach(vm.roles, function (role) {
                if (!!role.selected) vm.rolesInput.push(role);
            })
            var user = {};
            user.userId = $routeParams.id;
            user.roles = vm.rolesInput;
            $resource(appSettings.serverPath + 'users/adduserroles')
                .save(user).$promise.then(onSuccess, onError);
            function onSuccess(response) {
                $location.path('/home');
            };
            function onError(response) {
                alert(response.data.message);
            }
        }
    }
}());