$(document).ready(function () {
    $(".spoiler__title").click(function(event) {
        
        if ($(".spoiler").hasClass("one")) {
            $(".spoiler__title").not($(this)).removeClass("active");
            $(".spoiler__description").not($(this).next()).slideUp(200);
        }

        $(this).toggleClass("active").next(".spoiler__description").slideToggle(200);
    });
});