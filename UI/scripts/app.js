var app = angular.module("appFinandina", ['ngRoute']);

app.filter('roundUp', function () {
    return function (input) {
        var output = Math.ceil(input);
        return output;
    }
});
app.controller('mainCtrl', function ($scope, $http) {

    $scope.transactions = [];

    $scope.init = function () {
        swal({
            showLoaderOnConfirm: true,
            type: 'info',
            title: 'Cargando',
            text: 'Esto puede tomar unos segundos',
            showConfirmButton: false
        });

        $http.get(document.location.origin + '/' + 'api/Transactions', { headers: { 'Cache-Control': 'no-cache' } })
            .success(function (data) {
                $scope.transactions = data;
                swal.close();
            })
            .error(function () {
                swal({
                    showLoaderOnConfirm: true,
                    type: 'error',
                    title: 'Error',
                    text: 'Ha ocurrido un error, pruebe mas tarde',
                    showCancelButton: true,
                    showConfirmButton: false
                });
            });

    }

});

app.controller('TransactionCreateCtrl', function ($scope, $http) {

    $scope.clients = [];
    $scope.model = {};

    $scope.init = function () {
        swal({
            showLoaderOnConfirm: true,
            type: 'info',
            title: 'Cargando',
            text: 'Esto puede tomar unos segundos',
            showConfirmButton: false
        });

        $http.get(document.location.origin + '/' + 'api/Clients', { headers: { 'Cache-Control': 'no-cache' } })
            .success(function (data) {
                $scope.clients = data;
                swal.close();
            })
            .error(function () {
                swal({
                    showLoaderOnConfirm: true,
                    type: 'error',
                    title: 'Error',
                    text: 'Ha ocurrido un error, pruebe mas tarde',
                    showCancelButton: true,
                    showConfirmButton: false
                });
            });

    }

    $scope.save = function () {
        swal({
            title: "¿Esta seguro?",
            text: "Esta seguro de que desea agregar esta nueva transaccion",
            type: "warning", showCancelButton: true,
            confirmButtonText: "Si",
            cancelButtonText: "No",
            closeOnConfirm: false,
            closeOnCancel: false
        }, function (isConfirm) {
            if (isConfirm) {
                swal({
                    showLoaderOnConfirm: true,
                    type: 'info',
                    title: 'Guardando',
                    text: 'Esto puede tomar unos segundos',
                    showConfirmButton: false
                });
                $http.post(document.location.origin + '/' + 'api/Transactions', $scope.model)
                    .success(function () {
                        swal({
                            title: "Guardado!", text: "Se ha insertado la transaccion con exito", type: 'success', timer: 1000, showConfirmButton: false
                        });
                    })
                    .error(function () {
                        swal({
                            showLoaderOnConfirm: true,
                            type: 'error',
                            title: 'Error',
                            text: 'La cuenta de origen no tiene fondos suficientes!',
                            showCancelButton: true,
                            showConfirmButton: false
                        });
                    });
            }
            else {
                swal.close();
            }
        });
    }

});

app.config(function ($routeProvider) {
    $routeProvider
         .when('/', {
            templateUrl: '/Home/Home',
            controller: 'mainCtrl'
         })
        .when('/CreateTransaction', {
            templateUrl: '/Transaction/Create',
            controller: 'TransactionCreateCtrl'
        })
        .otherwise({
            templateUrl: '/Home/Home',
            controller: 'mainCtrl'
        })
});