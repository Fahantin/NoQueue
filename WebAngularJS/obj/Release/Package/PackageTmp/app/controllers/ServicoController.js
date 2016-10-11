angular.module("app")
    .controller("ServicoController",
        function ($scope, $http) {
            $http.get("http://no-queue.azurewebsites.net/api/Servico")
                .success(function (data) {
                    $scope.retorno = data;
                });
        });