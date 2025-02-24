﻿/*
* Create by daniel.zuo on 4/19/2015
*/
KBLApp.controller("User.RegisterController", ['$rootScope', '$scope', '$state', '$stateParams', 'ApiService', 'CommService', 'UserService',
    function ($rootScope, $scope, $state, $stateParams, ApiService, CommService, UserService) {

        //document.getElementById('role.parentCid').addEventListener('input', function (inputtext) {
            
        //});

        if (!$scope.customer.model.Cid && !$stateParams.cid) {
            //window.location.href = "#/customer/create";
            $state.go('create');
        }

        if(!$scope.role){
            $scope.role = {
                Cid:$scope.customer.model.Cid
            }
        }
        $scope.save = function () {            
            var model ={
                Input0 : {
                    CustomerRole: $scope.role
                },
                S: Math.random()
            }            
            var param = JSON.stringify(model);
            UserService.submit(param).then(function (response) {
                if (response.result > 0) {
                    $scope.isShowRoleSaveAction = false;
                    $state.go('customer.type', { type:'general',s:$scope.role.cid});
                } else {
                    alert("收录失败！！请联系开发人员");
                }
            }, function (data, status, header, configs) {
                console.log(data, status, header, configs);
            });
        }
    }]);