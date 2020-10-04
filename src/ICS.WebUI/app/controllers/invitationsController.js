'use strict';
app.controller('invitationsController', ['$scope', 'invitationsService', function ($scope, invitationsService) {

    $scope.invitations = [];

    invitationsService.getInvitations().then(
        function (results) {
            $scope.invitations = results.data;
        },
        function (error) {
            if (error.status === 401) {
                $location.path('/');
            }
    });

}]);