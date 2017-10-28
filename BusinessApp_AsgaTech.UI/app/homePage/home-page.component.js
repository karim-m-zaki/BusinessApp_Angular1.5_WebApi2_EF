(function () {
    'use strict'

    var app = angular.module('app');
    app.component('homePage', {
        templateUrl: '/app/homePage/homePage.html',
        controllerAs: 'vm',
        controller: ['$location', '$resource', 'appSettings', 'homeService', '$scope', 'uiGridConstants', controller]
    });
    function controller($location, $resource, appSettings, homeService, $scope, uiGridConstants) {
        var vm = this;
        vm.showInsert = true;
        vm.showUpdate = false;
        //Get all members from database
        vm.getAllUsers = function () {
            debugger
            homeService.getAllUsers.query(
                function (data) {
                    $scope.usersGrid.data = data;
                });
        }
        vm.getAllUsers();        

        //ui grid
        $scope.usersGrid = {
            paginationPageSizes: [25, 50, 75],
            paginationPageSize: 15,
            enableFiltering: true,
            enableRowSelection: true,
            enablePinning: true,
            enableRowHeaderSelection: false,
            multiSelect: true,
            showGridFooter: true,
            showColumnFooter: true,
            enableHorizontalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
            enableVerticalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
            columnDefs: [
                { name: 'id', enableCellEdit: false, displayName: 'Id', width: "10%" },
                { name: 'userName', enableCellEdit: false, displayName: 'Full Name', width: "40%" },
                { name: 'email', enableCellEdit: false, displayName: 'Email', width: "40%", cellTemplate: '<div class="ui-grid-cell-contents"><a ng-click="grid.appScope.detail(row)" > {{ COL_FIELD }}   </a></div>' },
                //{ name: 'title', enableCellEdit: false, displayName: 'Title', width: "30%" },
                { field: 'action', enableCellEdit: false, name: '', cellTemplate: '<button type="button" class="btn btn-xs btn" ng-click="grid.appScope.openDeleteModal(row)"> <i class="fa fa-trash"></i> </button><button type="button" class="btn btn-xs btn" ng-click="grid.appScope.detail(row)"> <i class="fa fa-edit"></i> </button>', width: "5%", enableFiltering: false }
            ],
            onRegisterApi: function (gridApi) {
                $scope.gridApi = gridApi;
            }
        };
        //open modal to update user
        $scope.detail = function (row) {
            $('#modalForDetail').modal('show');
            vm.userName = row.entity.userName;
            vm.email = row.entity.email;
            vm.tempSelected = row.entity;
            vm.showInsert = false;
            vm.showUpdate = true;
        }

        $scope.openDeleteModal = function (row) {
            $('#alertMessage').modal('show');
            vm.idRow = row.entity.id;
        }

        //Redirect to RolePage
        vm.goToCreate = function () {
            $location.path('/user/');
        }
        

        //Update member
        vm.edit = function (data) {
            debugger
            var user = {};
            user = vm.tempSelected;
            user.userName = data.userName;
            user.email = data.email;
            homeService.updateUser.save(user)
                .$promise.then(function (value) {
                    $('#endMessage').modal('show');
                    $('#modalForDetail').modal('hide');
                    vm.SuccessMess = "Updated Successfully";
                    vm.getAllUsers();
                    vm.messageSuc = true;
                    vm.messageErr = false;
                }),
                function (error) {
                    $('#endMessage').modal('show');
                    vm.messageSuc = false;
                    vm.messageErr = true;
                }
        }

        //Delete member
        vm.delete = function () {
            debugger
            $resource(appSettings.serverPath + 'users/delete/' + vm.idRow)
                .delete(vm.idRow).$promise.then(function (value) {
                    $('#endMessage').modal('show');
                    vm.SuccessMess = "Deleted Successfully";
                    vm.getAllUsers();
                    vm.messageSuc = true;
                    vm.messageErr = false;
                }),
                function (error) {
                    $('#endMessage').modal('show');
                    vm.messageSuc = false;
                    vm.messageErr = true;
                }
        }

    }
}());