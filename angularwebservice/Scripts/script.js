var myApp = angular.module("myModule", []);
//myApp.controller("myController", function ($scope, $http,$log) {
//    $http.post('EmployeeService.asmx/GetAllEmployees').then(function (response) {
//        $scope.employees = response.data;
//        $log.info(response);
//    }, function (reason) {
//        $scope.error = reason.data;
//        $log.error(reason);
//    });


//});


myApp.controller("myController", function ($scope, $http, $log) {

    var successCallBack = function (response) {
        $scope.employees = response.data;
        $log.info(response);
    }
    var errorcallback = function (reason) {
        $scope.eoorr = reason.data;
        $scope.error(reason);
    }

    $http.post('EmployeeService.asmx//GetAllEmployees').then(successCallBack

       
    , errorcallback
        );

});


//myApp.controller("myController", function ($scope, $http, $log) {
//    var successCallBack = function (response) {
//        $scope.employees = response.data;
//    };
//    var errorCallBack = function (reason) {
//        $scope.error = reason.data;

//    };
//    $http.post('EmployeeService.asmx/GetAllEmployees').then(successCallBack,errorCallBack);
//    });


//OR

//myApp.controller("myController", function ($scope, $http) {
//    $http({
//        method: "post",
//        url: 'EmployeeService.asmx/GetAllEmployees'
//    }).then(function (response) {
//        $scope.employees = response.data;
//    });
//});
//if you want to use get() method above add following code in the web.config under <system.web></sysytem.web>
//<webServices>
//      <protocols>
//        <add name="HttpGet"/>
//      </protocols>
//    </webServices>