/// <reference path="jquery-1.10.2.js" />

function getAccessToken() {
    if (location.hash) {
        if (location.hash.split('access_token=')) {
            var accessToken = location.hash.split('access_token=')[1].split('&')[0];
            if (accessToken) {
                isUserRegistered(accessToken);
            }
        }
    }
}


function isUserRegistered(accessToken) {
    $.ajax({
        url: 'http://localhost:62513/api/Account/UserInfo',
        method: 'GET',
        headers: {
            'content-type': 'application/json',
            'Authorization': 'Bearer ' + accessToken
        },
        success: function (response) {
            if (response.HasRegistered) {
                sessionStorage.setItem('accessToken', accessToken);
                window.location.href = "Data/Data.html";
            }
            else {

                SignUpExternalUser(accessToken);
            }

        },
        error: function (jqXHR) {
            alert('twist1');
        }
    });
}


function SignUpExternalUser(accessToken) {
    $.ajax({
        url: 'http://localhost:62513/api/Account/RegisterExternal',
        method: 'POST',
        headers: {
            'content-type': 'application/json',
            'Authorization': 'Bearer ' + accessToken
        },
        success: function (response) {
            window.location.href = "http://localhost:62513/api/Account/ExternalLogin?provider=Google&response_type=token&client_id=self&redirect_uri=http%3A%2F%2Flocalhost%3A62513%2FLogin.html&state=TGnFBFspU52MlKyudox2grIKotfbDrLmjjrX3ewQeM01";

        },
        error: function (jqXHR) {
            alert(jqXHR);
        }
    });
}