angular.module("app")
    .controller("SenhaController",
        function ($scope, $http) {

            var buscar = function () {
                $http.get("http://localhost:55076/api/v1/Senha")
                       .success(function (data) {
                           $scope.retorno = data;
                       });
            }

            buscar();

            $scope.SenhaAdd = function () {

                var Senha = {
                    "IdServico": $scope.senhaIdServico,
                    "IdUsuario": $scope.senhaIdUsuario,
                    "SenhaUsuario": $scope.senhaUsuario
                }

                $http.post("http://localhost:55076/api/v1/Senha", Senha)
                   .success(function (data) {
                       buscar();
                   });
            }

            $scope.SenhaUpdate = function () {

                var Senha = {
                    "Id": $scope.senhaId,
                    "IdServico": $scope.senhaIdServico,
                    "IdUsuario": $scope.senhaIdUsuario,
                    "SenhaUsuario": $scope.senhaUsuario
                }

                $http.put("http://localhost:55076/api/v1/Senha/" + $scope.senhaId, Senha)
                   .success(function (data) {
                       buscar();
                   });
            }

            $scope.SenhaDelete = function () {
                $http.delete("http://localhost:55076/api/v1/Senha/" + $scope.senhaId)
                   .success(function (data) {
                       buscar();
                   });
            }

        }/*]*/);