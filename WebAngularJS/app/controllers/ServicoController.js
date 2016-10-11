angular.module("app")
    .controller("ServicoController",
        function ($scope, $http) {
            $http.get("http://localhost:55076/api/Servico")
                .success(function (data) {
                    $scope.retorno = data;
                });
        });