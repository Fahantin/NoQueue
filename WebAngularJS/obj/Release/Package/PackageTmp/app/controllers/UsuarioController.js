angular.module("app")
    .controller("UsuarioController",/*["$location", "$window",*/
        function ($scope, $http/*, $location, $window*/) {

            $http.get("http://localhost:55076/api/v1/Usuario")
                   .success(function (data) {
                       $scope.retorno = data;
                   });

            $scope.UsuarioAdd = function () {

                var usuario = {
                    "id": $scope.userId,
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

            $scope.UsuarioDel = function () {

                var id = $scope.userIdDel

                $http.delete("http://localhost:55076/api/v1/Usuario", 1)
                   .success(function (data) {
                       alert("Delete Successfull");
                       $scope.retorno = data;
                       console.log(data);
                   });
            }

        }/*]*/);

