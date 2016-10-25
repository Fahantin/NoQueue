angular.module("app")
    .controller("TipoServicoController",
        function ($scope, $http) {

            $scope.retorno = [];

            //var buscar = function () {
            $scope.TipoServicoGet = function () {
                $http.get("http://fahantin.azurewebsites.net/api/v1/TipoServico")
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
                }
                else if (x == 2) {
                    $scope.updId = null;
                    $scope.updNome = null;
                }
                else if (x == 3) {
                    $scope.delId = null;
                }
            }

            $scope.TipoServicoGet();

            $scope.TipoServicoAdd = function () {

                var TipoServico = {
                    "Nome": $scope.cadNome
                }

                $http.post("http://fahantin.azurewebsites.net/api/v1/TipoServico", TipoServico)
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

            $scope.TipoServicoUpdate = function () {

                var TipoServico = {
                    "Id": $scope.updId,
                    "Nome": $scope.updNome
                }

                $http.put("http://fahantin.azurewebsites.net/api/v1/TipoServico/" + $scope.updId, TipoServico)
                   .success(function (data) {
                       $scope.TipoServicoGet();
                       Apagar(2);
                       console.log("Alterado");
                   })
                   .error(function (erro) {
                       console.log("Erro");
                       console.log(erro);

                   })
                   .finally(function () { console.log("Alteração Finalizada"); });
            }

            $scope.TipoServicoDelete = function () {
                $http.delete("http://fahantin.azurewebsites.net/api/v1/TipoServico/" + $scope.delId)
                   .success(function (data) {
                       $scope.TipoServicoGet();
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