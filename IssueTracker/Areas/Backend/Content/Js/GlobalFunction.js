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

function displaySuccess() {
    $("#displaySuccess").show("blind");
    setTimeout(function () {
        $("#displaySuccess").hide("blind");
    }, 1000);

}

function displayFailed() {
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
                    displaySuccess();
                    callBack(response);
                } else if (response.Status == 1) {
                    displaySuccess();
                    callBack(response.Data);
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