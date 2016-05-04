myApp.controller('CitasPacienteController', function ($scope, $http) {
    $scope.inicializar = function () {
        $scope.doctores = [
        { NumeroDoctor: 1, Nombre: "Cristian", PrimerApellido: "Rivera", SegundoApellido: "Lopez" },
        { NumeroDoctor: 2, Nombre: "Esteban", PrimerApellido: "Ferarios", SegundoApellido: "S." },
        { NumeroDoctor: 3, Nombre: "Yosua", PrimerApellido: "E.", SegundoApellido: "A." },
        { NumeroDoctor: 4, Nombre: "Nasus", PrimerApellido: "LOL", SegundoApellido: "LOL" }
        ];

        $scope.citasDisponibles = [
            { idCita: 1, HoraCita: "10:00 a.m" },
            { idCita: 2, HoraCita: "11:00 a.m" },
            { idCita: 3, HoraCita: "12:00 p.m" },
            { idCita: 4, HoraCita: "1:00 p.m" },
            { idCita: 5, HoraCita: "2:00 p.m" },
            { idCita: 6, HoraCita: "3:00 p.m" }
        ];


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
        $scope.doctorSeleccionado = $scope.doctores[0];
        console.log($scope.doctorSeleccionado);
        $scope.citaSeleccionada = $scope.citasDisponibles[0];
    }
    

    $scope.solicitarCita = function () {
        //$scope.doctorSeleccionado = $scope.doctores[0];
        var doc = $scope.doctorSeleccionado;
        alert("Usted desea solicitar una cita con el doctor: " + doc.Nombre + " " + doc.PrimerApellido
            + ", en la fecha: " + $scope.fechaCita.toString() + ", a las " + $scope.citaSeleccionada.HoraCita + " horas.");
    }

    $scope.filtroDoctor = function () {
        console.log("se ha seleccionado un doctor");
    }

    $scope.filtroFecha = function () {
        console.log("se ha seleccionado una fecha diferente");
    }


});