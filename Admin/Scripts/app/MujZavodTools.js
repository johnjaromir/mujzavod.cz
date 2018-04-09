var MujZavod = MujZavod || {};


MujZavod.Confirm = function (msg, fncSuc, fncErr) {
    bootbox.confirm({
        message: msg,
        /*buttons: {
            confirm: {
                label: 'Yes',
                className: 'btn-success'
            },
            cancel: {
                label: 'No',
                className: 'btn-danger'
            }
        },*/
        callback: function (result) {
            if (result) {
                if ($.isFunction(fncSuc))
                    fncSuc();
                else {
                    if ($.isFunction(fncErr))
                        fncErr();
                }
            }
        }
    });
}


MujZavod.Alert = function (msg) {
    bootbox.alert(msg);
}

MujZavod.DoAction = function (action, fncSuc, fncErr) {
    $.post(action)
        .done(function (data) {
            if (data == "OK") {
                if ($.isFunction(fncSuc))
                    fncSuc();
                else
                    location.reload();
            }
            else {
                if ($.isFunction(fncErr))
                    fncErr();
                else
                    MujZavod.Alert(data);
            }
        })
        .fail(
            function (jqXHR, textStatus, errorThrown) {
                MujZavod.Alert(jqXHR.responseText);
            }
        );
}