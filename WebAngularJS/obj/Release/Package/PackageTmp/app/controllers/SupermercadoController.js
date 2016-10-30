angular.module("app")
    .controller("SupermercadoController",
        function ($scope, $http, $window) {

            $scope.retorno = [];

            $scope.Get = function () {
                $http.get("http://fahantin.azurewebsites.net/api/v1/Supermercado")
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
                    "Nome": $scope.addNome,
                    "Lat": $scope.addLatitude,
                    "Lng": $scope.addLongitude
                }

                $http.post("http://fahantin.azurewebsites.net/api/v1/Supermercado", Objeto)
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
                    "Nome": $scope.updNome,
                    "Lat": $scope.updLatitude,
                    "Lng": $scope.updLongitude
                }

                $http.put("http://fahantin.azurewebsites.net/api/v1/Supermercado/" + Objeto.Id, Objeto)
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
                $http.delete("http://fahantin.azurewebsites.net/api/v1/Supermercado/" + $scope.delId)
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
                    $http.delete("http://fahantin.azurewebsites.net/api/v1/Supermercado/" + r)
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
                $scope.updNome = r.nome
                $scope.updLatitude = r.lat
                $scope.updLongitude = r.lng

                $scope.updHide = !$scope.updHide;
            }

            function Apagar(x) {
                if (x == 1) {
                    $scope.addNome = null;
                    $scope.addLatitude = null;
                    $scope.addLongitude = null;
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
        });