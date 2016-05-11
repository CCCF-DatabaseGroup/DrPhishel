myApp.controller('CitasPacienteController', function ($scope, $http) {


    $scope.solicitarCitasDisponibles = function () {
        $http.get('/Paciente/api/ApiPaciente/ObtenerCitasDisponiblesDoctor/', { params: { pIdDoctor: $scope.doctorSeleccionado.NumeroDoctor, pDia: $scope.fechaCita } })
        .success(function (result) {
            console.log(result);
            $scope.citasDisponibles = result;
            $scope.citaSeleccionada = $scope.citasDisponibles[0];
        })
        .error(function (data) {
        });
    }

    $scope.solicitarDoctoresHelp = function (cedula) {
        $http.get('/Paciente/api/ApiComun/VerMisDoctores', { params: { pCedula: cedula } })
        .success(function (result) {
            $scope.doctores = result;
            $scope.doctorSeleccionado = $scope.doctores[0];
            $scope.solicitarCitasDisponibles();
            console.log($scope.doctorSeleccionado);
        })
        .error(function (data) {
        });
    }

    $scope.solicitarDoctores = function () {
        $http.get('/Home/obtenerMiCedula')
        .success(function (result) {
            console.log(result.Cedula);
            $scope.miCedula = result.Cedula;
            $scope.solicitarDoctoresHelp(result.Cedula);
        })
        .error(function (data) {
        });

    }



    $scope.inicializarAgregar = function () {
        console.log("Inicializar dos veces?");

        $scope.doctores = $scope.solicitarDoctores();

        /*
        $scope.citasDisponibles = [
            { idCita: 1, HoraCita: "10:00 a.m" },
            { idCita: 2, HoraCita: "11:00 a.m" },
            { idCita: 3, HoraCita: "12:00 p.m" },
            { idCita: 4, HoraCita: "1:00 p.m" },
            { idCita: 5, HoraCita: "2:00 p.m" },
            { idCita: 6, HoraCita: "3:00 p.m" }
        ];
        */


        $scope.fechaHoy = function () {
            var today = new Date();
            var dd = today.getDate();
            var mm = today.getMonth() + 1; //January is 0!
            var yyyy = today.getFullYear();
            if (dd < 10) { dd = '0' + dd }
            if (mm < 10) { mm = '0' + mm }
            today = new Date(mm + '/' + dd + '/' + yyyy);
            $scope.fechaCita = today;
            console.log(typeof $scope.fechaCita);
        }
        $scope.fechaHoy();
        /*
        $scope.doctorSeleccionado = $scope.doctores[0];
        console.log($scope.doctorSeleccionado);
        $scope.citaSeleccionada = $scope.citasDisponibles[0];
        */
    }
    


    $scope.solicitarCita = function () {
        //$scope.doctorSeleccionado = $scope.doctores[0];
        var doc = $scope.doctorSeleccionado;
        $http({
            method: 'POST',
            url:'/Paciente/CrearCita',
            params: {
                pCedulaPaciente: $scope.miCedula,
                pFecha: $scope.fechaCita, pHora: $scope.citaSeleccionada, pNumeroDoctor: $scope.doctorSeleccionado.NumeroDoctor
            }
        })
        .success(function (result) {
            $scope.solicitarCitasDisponibles();
        })
        .error(function (data) {
        });
        alert("Usted desea solicitar una cita con el doctor: " + doc.Nombre + " " + doc.PrimerApellido
            + ", en la fecha: " + $scope.fechaCita.toString() + ", a las " + $scope.citaSeleccionada.HoraCita + " horas.");
    }

    $scope.filtroDoctor = function () {
        $scope.solicitarCitasDisponibles();
        console.log("se ha seleccionado un doctor");
    }

    $scope.filtroFecha = function () {
        if ($scope.fechaCita - new Date() < 0) $scope.fechaCita = new Date();
        $scope.solicitarCitasDisponibles();
        console.log("se ha seleccionado una fecha diferente");
    }



    $scope.inicializarEditar= function () {
        
    }


});