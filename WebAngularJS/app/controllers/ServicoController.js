angular.module("app")
    .controller("ServicoController",
        function ($scope, $http, $window) {

            $scope.retorno = [];

            $scope.Get = function () {
                $http.get("http://fahantin.azurewebsites.net/api/v1/Servico")
                   .success(function (data) {
                       console.log("Listado");
                       $scope.retorno = data;
                   })
                   .error(function (erro) {
                       console.log("Erro Get");
                       console.log(erro);

                   })
                   .finally(function () { console.log("Finalizado"); });
            }


            $scope.Get();


            $scope.Post = function () {

                var Objeto = {
                    "IdSupermercado": $scope.addIdSupermercado,
                    "IdTipoServico": $scope.addIdTipoServico,
                    "AtualSenha": 0,
                    "ProxSenha": 1
                }

                $http.post("http://fahantin.azurewebsites.net/api/v1/Servico", Objeto)
                   .success(function (data) {
                       $scope.Get();
                       Apagar(1);
                       console.log("Criado");
                   })
                   .error(function (erro) {
                       console.log("Erro Post");
                       console.log(erro);

                   })
                   .finally(function () { console.log("Finalizado"); });
            }


            $scope.Put = function () {

                var Objeto = {
                    "Id": $scope.updId,
                    "IdSupermercado": $scope.updIdSupermercado,
                    "IdTipoServico": $scope.updIdTipoServico,
                    "AtualSenha": $scope.updAtualSenha,
                    "ProxSenha": $scope.updProxSenha
                }

                $http.put("http://fahantin.azurewebsites.net/api/v1/Servico/" + Objeto.Id, Objeto)
                   .success(function (data) {
                       $scope.Get();
                       Apagar(2);
                       console.log("Atualizado");
                   })
                   .error(function (erro) {
                       console.log("Erro Put");
                       console.log(erro);

                   })
                   .finally(function () {
                       console.log("Finalizado");
                       $scope.updHide = !$scope.updHide;
                   });
            }


            $scope.Delete = function () {
                $http.delete("http://fahantin.azurewebsites.net/api/v1/Servico/" + $scope.delId)
                   .success(function (data) {
                       $scope.Get();
                       Apagar(3);
                       console.log("Deletado");
                   })
                   .error(function (erro) {
                       console.log("Erro Delete");
                       console.log(erro);

                   })
                   .finally(function () { console.log("Finalizado"); });
            }

            //NEWS---------------------------------------------

            $scope.BtnDeletar = function (r) {
                if (confirm('Tem Certeza?')) {
                    $http.delete("http://fahantin.azurewebsites.net/api/v1/Servico/" + r)
                       .success(function (data) {
                           $scope.Get();
                           Apagar(3);
                           console.log("Deletado");
                       })
                       .error(function (erro) {
                           console.log("Erro BtnDeletar");
                           console.log(erro);

                       })
                       .finally(function () { console.log("Finalizado"); });
                }
            }

            $scope.BtnAlterar = function (r) {
                $scope.updId = r.id
                $scope.updIdSupermercado = r.idSupermercado
                $scope.updIdTipoServico = r.idTipoServico
                $scope.updAtualSenha = r.atualSenha
                $scope.updProxSenha = r.proxSenha

                $scope.updHide = !$scope.updHide;
            }

            function Apagar(x) {
                if (x == 1) {
                    $scope.addIdSupermercado = null;
                    $scope.addIdTipoServico = null;
                    $scope.addAtualSenha = null;
                    $scope.addProxSenha = null;
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
        });