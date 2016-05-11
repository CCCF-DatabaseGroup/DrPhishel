myApp.controller('LoginController', function ($scope, $http, $window) {

    $scope.Paciente = 3;
    $scope.Doctor = 2;
    $scope.Administrador = 1;

    $scope.usuarioLogin = { CorreoElectronico: undefined, Contrasena: undefined, TipoUsuario: 3 };
    $scope.loginMessage = "";

    $scope.ingresar = function () {
        /*$http.post('/Home/SetUsuario')
    .success(function (result) {
        $window.location.reload();
    })
    .error(function (data) {
        $scope.loginMessage = "Error al ingresar con el usuario, esto puede suceder por que usted esta iniciado con un usuario que no existe (correo electronico invalido), su contraseña sea erronea o ha elegido un tipo de usuario no valido para usted";
    });
    */
        

        $http({
            method: 'POST',
            url: 'Home/api/ApiComun/LoginUsuario',
            params: {
                pCorreoElectronico: $scope.usuarioLogin.CorreoElectronico,
                pContrasena: $scope.usuarioLogin.Contrasena,
                pTipoUsuario: $scope.usuarioLogin.TipoUsuario
            }
        })
        .success(function (result) {
            console.log(result);
            if (result != null) $scope.setUsuario(result);
            else 
                $scope.loginMessage = "Error al ingresar con el usuario, esto puede suceder por que usted esta iniciado con un usuario que no existe (correo electronico invalido), su contraseña sea erronea o ha elegido un tipo de usuario no valido para usted";
        }).error(function (data) {
            $scope.loginMessage = "Error al ingresar con el usuario, esto puede suceder por que usted esta iniciado con un usuario que no existe (correo electronico invalido), su contraseña sea erronea o ha elegido un tipo de usuario no valido para usted";
        });

    }

    $scope.setUsuario = function (usuario) {
        $http.post('/Home/SetUsuario', { pUsuario: usuario }).success(function (result) {
            console.log('is done!');
            console.log(result);
            $window.location.reload();
        }).error(function (data) {
            $scope.loginMessage = "Error al ingresar con el usuario, esto puede suceder por que usted esta iniciado con un usuario que no existe (correo electronico invalido), su contraseña sea erronea o ha elegido un tipo de usuario no valido para usted";
            console.log(data);
        });
    };

});