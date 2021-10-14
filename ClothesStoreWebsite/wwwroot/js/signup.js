$(document).ready(function () {
    $("#email-input").change(function () {
        var email = $(this).val();

        var url = "/User/IsUserExist?email=" + email;

        $("[name=signup-form__icons]").addClass("_hide");

        $.get(url).done(function (answer) {
            if (answer) {
                $(".icons-bad").removeClass("_hide");
            }
            else {
                $(".icons-good").removeClass("_hide");
            }
        });
    })
});