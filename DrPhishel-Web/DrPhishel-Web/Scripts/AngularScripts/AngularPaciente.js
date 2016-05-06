myApp.controller('PacienteController', function ($scope, $http) {
    $http({
        url: 'api/ApiPaciente/EliminarCita',
        method:'POST',
        params: { pIdCita: 1 }
    });

    $http({
        url: 'api/ApiPaciente/cambiarHoraCita',
        method: 'POST',
        params: { pCedulaPaciente: 604220930, pIdCita: 1, pFechaNueva: "10-10-2010", pHoraNueva: "04:30 p.m" }
    });

});