angular.module("app")
    .controller("SenhaController",
        function ($scope, $http) {
            $http.get("http://no-queue.azurewebsites.net/api/v1/Senha")
                .success(function (data) {
                    $scope.retorno = data;
                });
        });