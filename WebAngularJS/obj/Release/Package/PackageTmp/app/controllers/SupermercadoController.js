angular.module("app")
    .controller("SupermercadoController",
        function ($scope, $http) {

            $scope.retorno = [];

            //var buscar = function () {
            $scope.SupermercadoGet = function () {
                $http.get("http://fahantin.azurewebsites.net/api/v1/Supermercado")
                   .success(function (data) {
                       console.log("Leitura");
                       $scope.retorno = data;
                   })
                   .error(function (erro) {
                       console.log("Erro");
                       console.log(erro);

                   })
                   .finally(function () { console.log("Leitura Finalizada"); });
            }

            function Apagar(x) {
                if (x == 1) {
                    $scope.cadNome = null;
                    $scope.cadLatitude = null;
                    $scope.cadLongitude = null;
                }
                else if (x == 2) {
                    $scope.updId = null;
                    $scope.updNome = null;
                    $scope.updLatitude = null;
                    $scope.updLongitude = null;
                }
                else if (x == 3) {
                    $scope.delId = null;
                }
            }

            $scope.SupermercadoGet();

            $scope.SupermercadoAdd = function () {

                var Supermercado = {
                    "Nome": $scope.cadNome,
                    "Lat": $scope.cadLatitude,
                    "Lng": $scope.cadLongitude
                }

                $http.post("http://fahantin.azurewebsites.net/api/v1/Supermercado", Supermercado)
                         .success(function (data) {
                             //$scope.retorno.add(Usuario);
                             //$scope.ServicoGet();
                             Apagar(1);
                             console.log("Criado");
                         })
                         .error(function (erro) {
                             console.log("Erro");
                             console.log(erro);

                         })
                         .finally(function () { console.log("Criação Finalizada"); });
            }


            $scope.SupermercadoUpdate = function () {

                var Supermercado = {
                    "Id": $scope.updId,
                    "Nome": $scope.updNome,
                    "Lat": $scope.updLatitude,
                    "Lng": $scope.updLongitude
                }

                $http.put("http://fahantin.azurewebsites.net/api/v1/Supermercado/" + $scope.updId, Supermercado)
                   .success(function (data) {
                       $scope.SupermercadoGet();
                       Apagar(2);
                       console.log("Alterado");
                   })
                   .error(function (erro) {
                       console.log("Erro");
                       console.log(erro);

                   })
                   .finally(function () { console.log("Alteração Finalizada"); });
            }

            $scope.SupermercadoDelete = function () {
                $http.delete("http://fahantin.azurewebsites.net/api/v1/Supermercado/" + $scope.delId)
                   .success(function (data) {
                       $scope.SupermercadoGet();
                       Apagar(3);
                       console.log("Deletado");
                   })
                   .error(function (erro) {
                       console.log("Erro");
                       console.log(erro);

                   })
                   .finally(function () { console.log("Delete Finalizado"); });
            }

        }/*]*/);