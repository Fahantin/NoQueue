angular.module("app")
    .controller("ServicoController",
        function ($scope, $http) {

            $scope.retorno = [];

            //var buscar = function () {
            $scope.ServicoGet = function () {
                $http.get("http://fahantin.azurewebsites.net/api/v1/Servico")
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
                    $scope.cadIdSupermercado = null;
                    $scope.cadIdTipoServico = null;
                    $scope.cadAtualSenha = null;
                    $scope.cadProxSenha = null;
                }
                else if (x == 2) {
                    $scope.updId = null;
                    $scope.updIdSupermercado = null;
                    $scope.updIdTipoServico = null;
                    $scope.updAtualSenha = null;
                    $scope.updProxSenha = null;
                }
                else if (x == 3) {
                    $scope.delId = null;
                }
            }

            $scope.ServicoGet();

            $scope.ServicoAdd = function () {

                var Servico = {
                    "IdSupermercado": $scope.cadIdSupermercado,
                    "IdTipoServico": $scope.cadIdTipoServico,
                    "AtualSenha": $scope.cadAtualSenha,
                    "ProxSenha": $scope.cadProxSenha
                }

                if (Servico.IdSupermercado != null && Servico.IdTipoServico != null) {

                    $http.post("http://fahantin.azurewebsites.net/api/v1/Servico", Servico)
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
                else {
                    alert("Valores Incorretos!");
                }
            }

            $scope.ServicoUpdate = function () {

                var Servico = {
                    "Id": $scope.updId,
                    "IdSupermercado": $scope.updIdSupermercado,
                    "IdTipoServico": $scope.updIdTipoServico,
                    "AtualSenha": $scope.updAtualSenha,
                    "ProxSenha": $scope.updProxSenha
                }

                $http.put("http://fahantin.azurewebsites.net/api/v1/Servico/" + $scope.updId, Servico)
                   .success(function (data) {
                       $scope.ServicoGet();
                       Apagar(2);
                       console.log("Alterado");
                   })
                   .error(function (erro) {
                       console.log("Erro");
                       console.log(erro);

                   })
                   .finally(function () { console.log("Alteração Finalizada"); });
            }

            $scope.ServicoDelete = function () {
                $http.delete("http://fahantin.azurewebsites.net/api/v1/Servico/" + $scope.delId)
                   .success(function (data) {
                       $scope.ServicoGet();
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