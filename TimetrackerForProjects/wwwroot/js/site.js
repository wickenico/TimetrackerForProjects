// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(document).ready(function () {
    // executes when HTML-Document is loaded and DOM is ready
    console.log("document is ready");

    var options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
    var today = new Date();
    document.getElementById("date").innerHTML = today.toLocaleDateString("de-DE", options);

    $(".card").hover(
        function () {
            $(this).addClass('shadow-lg').css('cursor', 'pointer');
        }, function () {
            $(this).removeClass('shadow-lg');
        }
    );

    // document ready  
});


