myApp.controller('PacienteController', function ($scope, $http) {
    $http({
        url: 'api/ApiPaciente/EliminarCita',
        method:'POST',
        params: { pIdCita: 1 }
    });
});