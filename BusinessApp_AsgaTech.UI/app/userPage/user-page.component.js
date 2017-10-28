(function () {
    'use strict'

    var app = angular.module('app');
    app.component('userPage', {
        templateUrl: '/app/userPage/userPage.html',
        controllerAs: 'vm',
        controller: ['$location','$resource','appSettings', controller]
    });
    function controller($location,$resource, appSettings) {
        var vm = this;
        //create member
        vm.submit = function (data) {
            //if (data == null || data == undefined || data="") {
            //    $('#endMessage').modal('show');
            //    vm.ErrMassge = "Please Enter ";
            //    vm.messageSuc = false;
            //    vm.messageErr = true;
            //}
            debugger
            var user = {};
            user.userName = data.userName;
            user.email = data.email;
            user.passWord = data.passWord;
            $resource(appSettings.serverPath + 'users/createuser')
                .save(user).$promise.then(onSuccess, onError);
            function onSuccess(response) {
                $location.path('/role/' + response.id);
            };
            function onError(response) {
                $('#endMessage').modal('show');
                vm.ErrMassge = response.data.message;
                vm.messageSuc = false;
                vm.messageErr = true;
            }
        }
    }
}());