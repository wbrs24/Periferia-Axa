console.log("login");
var loginModel = {
    "Email": "",
    "Password" : ""
};

$("#logForm").submit(function (e) {

    e.preventDefault(); // avoid to execute the actual submit of the form.

    //var form = $(this);
    //var url = form.attr('action');

    //$.ajax({
    //    type: "POST",
    //    url: url,
    //    data: form.serialize(), // serializes the form's elements.
    //    success: function (data) {
    //        alert(data); // show response from the php script.
    //    }
    //});
    singIn();

});

function singIn() {
    loginModel.Email = $('#inputEmail').val();
    loginModel.Password = $('#inputPassword').val();
    $('#msjError').html('');
    $.ajax({
        async: true,
        type: 'GET',
        url: '/Account/Login',
        data: loginModel,
        dataType: 'json',
        success: function (data) {
            //alert("View Model Passed Successfully");
            console.log(data);
            if (data.IsValid) {
                setLoggedUser(data.ContentResult)
            }
            else {
                setFaildLogin(data.Error);
            }
        },
        error: function (er) {
            alert("View Model faild" + er);  
            console.log(er);
        } 
    });
}

function setLoggedUser(ContentResult) {
    var user = JSON.parse(ContentResult);
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
    localStorage.setItem('userLogged', ContentResult);
    window.location.href = "/Home/Index";
} 

function setFaildLogin(error) {
    $('#msjError').html(error.ErrorMessage); 
} 
