$(document).ready(function () {	

	// check if present authentication token
	if (getParameterByName('authToken') == 'Ivrea2015') {
		$.cookie('loggedin', 'loggedin');
	}

	// check the cookie, in case go to google.it
	if ($.cookie('loggedin') != 'loggedin') {
		document.location.href = 'http://www.google.it';
	};
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

ga('create', 'UA-58009688-1', 'auto');
ga('send', 'pageview');