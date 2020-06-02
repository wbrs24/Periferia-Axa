var table; // use a global for the submit and return data rendering in the examples
var page = 1;
var rows = 5;
var prodEdit = { IdProduct: 0, Name: "", Description: "", Price: 0, Quantity: 0, State: ["default"], CreatedBy: 0 }
var action = 0;

$(document).ready(function () {
    console.log('Products Setting');
    getProducts();
});

function getProducts() {
    openSpinner('spinnerTable');
    $.ajax({
        async: true,
        type: 'GET',
        url: '/Products/GetAllProducts',
        data: {page: page, rows: rows},
        dataType: 'json',
        success: function (data) {
            //alert("View Model Passed Successfully");
            console.log(data);
            if (data.IsValid) {
                setTableData(data.ContentResult)
            }
            else {
                alert(data.Error.ErrorMessage);
            }
            closeSpinner('spinnerTable');
        },
        error: function (er) {
            alert("Something was wrong");
            closeSpinner('spinnerTable');
            console.log(er);
        }
    });
}

function setTableData(contentResult) {
    console.log('Set data into the table');
    var data = JSON.parse(contentResult);

    table = $('#productsTable').DataTable({
        data: data.rows,
        columns: [
            { title: 'Name', data: 'Name' },
            { title: 'Description', data: 'Description' },
            { title: 'Price', data: 'Price' },
            { title: 'Quantity', data: 'Quantity' },
            { title: 'State', data: 'State' },
            { title: 'CreatedBy', data: 'CreatedBy', visible: false }
        ],
        select: 'single',
        buttons: [
            {
                action: function (e, dt, node, config) {
                    action = 1;
                    prepareCreate();
                },
                text: 'Create'
            },
            {
                action: function (e, dt, node, config) {
                    action = 2;
                    var rowSelected = dt.rows('.selected').data();
                    console.log(rowSelected);
                    prepareEdit(rowSelected);
                },
                text: 'Edit'
            },
            {
                action: function (e, dt, node, config) {
                    action = 3;
                    var rowSelected = dt.rows('.selected').data();
                    console.log(rowSelected)
                    deleteProduct(rowSelected)
                },
                text: 'Remove'
            }
        ]
    });
    table.buttons().container()
        .appendTo($('.col-sm-12:eq(0)', table.table().container()));
}

function createProduct(prod) {
    openSpinner('spinner');
    var userLogged = localStorage.getItem('userLogged');
    var user = JSON.parse(userLogged);
    prod.CreatedBy = user.IdUser;

    $.ajax({
        async: true,
        type: 'POST',
        url: '/Products/CreateProduct',
        data: prod,
        dataType: 'json',
        success: function (data) {
            closeSpinner('spinner');
            console.log(data);
            if (data.IsValid) {
                table.clear().draw();
                var rw = JSON.parse(data.ContentResult);
                table.rows.add(rw.rows).draw();
                closeModal('modalEC'); 
            }
            else {
                alert(data.Error.ErrorMessage);
            }
        },
        error: function (er) {
            alert("Something was wrong");
            closeSpinner('spinner');
            console.log(er);
        }
    });
}

function deleteProduct(prod) {
    if (prod[0] == undefined)
        return;

    console.log('Delete Product');
    var p = prod[0];
    $.ajax({
        async: true,
        type: 'POST',
        url: '/Products/DeleteProduct',
        data: p,
        dataType: 'json',
        success: function (data) {
            console.log(data);
            if (data.IsValid) {
                table.clear().draw();
                var rw = JSON.parse(data.ContentResult);
                table.rows.add(rw.rows).draw();
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

function updateProduct(prod) {
    openSpinner('spinner');

    $.ajax({
        async: true,
        type: 'POST',
        url: '/Products/UpdateProduct',
        data: prod,
        dataType: 'json',
        success: function (data) {
            closeSpinner('spinner');
            console.log(data);
            if (data.IsValid) {
                table.clear().draw();
                var rw = JSON.parse(data.ContentResult);
                table.rows.add(rw.rows).draw();
                closeModal('modalEC'); 
            }
            else {
                alert(data.Error.ErrorMessage);
            }
        },
        error: function (er) {
            alert("Something was wrong");
            closeSpinner('spinner');
            console.log(er);
        }
    });
}

function prepareCreate() {
    console.log('Create Product');
    $("#editForm").trigger('reset');
    $(".modal-title").html("Creating Product");
    $("#modalEC").modal({ backdrop: 'static', keyboard: false });
} 

function prepareEdit(prod) {
    if (prod[0] == undefined)
        return;

    console.log('Update Product');
    prodEdit.IdProduct = prod[0].IdProduct;
    prodEdit.Name = prod[0].Name;
    prodEdit.Description = prod[0].Description;
    prodEdit.Price = prod[0].Price;
    prodEdit.Quantity = parseInt(prod[0].Quantity);
    prodEdit.State[0] = "" + prod[0].State;
    prodEdit.CreatedBy = prod[0].CreatedBy;
    var pdJson = JSON.stringify(prodEdit); 
    console.log(pdJson);

    $(".modal-title").html("Creating Product");
    $("#modalEC").modal({ backdrop: 'static', keyboard: false });
    $("#editForm").jsonToForm(prodEdit);
}    

$('#btnSaveEdit').click(function (e) {
    var $form = $("#editForm");
    var data = getFormData($form);
    console.log(data);
    if (action == 1) { createProduct(data);} else { updateProduct(data);}
});

function getFormData($form) {
    var unindexed_array = $form.serializeArray();
    var indexed_array = {};

    $.map(unindexed_array, function (n, i) {
        if (n['name'].indexOf("[]") > 0)
        { indexed_array[n['name'].replace("[]", "")] = n['value']; }
        else { indexed_array[n['name']] = n['value']; }
    });
    return indexed_array;
}

function closeModal(name) {
    $("#"+name).modal('hide');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
}

function closeSpinner(name) {
    $("#" + name).addClass('hide');
}

function openSpinner(name) {
    $("#" + name).removeClass('hide');
}