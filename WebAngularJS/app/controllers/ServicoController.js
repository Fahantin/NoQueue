angular.module("app")
    .controller("ServicoController",
        function ($scope, $http) {
            $http.get("http://no-queue.azurewebsites.net/api/v1/Servico")
                .success(function (data) {
                    $scope.retorno = data;
                });
        });