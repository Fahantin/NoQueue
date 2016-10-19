angular.module("app")
    .controller("UsuarioController",
        function ($scope, $http) {

            $http.get("http://localhost:55076/api/v1/Usuario")
                       .success(function (data) {
                           $scope.retorno = data;
                       });

            $scope.UsuarioAdd = function () {

                var usuario = {
                    "lat": $scope.userLatitude,
                    "lng": $scope.userLongitude
                }

                $http.post("http://localhost:55076/api/v1/Usuario", usuario)
                   .success(function (data) {
                       $scope.retorno = data;
                       console.log(data);
                       //$window.location.reload();
                   });
            }

            $scope.UsuarioUpdate = function () {

                var usuario = {
                    "id": $scope.userId,
                    "lat": $scope.userLatitude,
                    "lng": $scope.userLongitude
                }

                $http.put("http://localhost:55076/api/v1/Usuario/" + $scope.userId, usuario)
                   .success(function (data) {
                       $scope.retorno = data;
                       console.log(data);
                   });
            }

            $scope.UsuarioDel = function () {
                $http.delete("http://localhost:55076/api/v1/Usuario/" + $scope.userId)
                   .success(function (data) {
                       $scope.retorno = data;
                       console.log(data);
                   });
            }

        }/*]*/);