(function (window, $) {

    var controllers = {};

    controllers.newProductCtrl = function () {
    };

    controllers.listProductCtrl = function ($scope, blockUI, $http, pList) {

        $scope.productList = pList;
        $scope.total = pList.length > 0 ? pList[0].totalCount : 0;
        $scope.itemsOnPage = 25;

        var blockSection = blockUI.instances.get('productBlockSection');

        $scope.pageChanged = function (url, newPage) {

            var postData = {
                keyword: '',
                pageIndex: newPage,
                PageSize: $scope.itemsOnPage
            };

            getProductList(url, postData);
        }

        function getProductList(link, postData) {

           // blockSection.start();
            $http({
                url: link,
                method: 'POST',
                data: postData
            }).then(function (response) {

                var prodList = response.data.result;
                $scope.productList = prodList;
                $scope.total = prodList.length > 0 ? prodList[0].totalCount : 0;
                //blockSection.stop();
            }, function (error) {

                alert(error);
               // blockSection.stop()
            });
        }
    };

    window.trainingApp.controller(controllers);
})(window, jQuery);