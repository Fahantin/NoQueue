angular.module("app")
    .controller("TipoServicoController",
        function ($scope, $http) {
            $http.get("http://no-queue.azurewebsites.net/api/v1/TipoServico")
                .success(function (data) {
                    $scope.retorno = data;
                });
        });