(function (window, $, angular) {
    window.app = {
        appUrl: ''
    };

    var akureTrainingApp = angular.bootstrap(window.document, ['blockUI', 'angularUtils.directives.dirPagination', 'ui.router']);

    window.trainingApp = akureTrainingApp;

})(window, jQuery, angular);