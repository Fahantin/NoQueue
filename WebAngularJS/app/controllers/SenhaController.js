angular.module("app")
    .controller("SenhaController",
        function ($scope, $http) {
            $http.get("http://localhost:55076/api/Senha")
                .success(function (data) {
                    $scope.retorno = data;
                });
        });