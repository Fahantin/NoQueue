angular.module("app")
    .controller("SupermercadoController",
        function ($scope, $http) {
            $http.get("http://localhost:55076/api/Supermercado")
                .success(function (data) {
                    $scope.retorno = data;
                });
        });