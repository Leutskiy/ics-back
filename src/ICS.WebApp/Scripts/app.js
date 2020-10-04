function ViewModel() {
    var self = this;

    _token = '';

    $.ajaxSetup({
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'Bearer ' + _token);
        }
    });

    var tokenKey = 'accessToken';

    self.result = ko.observable();

    //self.user = ko.observable();

    self.registerEmail = ko.observable();
    self.registerPassword = ko.observable();
    self.registerPassword2 = ko.observable();

    self.loginEmail = ko.observable();
    self.loginPassword = ko.observable();
    self.rememberMe = ko.observable();
    self.errors = ko.observableArray([]);

    self.invitations = ko.observableArray();
    self.editor = {
        id: ko.observable(""),
        name: ko.observable(""),
        visitGoal: ko.observable(""),
        alienName: ko.observable(""),
        visitCountry: ko.observable("")
    };

    self.getAllInvitations = function getAllInvitations() {

        _token = sessionStorage.getItem(tokenKey);
        //var token = sessionStorage.getItem(tokenKey);
        //var headers = {};
        //if (token) {
        //    headers.Authorization = 'Bearer ' + token;
        //}

        // beforeSend: function(xhr, settings) { xhr.setRequestHeader('Authorization', 'Bearer ' + token); } 

        $.ajax({
            type: 'GET',
            url: '/api/v1/invitations/invitation/a00264e4-e26b-56fb-904b-2b2df4d18f0e'
            //headers: headers
        }).done(function (data) {
            self.invitations.removeAll();
            for (var i = 0; i < data.length; i++) {
                self.invitations.push(data[i]);
            }
        }).fail(showError);
    };

    function showError(jqXHR) {

        self.result(jqXHR.status + ': ' + jqXHR.statusText);

        var response = jqXHR.responseJSON;
        if (response) {
            if (response.Message) self.errors.push(response.Message);
            if (response.ModelState) {
                var modelState = response.ModelState;
                for (var prop in modelState) {
                    if (modelState.hasOwnProperty(prop)) {
                        var msgArr = modelState[prop]; // expect array here
                        if (msgArr.length) {
                            for (var i = 0; i < msgArr.length; ++i) self.errors.push(msgArr[i]);
                        }
                    }
                }
            }
            if (response.error) self.errors.push(response.error);
            if (response.error_description) self.errors.push(response.error_description);
        }
    }

    self.callApi = function () {
        self.result('');
        self.errors.removeAll();

        var token = sessionStorage.getItem(tokenKey);
        var headers = {};
        if (token) {
            headers.Authorization = 'Bearer ' + token;
        }

        $.ajax({
            type: 'GET',
            url: '/api/values',
            headers: headers
        }).done(function (data) {
            self.result(data);
        }).fail(showError);
    };

    self.register = function () {
        self.result('');
        self.errors.removeAll();

        var data = {
            UserName: self.registerEmail(),
            Password: self.registerPassword(),
            ConfirmPassword: self.registerPassword2()
        };

        $.ajax({
            type: 'POST',
            url: '/api/account/register',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(data)
        }).done(function (data) {
            self.result("Done!");
        }).fail(showError);
    };

    self.login = function () {
        self.result('');
        self.errors.removeAll();

        var loginData = {
            grant_type: 'password',
            username: self.loginEmail(),
            password: self.loginPassword()
        };

        $.ajax({
            type: 'POST',
            url: '/token',
            data: loginData
        }).done(function (data) {

            // self.user(data.userName);

            // Cache the access token in session storage.
            sessionStorage.setItem(tokenKey, data.access_token);

            _token = sessionStorage.getItem(tokenKey);

            //var token = sessionStorage.getItem(tokenKey);
            //var headers = {};
            if (_token) {
                //headers.Authorization = 'Bearer ' + token;

                // self.getAllInvitations();

                //$.ajax({
                //    type: 'GET',
                //    url: '/Home/Page',
                //    headers: headers
                //}).done(function (resp) {
                //}).fail(showError);

                window.location.href = "/Home/Page";
            }

        }).fail(showError);
    };


    self.handleChangeClick = function (record) {

        sendAjaxRequest("GET", function (data) {
            self.editor.id = data.Id;
            self.editor.name = data.Name;
            self.editor.visitGoal = data.VisitGoal;
            self.editor.alienName = data.AlienName;
            self.editor.visitCountry = data.VisitCountry;

            self.isNew = false;
            self.displaySummary(false);
        }, record.Id);
    };

    self.handleCreateClick = function () {
        self.editor.name = "";
        self.editor.alienName = "";
        self.editor.visitGoal = "";
        self.editor.visitCountry = "";

        self.isNew = true;
        self.displaySummary(false);
    };

    self.logout = function () {
        // Log out from the cookie based logon.
        var token = sessionStorage.getItem(tokenKey);
        var headers = {};
        if (token) {
            headers.Authorization = 'Bearer ' + token;
        }

        $.ajax({
            type: 'POST',
            url: '/api/account/logout',
            headers: headers
        }).done(function (data) {
            // Successfully logged out. Delete the token.
            self.user('');
            sessionStorage.removeItem(tokenKey);
        }).fail(showError);
    };
}

var app = new ViewModel();
ko.applyBindings(app);