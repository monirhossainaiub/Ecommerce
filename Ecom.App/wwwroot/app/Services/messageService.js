/// <reference path="../app.js" />

// #region tostr message
let success = (message, title) => {
    toastr.success(message, title, { timeOut: 5000 });
}

let info = (message) => {
    toastr.info(message);
}

let added = (data) => {
    toastr.success(data + ' is added', 'Success', { timeOut: 5000 });
}

let updated = (data) => {
    toastr.success(data + ' is updated', 'Success', { timeOut: 5000 });
}

let deleted = (data) => {
    toastr.success(data + ' is deleted', 'Success', { timeOut: 5000 });
}

let error = (message) => {
    toastr.error(message, 'Error', { timeOut: 5000 });
}

// #endregion tostr message

// #region bootbox message 
let deleteconfirmationMessage = (data) => {
    bootbox.confirm({
        message: "Are you sure? You want to delete " + data + " permanently?",
        buttons: {
            confirm: {
                label: '<i class="fa fa-check"></i> Confirm',
                className: 'btn-success'
            },
            cancel: {
                label: '<i class="fa fa-times"></i> No',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            return result;
        }
    });
}
// #endregion bootbox message

var messageService = () => {
    return {
        success: success,
        info: info,
        added: added,
        deleted: deleted,
        error: error,
        updated: updated,
        deleteconfirmationMessage: deleteconfirmationMessage
    }
}


app.factory('messageService', messageService);