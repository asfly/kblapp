﻿
/*
* create by daniel.zuo on 2015.4.19
*
*
*/
KBLApp.service('CommService', ["$rootScope", function ($rootScope) {
    var service = {};
    service.prepbroadcast = function (command, msg) {
        $rootScope.$broadcast(command, msg);
    }
    return service;
}]);