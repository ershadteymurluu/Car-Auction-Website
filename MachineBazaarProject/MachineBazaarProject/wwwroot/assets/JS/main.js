/*// auction categories*/
//$(".auction-filter li a").click(function () {
//    $(".auction-filter li a").removeClass("selected");
//    $(this).addClass("selected");
//});

//$(".auction-filter li a").click(function () {
//    let targeted = $(this).attr("data-target");
//    $(".col-lg-3").hide();
//    if ($(".col-lg-3").hasClass(targeted)) {
//        $(`.col-lg-3.${targeted}`).show();
//    }
//});



//$(".auction-menu li").click(function () {
//    $(".auction-menu li").removeClass("clicked");
//    $(".auction-menu li i").addClass("d-none");
//    if (!$(this).hasClass("clicked")) {
//        $(this).addClass("clicked");
//        $(".clicked i").removeClass("d-none");
//    }
//});
$(document).ready(function () {
    $(".owl-carousel").owlCarousel({
        margin: 6,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
                nav: false
            },
            600: {
                items: 3,
                nav: false
            },
            1000: {
                items: 5,
                loop: false
            }
        }
    });
});
$(document).ready(function () {
    $(".owlCarousel").owlCarousel({
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
                nav: false
            },
            600: {
                items: 3,
                nav: false
            },
            1000: {
                items: 5,
                loop: false
            }
        }
    });
});
$(".comment-send").click(function () {
    location.reload();
});