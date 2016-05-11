

angular.module('myApp').controller('AdministradorController', function ($scope, $http) {

    $scope.doctorSolicitantes = [
        { NumeroDoctor: 1, Cedula: 2, Nombre: "Fernando", PrimerApellido: "Rivera", SegundoApellido: "Lopez", Especialidad: "pos ser OP" }
    ];

    $scope.obtenerEspecialidades = function () {
        console.log("llamando a obtener especialidades");
        //"api/AdministradorApi/SolicitarEspecialidades"
        $http.get("api/ApiAdministrador/SolicitarEspecialidades")
            .success(function (data, status) {
                console.log(data);
                $scope.especialidades = data;
            })
            .error(function () {
                //alert("Lo sentimos, no se pudo contactar con el servidor :(");
            });
    }

    $scope.insertarEspecialidad = function () {
        $http.post("/Administrador/AgregarEspecialidadDoctor", { pNombreCategoria: $scope.EspecialidadInsertar })
            .success(function (data, status) {
                console.log(data);
                $scope.EspecialidadInsertar = "";
                $scope.errorEspecialidad = "";
                $scope.obtenerEspecialidades();

            })
            .error(function () {
                $scope.errorEspecialidad = "Error: no se pudo insertar la especialidad";
            });
    }





    


    $scope.obtenerCobros = function () {
        console.log('obteniendo cobros');
        $http.post('/Administrador/VerCobrosDoctores')
            .success(function (data, status) {
                console.log(data);
                $scope.cobros = data;
            })
            .error(function (data) {
                //alert("Cobros: Lo sentimos, no se pudo contactar con el servidor :(");
            });
    };



    $scope.realizarCobros = function () {
        console.log('realizando cobros');
        $http.post('/Administrador/RealizarCobro', { pCostoCita: $scope.cantidadCobro })
            .success(function (data, status) {
                console.log(data);
                $scope.obtenerCobros();
            })
            .error(function (data) {
                //alert("Cobros: Lo sentimos, no se pudo contactar con el servidor :(");
            });
    };



    $scope.obtenerSolicitudesDoctores = function () {
        console.log('buscando solicitudes doctores');
        $http.get('/Administrador/VerSolicitudesDoctores')
            .success(function (data, status) {
                console.log(data);
                $scope.doctorSolicitantes = data;
            })
            .error(function (data) {
                //alert("Cobros: Lo sentimos, no se pudo contactar con el servidor :(");
            });
    };


    $scope.aceptarDoctor = function (doctor) {
        //NumeroDoctor
        console.log('Aceptando Doctores');
        $http.post('/Administrador/AceptarDoctor', { pNumeroDoctor: doctor.NumeroDoctor })
            .success(function (data, status) {
                $scope.obtenerSolicitudesDoctores();
            })
            .error(function (data) {
                //alert("Cobros: Lo sentimos, no se pudo contactar con el servidor :(");
            });
    };



    /*
    {
    "NumeroDoctor": 88888888,
    "NombreDoctor": "Cristian",
    "PrimerApellido": "Rivera",
    "SegundoApellido": "Lopez",
    "TelefonoConsultorio": 2275,
    "DireccionConsultorio": "Asgard es mi hogar",
    "NombreEspecialidad": "Alergología",
    "NumeroTarjetaCredito": 1524
  }
    */




    /*
    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

    */



    //$scope.obtenerEspecialidades();





});
