myApp.controller('AdministradorController', function ($scope, $http) {

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
                alert("Something went wrong");
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


    $scope.obtenerEspecialidades();


});