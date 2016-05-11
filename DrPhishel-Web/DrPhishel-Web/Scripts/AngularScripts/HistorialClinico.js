
myApp.controller('historialClinicoController', function ($scope, $http) {
    //$scope.citas = [{ DoctorEncargado: "Fernando Rivera", FechaCita: "Hoy", Descripcion: "nada", ResultadosDeEstudios: "no pos paciente gg" }, { DoctorEncargado: "Fernando Rivera", FechaCita: "ayer", Descripcion: "nope", ResultadosDeEstudios: "pos paciente gg" }];
    $scope.receta = [{ nombre: "Medicamento a" }, { nombre: "Medicamento b" }];

    $scope.seleccionarCita = function (cita) {
        $scope.citaSeleccionada = cita;
    }

    $scope.solicitarCedula = function () {
        $http.get('/Home/obtenerMiCedula')
        .success(function (result) {
            console.log(result.Cedula);
            $scope.miCedula = result.Cedula;
        })
        .error(function (data) {
        });
    };


    $scope.obtenerHistorialClinicoHelp = function (cedula) {
        console.log("Called obtener Historial ", cedula);
        $http.get('/Paciente/api/ApiComun/ObtenerHistorialClinico',
            { params: { pCedula: cedula } }
        ).success(function (result, status) {
            console.log(result);
            $scope.citas = result;
        })
        .error(function (data) {
        });
    }

    $scope.obtenerHistorialClinico = function () {
        $http.get('/Home/obtenerMiCedula')
        .success(function (result) {
            console.log(result.Cedula);
            $scope.miCedula = result.Cedula;
            $scope.obtenerHistorialClinicoHelp(result.Cedula);
        })
        .error(function (data) {
        });
    };





});