myApp.controller('DoctorController', function($scope,$http){

    $scope.fechaHoy = function () {
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1; //January is 0!
        var yyyy = today.getFullYear();
        if (dd < 10) { dd = '0' + dd }
        if (mm < 10) { mm = '0' + mm }
        today = new Date(mm + '/' + dd + '/' + yyyy);
        $scope.fechaCalendario = today;
        console.log(typeof $scope.fechaCita);
    }
    $scope.fechaHoy();

    $scope.resetDay = function () {
        $scope.fechaHoy();
    }
    $scope.obtenerCalendarioCitasHelp = function (cedula) {
        $http.get('/Doctor/api/ApiComun/VerCitasDoctor', { params: { pCedula: cedula, pDia: $scope.fechaCalendario } })
        .success(function (result) {
            console.log("Listo!", result);
            $scope.citas = result;
            if ($scope.citas.length > 0) $scope.citaSeleccionada = $scope.citas[0];
        })
        .error(function (data) {
        });
    }
    $scope.obtenerCalendarioCitas = function () {
        $http.get('/Home/obtenerMiCedula')
        .success(function (result) {
            console.log(result.Cedula);
            $scope.miCedula = result.Cedula;
            $scope.obtenerCalendarioCitasHelp(result.Cedula);
        })
        .error(function (data) {
        });

    }

    $scope.estaLaCitaSeleccionada = function (cita) {
        if (cita == $scope.citaSeleccionada) {
            return "list-group-item active";
        }
        return "list-group-item";
    }

    $scope.setearCitaSeleccionada = function(cita){
        $scope.citaSeleccionada = cita;
    }


    $scope.insertarHistorial = function () {
        if ($scope.citaSeleccionada == null) {
            $scope.ErrorHistorial = "Debe seleccionar una cita";
        }
        else {

            $http({
                method: 'POST',
                url: '/Doctor/InsertarHistorialClinico',
                params: {
                    pIdCita: $scope.citaSeleccionada.IdCita,
                    pConsulta: $scope.consulta,
                    pEstudios: $scope.estudios
                }
            })
        .success(function (result) {
            $scope.ErrorHistorial = "";
            $scope.estudios = "";
            $scope.consulta = "";
            $scope.obtenerCalendarioCitas();
            console.log($scope.citaSeleccionada.IdCita);
        })
        .error(function (data) {
            $scope.ErrorCita = "Error: Algo salio mal en la creacion de la cita";
        });
        }

    }





});