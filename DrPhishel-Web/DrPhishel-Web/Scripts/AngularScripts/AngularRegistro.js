﻿
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
    })
    }

    $scope.obtenerUsuario = function () {

        $http.get(
            'api/ApiComun/ObtenerUsuario', { params: { pCedula: $scope.usuario.Cedula } }
            )
        .success(function (data, status) {
            //alert("fuck yeah!")
            console.log(data);
            if (data != null && data != {}) {
                data.Cedula = data.Cedula.toString();
                var fecha_nacimiento = new Date(data.FechaNacimiento);
                console.log(fecha_nacimiento);
                data.FechaNacimiento = data.FechaNacimiento.replace(/\//gi, '-');
                console.log(data.FechaNacimiento);
                console.log(typeof data.FechaNacimiento);
                data.FechaNacimiento = (fecha_nacimiento);
                console.log(data.FechaNacimiento);
                $scope.usuario = data;
                $scope.MensajeError = "";
            }
            else
                $scope.MensajeError = "No es posible encontrar al paciente";

        })
        .error(function (data) {
            console.log(data);
        });
    };

    //Asocia un doctor con el usuario
    $scope.asociarUsuarioHelp = function (cedula) {
        $http({
            url: '/Doctor/api/ApiDoctor/AsociarPacienteADoctor',
            method: 'POST',
            params: { pNumeroDoctor: cedula, pCedulaPaciente: $scope.usuario.Cedula}
        })
            .success(function (result) {
                $scope.initUsuario();
            })
            .error(function (data) {
            });

    }

    $scope.asociarUsuario  = function(){
        if ($scope.MensajeError == "") {

            $http.get('/Home/obtenerMiCedula')
                .success(function (result) {
                    console.log(result.Cedula);
                    $scope.miCedula = result.Cedula;
                    $scope.asociarUsuarioHelp($scope.miCedula);
                })
                .error(function (data) {
                });


        }
    
    }



    //$scope.obtenerUsuario();


    //$scope.registrarUsuario();

});