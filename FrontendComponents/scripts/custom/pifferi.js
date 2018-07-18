$(document).ready(function () {
    $.cookieBar({
        message: "Questo sito utilizza i cookie per raccogliere dati anonimi sulle visite.",
        acceptButton: true,
        acceptText: "Accetto",
        declineButton: true,
        declineText: "Disabilita i cookie"
    });
});




function getParameterByName(name) {
    var match = RegExp('[?&]' + name + '=([^&]*)').exec(window.location.search);
    return match && decodeURIComponent(match[1].replace(/\+/g, ' '));
}


/* Google Analytics */
(function (i, s, o, g, r, a, m) {
    i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
        (i[r].q = i[r].q || []).push(arguments)
    }, i[r].l = 1 * new Date(); a = s.createElement(o),
        m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
})(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');


if (jQuery.cookieBar('cookies')) {
    ga('create', 'UA-58009688-1', 'auto');
    ga('send', 'pageview');
}
