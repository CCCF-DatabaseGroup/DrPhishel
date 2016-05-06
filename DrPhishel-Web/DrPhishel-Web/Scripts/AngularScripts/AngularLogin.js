myApp.controller('LoginController', function ($scope, $http, $window) {

    $scope.Paciente = 1;
    $scope.Doctor = 2;
    $scope.Administrador = 3;

    $scope.usuarioLogin = { CorreoElectronico: undefined, Contrasena: undefined, TipoUsuario: 1 };
    $scope.loginMessage = "";

    $scope.ingresar = function () {
        $http.post('/Home/SetUsuario')
    .success(function (result) {
        $window.location.reload();
    })
    .error(function (data) {
        $scope.loginMessage = "Error al ingresar con el usuario, esto puede suceder por que usted esta iniciado con un usuario que no existe (correo electronico invalido), su contraseña sea erronea o ha elegido un tipo de usuario no valido para usted";
    });
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