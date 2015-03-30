// As far, as i understand that's all, that is needed in task 1.

(function () {
	var HTTPrequester;

	HTTPrequester = (function() {
		'use strict';

		function HTTPrequester() {

		}

		HTTPrequester.prototype.getJSON = function(requestURL, requestHeaders, callback) {
			return $.ajax({
				url: requestURL,
				type: 'GET',
				dataType: 'json',
				headers: requestHeaders,
				success: callback
			});
		};

		HTTPrequester.prototype.postJSON = function(requestURL, data, requestHeaders, callback) {
			return $.ajax({
				url: requestURL,
				type: 'POST',
				dataType: 'json',
				headers: requestHeaders,
				success: callback,
				data: data
			});
		};

		return HTTPrequester;
	})();

	return HTTPrequester;
});