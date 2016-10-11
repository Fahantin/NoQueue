angular.module("app")
    .controller("TipoServicoController",
        function ($scope, $http) {
            $http.get("http://localhost:55076/api/TipoServico")
                .success(function (data) {
                    $scope.retorno = data;
                });
        });