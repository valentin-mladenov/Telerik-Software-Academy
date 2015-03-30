require(['jQurey', 'OAuth'], function() {
	'use strict';

	function getAuthorizationPromise() {
		OAuth.initialize('HGipp0Xb_RrWA6Lh0K9vcCYiaU0');
		var promise = OAuth.popup('twitter', {
			cache: true
		});

		return promise;
	}

	$('#authorization').on('click', function() {
		getAuthorizationPromise()
			.done(function() {
				console.log('Authenticated succesfully. Login cached.');
			})
			.fail(function(error) {
				console.log(error.toString());
			});
	});

	$('#get-user').on('click', function() {
		var username = $('#username').val(),
			messageCount = parseInt($('#count').val()),
			requestURL;

		requestURL = 'https://api.twitter.com/1.1/statuses/user_timeline.json?count=' + messageCount + '&screen_name=' + username;

		getAuthorizationPromise()
			.done(function(result) {
				result.get(requestURL)
					.done(function(response) {
						console.log('User messages recieved succesfully.');
						console.log(response);
					})
					.fail(function(error) {
						console.log(error);
					});
			});
	});
});