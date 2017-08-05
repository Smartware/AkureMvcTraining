(function (window, $, angular) {
    window.app = {
        appUrl: ''
    };

    var akureTrainingApp = angular.module("akureTrainingApp", ['blockUI', 'angularUtils.directives.dirPagination', 'ui.router']);

    window.trainingApp = akureTrainingApp;

})(window, jQuery, angular);