myApp.controller('LoginController', function ($scope, $http) {
    
    $scope.Paciente = 1;
    $scope.Doctor = 2;
    $scope.Administrador = 3;

    $scope.usuarioLogin = { CorreoElectronico: undefined, Contrasena: undefined, TipoUsuario: 1 };
    $scope.loginMessage = "";


    $scope.ingresar = function () {
        console.log($scope.usuarioLogin);
        /*
        $http.post('/Home/Ingresar',
            {
                pCorreoElectronico: $scope.usuarioLogin.CorreoElectronico,
                pContrasena: $scope.usuarioLogin.Contrasena,
                pTipoUsuario: $scope.usuarioLogin.TipoUsuario
            })
        .success(function (result) {

        })
        .error(function (data) {

        });
        */
    }






});