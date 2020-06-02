console.log("register");
$(document).ready(function () {
    $('.datepicker').datepicker({
        format: 'yyyy/mm/dd',
        todayHighlight: true
    });
});
var registerModel = {
    "IdNumber": 0,
    "IdType": "",
    "Name": "",
    "SureName": "",
    "BirthDate": "",
    "ContactNumber": 0,
    "Email": "",
    "Password": "",
    "ConfirmPassword": ""
};

$("#registerForm").submit(function (e) {
    e.preventDefault(); 
    registerUser();
});

function registerUser() {

    registerModel.IdNumber = $('#inputIdNumber').val();
    registerModel.IdType = $('#inputIdType').val();
    registerModel.Name = $('#inputName').val();
    registerModel.SureName = $('#inputSurename').val();
    registerModel.BirthDate = $('#inputBirthDate').val();
    registerModel.ContactNumber = $('#inputContacNumber').val();
    registerModel.Email = $('#inputEmail').val();
    registerModel.Password = $('#inputPassword').val();
    registerModel.ConfirmPassword = $('#inputConfirmPassword').val();
    console.log(registerModel);
    $.ajax({
        async: true,
        type: 'POST',
        url: '/Account/Register',
        data: registerModel,
        dataType: 'json',
        success: function (data) {
            //alert("View Model Passed Successfully");
            console.log(data);
            if (data.IsValid) {
                setLoggedUser(data.ContentResult)
            }
            else {
                alert(data.Error.ErrorMessage);
            }
        },
        error: function (er) {
            alert("Something was wrong");
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
    localStorage.setItem('userLogged', ContentResult);
    window.location.href = "/Home/Index";
} 

function logOut() {
    $('#niLogin').show();
    $('#nbdUserLogged').html(' ');
    $('#niUserLogged').hide();
    $('#niMarket').hide();
    localStorage.removeItem('userLogged');
}


function setFaildLogin(error) {
    $('#msjError').html(error.ErrorMessage); 
} 
