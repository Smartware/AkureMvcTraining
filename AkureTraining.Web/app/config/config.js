(function (window, $) {

    window.trainingApp.config(function ($locationProvider, $httpProvider, blockUIConfig, paginationTemplateProvider) {

        //    $locationProvider.html5Mode(false);
        //$locationProvider.hashPrefix('!');
        //$httpProvider.defaults.headers.common['X-Requested-With'] = //'XMLHttpRequest';

        blockUIConfig.message = 'Working...';
        blockUIConfig.delay = 0;
        paginationTemplateProvider.setPath(window.app.appUrl + 'scripts/dirPagination.tpl.html');
    });

    window.trainingApp.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {

        $stateProvider.state('app', {
            url: '/productList',
            templateUrl: '/Home/ProductList',
            controller: 'listProductCtrl',
            resolve: {
                //inject pList array object into listProductCtrl
                //$q angular promise
                pList: function ($http, $q) {

                    var deferred = $q.defer();

                    var apiUrl = 'api/productapi/list';
                    var postdata = {

                        keyword: '',
                        pageSize: 25,
                        pageIndex: 1
                    };

                    $http({
                        url: apiUrl,
                        method: 'POST',
                        data: postdata
                    }).then(function (response) {

                       
                        deferred.resolve(response.data);
                    }, function (error) {

                        deferred.resolve([]);
                    });

                    return deferred.promise;
                }
            }
        });

        $urlRouterProvider.otherwise('/productList');
    });

}(window, jQuery))