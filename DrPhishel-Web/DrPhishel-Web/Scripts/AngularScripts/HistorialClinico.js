
myApp.controller('historialClinicoController', function ($scope, $http) {
    $scope.citas = [{ DoctorEncargado: "Fernando Rivera", FechaCita: "Hoy", Descripcion: "nada", ResultadosDeEstudios: "no pos paciente gg" }, { DoctorEncargado: "Fernando Rivera", FechaCita: "ayer", Descripcion: "nope", ResultadosDeEstudios: "pos paciente gg" }];
    $scope.receta = [{ nombre: "Medicamento a" }, { nombre: "Medicamento b" }];

    $scope.seleccionarCita = function (cita) {
        $scope.citaSeleccionada = cita;
    }

});