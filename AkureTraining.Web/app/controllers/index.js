(function (window, $) {

    var controllers = {};

    controllers.newProductCtrl = function () {
    };

    controllers.listCtrl = function ($scope, blockUI, pList) {

        $scope.multiplier = 4 * 4;
    };

    window.trainingApp.controller(controllers);
})(window, jQuery);