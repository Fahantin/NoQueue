angular.module("app")
    .controller("UsuarioController",
        function ($scope, $http) {
            $http.get("http://localhost:55076/api/Usuario")
                .success(function (data) {
                    $scope.retorno = data;
                });
        });