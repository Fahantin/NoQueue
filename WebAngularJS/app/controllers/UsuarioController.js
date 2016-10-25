angular.module("app")
    .controller("UsuarioController",
        function ($scope, $http) {
            $scope.retorno = [];

            //var buscar = function () {
            $scope.UsuarioGet = function () {
                $http.get("http://fahantin.azurewebsites.net/api/v1/Usuario")
                   .success(function (data) {
                       console.log("Sucesso no GET");
                       $scope.retorno = data;
                   })
                   .error(function (erro) {
                       console.log("Deu erro no GET");
                       console.log(erro);

                   })
                   .finally(function () { console.log("GET Finalizado"); });
            }

            function Apagar(x) {
                if (x == 1) {
                    $scope.cadLatitude = null;
                    $scope.cadLongitude = null;
                }
                else if (x == 2) {
                    $scope.updId = null;
                    $scope.updLatitude = null;
                    $scope.updLongitude = null;
                }
                else if (x == 3) {
                    $scope.delId = null;
                }
            }

            $scope.UsuarioGet();

            $scope.UsuarioAdd = function () {

                var Usuario = {
                    "Lat": $scope.cadLatitude,
                    "Lng": $scope.cadLongitude
                }

                $http.post("http://fahantin.azurewebsites.net/api/v1/Usuario", Usuario)
                   .success(function (data) {
                       //$scope.retorno.add(Usuario);
                       $scope.UsuarioGet();
                       Apagar(1);
                       console.log("POST Success");
                   })
                   .error(function (erro) {
                       console.log("Deu erro no POST");
                       console.log(erro);

                   })
                   .finally(function () { console.log("POST Finalizado"); });
            }

            $scope.UsuarioUpdate = function () {

                var Usuario = {
                    "Id": $scope.updId,
                    "Lat": $scope.updLatitude,
                    "Lng": $scope.updLongitude
                }

                $http.put("http://fahantin.azurewebsites.net/api/v1/Usuario/" + $scope.updId, Usuario)
                   .success(function (data) {
                       $scope.UsuarioGet();
                       Apagar(2);
                       console.log("POST Success");
                   })
                   .error(function (erro) {
                       console.log("Deu erro no POST");
                       console.log(erro);

                   })
                   .finally(function () { console.log("POST Finalizado"); });
            }

            $scope.UsuarioDelete = function () {
                $http.delete("http://fahantin.azurewebsites.net/api/v1/Usuario/" + $scope.delId)
                   .success(function (data) {
                       $scope.UsuarioGet();
                       Apagar(3);
                       console.log("POST Success");
                   })
                   .error(function (erro) {
                       console.log("Deu erro no POST");
                       console.log(erro);

                   })
                   .finally(function () { console.log("POST Finalizado"); });
            }

        }/*]*/);