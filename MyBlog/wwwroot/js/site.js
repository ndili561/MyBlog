$(window).on('load', function () {
    setTimeout(function () {
        $(".loading").fadeOut("slow");
    }, 400)



   



});

$(document).ready(function () {

    $(window).scroll(function () {
        ($(this).scrollTop() > 300) ? $("a#scroll-to-top").addClass('visible') : $("a#scroll-to-top").removeClass('visible');
    });

    $("a#scroll-to-top").click(function () {
        $("html, body").animate({ scrollTop: 0 }, "slow");
        return false;
    });

});

function update() {
    $("#update").submit(function (event) {
        submitModalForm($(this), event);
    });
}

function objectifyForm(formArray) {//serialize data function
    var propertyNames = [];
    var returnArray = {};
    for (var i = 0; i < formArray.length; i++) {
        if (propertyNames.indexOf(formArray[i]['name']) === -1) {
            returnArray[formArray[i]['name']] = formArray[i]['value'];
            propertyNames.push(formArray[i]['name']);
        }

    }
    return returnArray;
}

function submitModalForm(form, event) {
    event.preventDefault();
    event.stopImmediatePropagation();
    var model = objectifyForm(form.serializeArray());
    $.ajax({
        url: $(form).attr('action'),
        type: "POST",
        headers: {
            'X-CSRF-Token': $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        data: model,
        success: function (result) {
            if (result.success) {
                displaySuccessMessage(result.message);
            } else {
                displayErrorMessage(result.message);
            }
        }
    });

    function displaySuccessMessage(message) {
        debugger;
        var type = 'success';
        displayMessage(message, type, type);
    }

    function displayErrorMessage(message) {
        var type = 'error';
        displayMessage(message, type, 'Error');
    }

    function displayWarningMessage(message) {
        var type = 'warning';
        displayMessage(message, type, type);
    }
    function displayInfoMessage(message) {
        var type = 'info';
        displayMessage(message, type, type);
    }
    function displayMessage(message, type, title) {
        toastr.options = {
            closeButton: true,
            progressBar: true,
            positionClass: 'toast-top-right',
            onclick: null
        };
        var $toast = toastr[type](message, title);
    }


}

