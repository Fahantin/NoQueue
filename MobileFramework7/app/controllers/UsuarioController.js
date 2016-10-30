angular.module("app")
    .controller("UsuarioController",
        function ($scope, $http) {
            $http.get("http://localhost:55076/api/v1/Usuario")
                .success(function (data) {
                    $scope.retorno = data;
                });
        });