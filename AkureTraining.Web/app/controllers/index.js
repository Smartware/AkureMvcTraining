(function (window, $) {

    var controllers = {};

    controllers.newProductCtrl = function () {
    };

    controllers.listProductCtrl = function ($scope, blockUI, pList) {

        $scope.productList = pList;
    };

    window.trainingApp.controller(controllers);
})(window, jQuery);