$(document).ready(function () {
    $(window).bind("load", function () {
        $(".profile-photo").letterpic({
            fill: 'color',
            font: "Tahoma",
            fontColor: "#fff",
            fontSize: 0.4
        });
        $('.magnify').magnify();
    });
});