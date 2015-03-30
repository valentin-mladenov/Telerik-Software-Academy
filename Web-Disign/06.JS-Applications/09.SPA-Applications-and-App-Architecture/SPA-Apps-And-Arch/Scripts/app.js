define(function () {
	require.config({
		paths: {
			'jquery': 'libs/jquery-2.1.1.min',
			'sammy': 'libs/sammy-0.7.4.min',
			'q': 'libs/q.min',
			'http-requester': 'http-requester',
			'validation-controller': 'validation-controller',
			'ui': 'ui-controller',
			'controller': 'controller'
		}
	});

	require(['jquery', 'sammy', 'controller'], function ($, Sammy, Controller) {
		var appController = new Controller('http://crowd-chat.herokuapp.com/posts');
		appController.setEventHandler();

		var app = Sammy('#wrapper', function () {
			this.get("#/login", function () {
				if (appController.isLoggedIn()) {
					window.location = '#/chat';
					return;
				}

				appController.loadLoginForm();
			});

			this.get("#/chat", function () {
				if (!appController.isLoggedIn()) {
					window.location = '#/login';
					return;
				}

				appController.loadChatBox();
			});
		});

		app.run('#/login');
	});
});