angular.module("app")
    .controller("SupermercadoController",
        function ($scope, $http) {
            $http.get("http://no-queue.azurewebsites.net/api/Supermercado")
                .success(function (data) {
                    $scope.retorno = data;
                });
        });