angular.module("app")
    .controller("UsuarioController",
        function ($scope, $http) {
            $http.get("http://no-queue.azurewebsites.net/api/Usuario")
                .success(function (data) {
                    $scope.retorno = data;
                });
        });