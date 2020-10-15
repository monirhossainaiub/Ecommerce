/// <reference path="../app.js" />
'use strict';

// #region tostr message
let success = (message, title) => {
    toastr.success(message, title, { timeOut: 5000 });
}

let info = (message) => {
    toastr.info(message);
}

let added = (data) => {
    toastr.success("<b><i>" + data + "</i></b>"  + ' is added', 'Success', { timeOut: 5000 });
}

let updated = (data) => {
    toastr.success("<b><i>" +data + "</i></b>" + ' is updated', 'Success', { timeOut: 5000 });
}

let deleted = (data) => {
    toastr.success("<b><i>" + data + "</i></b>"  + ' is deleted', 'Success', { timeOut: 5000 });
}

let error = (status) => {
    if (status == 404) {
        toastr.error("status code:" + status + ", The resource could not be found", 'Error', { timeOut: 5000 });
        return;
    }
    else if (status == 400) {
        toastr.error("status code:" + status + ", " , 'Error', { timeOut: 5000 });
        return;
    }
    else if (status == 500) {
        toastr.error("status code:" + status + ", " + " Unhandal error exception occured.", 'Error', { timeOut: 5000 });
        return;
    }

    toastr.error("status code:" + status, 'Error', { timeOut: 5000 });
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