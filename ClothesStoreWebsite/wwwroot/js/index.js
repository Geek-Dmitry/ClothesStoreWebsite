$(document).ready(function () {
    //activate item in the header menu while scrolling
    var sections = $('section')
        , nav = $('nav')
        , nav_height = nav.outerHeight();

    $(window).on('scroll', function () {
        var cur_pos = $(this).scrollTop();

        sections.each(function () {
            var top = $(this).offset().top - nav_height,
                bottom = top + $(this).outerHeight();

            if (cur_pos >= top && cur_pos <= bottom) {
                nav.find('a').removeClass('active');
                sections.removeClass('active');

                $(this).addClass('active');
               /* nav.find('a[href="Index#' + $(this).attr('id') + '"]').addClass('active');*/
                nav.find('a[id="#' + $(this).attr('id') + '"]').addClass('active');
            }
        });
    });

    $("a.scroll").on("click", function (e) {
        e.preventDefault();

        var $el = $(this)
            , id = $el.attr('id');
        $("html, body").stop().animate({scrollTop: $(id).offset().top - 60}, 1500);
    });

    const animItems = document.querySelectorAll(".scroll-animation");

    if (animItems.length > 0) {
        window.addEventListener("scroll", animOnScroll)

        function animOnScroll(params) {
            for (let index = 0; index < animItems.length; index++) {
                const animItem = animItems[index];
                const animItemHeight = animItem.offsetHeight;
                const animItemOffSet = offset(animItem).top;
                const animStart = 4;

                let animItemPoint = window.innerHeight - animItemHeight / animStart;
                if (animItemHeight > window.innerHeight) {
                    let animItemPoint = window.innerHeight - window.innerHeight / animStart;
                }

                if ((scrollY > animItemOffSet - animItemPoint) && scrollY < (animItemOffSet + animItemHeight)) {
                    animItem.classList.add("active");
                }
            }
        }

        function offset(el) {
            const rect = el.getBoundingClientRect(),
                scrollLeft = window.scrollX || document.documentElement.scrollLeft,
                scrollTop = window.screenY || document.documentElement.scrollTop;
            return { top: rect.top + scrollTop, left: rect.left + scrollLeft }
        }
    }

    animOnScroll();

});