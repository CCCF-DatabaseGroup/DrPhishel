
myApp.controller('registroController', function ($scope, $http, $filter) {

    //$filter('date')(date, format, timezone);
    $scope.initUsuario = function () {
        $scope.usuario = {
            Cedula: null,
            Nombre: "",
            PrimerApellido: "",
            SegundoApellido: "",
            FechaNacimiento: undefined,
            Telefono: "",
            Direccion: "",
            CorreoElectronico: "",
            Contrasena: "",
            ContraseniaVerificacion: ""
        };
    }

    $scope.initUsuario();


    $scope.registrarUsuario = function () {
        var object = {
            pCedula: parseInt($scope.usuario.Cedula),
            pNombre: $scope.usuario.Nombre,
            pPrimerApellido: $scope.usuario.PrimerApellido,
            pSegundoApellido: $scope.usuario.SegundoApellido,
            pFechaNacimiento: $scope.usuario.FechaNacimiento.toString(),
            pTelefono: parseInt($scope.usuario.Telefono),
            pDireccion: $scope.usuario.Direccion,
            pCorreo: $scope.usuario.CorreoElectronico.toString(),
            pContrasena: $scope.usuario.Contrasena.toString()
        };

        var fecha = ($scope.usuario.FechaNacimiento.getUTCMonth() + 1) + "-" +
            $scope.usuario.FechaNacimiento.getUTCDate()+"-" + 
            $scope.usuario.FechaNacimiento.getUTCFullYear()
            ;


        $http({
            url: "api/ApiComun/RegistrarUsuario",
            method: "POST",
            params: {
                pCedula: parseInt($scope.usuario.Cedula),
                pNombre: $scope.usuario.Nombre,
                pPrimerApellido: $scope.usuario.PrimerApellido,
                pSegundoApellido: $scope.usuario.SegundoApellido,
                pFechaNacimiento: fecha,
                pTelefono: parseInt($scope.usuario.Telefono),
                pDireccion: $scope.usuario.Direccion,
                pCorreo: $scope.usuario.CorreoElectronico.toString(),
                pContrasena: $scope.usuario.Contrasena.toString()
            }
        })
    .success(function (data, status) {
        $scope.advertenciaUsuarioRegistrado = "";
        $scope.initUsuario();
    })
    .error(function (data) {
        $scope.advertenciaUsuarioRegistrado = "Error: No se pudo crear el usuario, esto puede ocurrir porque el usuario ya existe o algunos de los campos no cumple las reglas";
        console.log(data);
    });

        /*
        $http.post("api/ApiComun/RegistrarUsuario",
            {
                params: {
                    pCedula: parseInt($scope.usuario.Cedula),
                    pNombre: $scope.usuario.Nombre,
                    pPrimerApellido: $scope.usuario.PrimerApellido,
                    pSegundoApellido: $scope.usuario.SegundoApellido,
                    pFechaNacimiento: $scope.usuario.FechaNacimiento.toString(),
                    pTelefono: parseInt($scope.usuario.Telefono),
                    pDireccion: $scope.usuario.Direccion,
                    pCorreo: $scope.usuario.CorreoElectronico.toString(),
                    pContrasena: $scope.usuario.Contrasena.toString()
                }
            }
            )
            .success(function (data, status) {
                alert("Exito maximo");
                $scope.initUsuario();
            })
        .error(function (data) {
            console.log(data);
        });

        */

    }

    $scope.obtenerUsuario = function () {

        $http.get(
            'api/ApiComun/ObtenerUsuario', { params: { pCedula: $scope.usuario.Cedula } }
            )
        .success(function (data, status) {
            //alert("fuck yeah!")
            console.log(data);
            data.Cedula = data.Cedula.toString();
            data.FechaNacimiento = new Date(data.FechaNacimiento);
            console.log(data.FechaNacimiento);
            $scope.usuario = data;
        })
        .error(function (data) {
            console.log(data);
        });
    }
    //$scope.obtenerUsuario();


    //$scope.registrarUsuario();

});