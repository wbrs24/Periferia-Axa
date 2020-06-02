$(document).ready(function () {
    var userLogged = localStorage.getItem('userLogged');
    valLogin(userLogged);
});

$("#logOut").click(function (e) {
    logOut();
});

function valLogin(content) {
    if (content != null || content != undefined) {
        var user = JSON.parse(content);
        $('#niLogin').hide();
        $('#nbdUserLogged').html(user.Name + ' ' + user.SureName);
        $('#niUserLogged').show();
        $('#niMarket').removeClass("hide").show();
        for (var i = 0; i < user.Rols.length; i++) {
            if (user.Rols[i].Description == 'Admin') {
                console.log('admin');
                $('#niSettings').removeClass("hide").show();
                break;
            }
        }
    }
}

function logOut() {
    $('#niLogin').show();
    $('#nbdUserLogged').html(' ');
    $('#niUserLogged').addClass("hide");
    $('#niMarket').addClass("hide");
    $('#niSettings').addClass("hide");
    localStorage.removeItem('userLogged');
    window.location.href = "/Home/Index";
}