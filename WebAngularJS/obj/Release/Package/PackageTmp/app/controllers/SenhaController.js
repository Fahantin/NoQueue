angular.module("app")
    .controller("SenhaController",
        function ($scope, $http, $window) {

            $scope.retorno = [];

            $scope.Get = function () {
                $http.get("http://fahantin.azurewebsites.net/api/v1/Senha")
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
                    "IdServico": $scope.addIdServico,
                    "IdUsuario": $scope.addIdUsuario,
                    "SenhaUsuario": $scope.addSenhaUsuario
                }

                $http.post("http://fahantin.azurewebsites.net/api/v1/Senha", Objeto)
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
                    "IdServico": $scope.updIdServico,
                    "IdUsuario": $scope.updIdUsuario,
                    "SenhaUsuario": $scope.updSenhaUsuario
                }

                $http.put("http://fahantin.azurewebsites.net/api/v1/Senha/" + Objeto.Id, Objeto)
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
                $http.delete("http://fahantin.azurewebsites.net/api/v1/Senha/" + $scope.delId)
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
                    $http.delete("http://fahantin.azurewebsites.net/api/v1/Senha/" + r)
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
                $scope.updIdServico = r.idServico
                $scope.updIdUsuario = r.idUsuario
                $scope.updSenhaUsuario = r.senhaUsuario

                $scope.updHide = !$scope.updHide;
            }

            function Apagar(x) {
                if (x == 1) {
                    $scope.addIdServico= null;
                    $scope.addIdUsuario = null;
                    $scope.addSenhaUsuario = null;
                }
                else if (x == 2) {
                    $scope.updId = null;
                    $scope.updIdServico = null;
                    $scope.updIdUsuario = null;
                    $scope.updSenhaUsuario = null;
                }
                else if (x == 3) {
                    $scope.delId = null;
                }
            }
        });