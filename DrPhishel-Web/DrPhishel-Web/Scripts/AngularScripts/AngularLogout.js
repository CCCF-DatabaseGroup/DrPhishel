myApp.controller('LogoutController', function ($scope, $http, $window) {


    $scope.logout = function () {
        $http.post('/Home/Logout').success(function (result) {
            $window.location.reload();
        }).error(function (data) {
            console.log(data);
        });
    }


});