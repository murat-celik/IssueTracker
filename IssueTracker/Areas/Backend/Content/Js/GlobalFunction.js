function startLoading(message) {
    $("#start-loading-message-text").text(message);
    $('#startLoading').modal('show');
}


function stopLoading() {
    $('#startLoading').modal('hide');
}

function displayMessage(message) {
    $("#display-message-text").text(message);
    $('#displayMessage').modal('show');
}

function displaySuccess(message) {
    if (message != 'undefined' && message != undefined) {
        $.notify(message, 'success');
    } else {
        $.notify("Success", 'success');
    }
   
   

    //if (message != 'undefined' && message != undefined) {
    //    if (message.length > 0) {
    //        console.log(message);
    //        console.log($("#display-success-message"));
    //        $("#display-success-message").html(message);
    //    }
    //} else {
    //    $("#display-success-message").html('Successful<i class="glyphicon glyphicon-ok"></i>');
    //}

    //$("#displaySuccess").show("blind");
    //setTimeout(function () {
    //    $("#displaySuccess").hide("blind");
    //}, 1000);

}

function displayFailed() {
    //$.notify(message, 'success');
    $("#displayFailed").show("blind");
    setTimeout(function () {
        $("#displayFailed").hide("blind");
    }, 1000);

}

var ajaxStatus = true; //  Discard Client Request When Previous Request Still Not Response
function ajax(url, data, callBack, loading, isHtml) {
    if (ajaxStatus = true) {

        ajaxStatus = false;

        if (loading != 'undefined' && loading != undefined) {
            if (loading == true) startLoading();
            else if (loading.length > 0) startLoading(loading);
        }

        $.ajax({
            method: "POST",
            url: url,
            data: $.isPlainObject(data) ? $.extend({ 'ajax': 1 }, data) : data + "&ajax=1",
            dataType: (isHtml != 'undefined' && isHtml == true) ? 'HTML' : 'JSON',
            complete: function () { ajaxStatus = true; stopLoading(); },
            success: function (response) {
                if (isHtml != 'undefined' && isHtml == true) {
                    callBack(response);
                    displaySuccess();
                } else if (response.Status == 1) {
                    callBack(response.Data);
                    displaySuccess(response.Message);
                } else {
                    if (response.Message != 'undefined' && response.Message != "") {
                        displayMessage(response.Message);
                    } else {
                        displayMessage('Your custom error message !');
                    }
                }

            },
            error: function (xhr) { ajaxStatus = true; stopLoading(); }
        });
    }
}