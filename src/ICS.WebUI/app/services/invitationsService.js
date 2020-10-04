'use strict';
app.factory('invitationsService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var invitationsServiceFactory = {};

    var _getInvitations = function () {
        return $http.get(serviceBase + 'api/v1/invitations').then(function (results) {
            return results;
        }, function (error) {
            return error;
        });
    };

    invitationsServiceFactory.getInvitations = _getInvitations;

    return invitationsServiceFactory;

}]);