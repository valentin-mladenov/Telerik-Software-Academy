/// <reference path="libs/jquery-2.1.1.min.js" />
/// <reference path="libs/handlebars.min.js"/>
/// <reference path="libs/require.js" />

(function() {
	require.config({
		paths: {
			handlebars: "libs/handlebars",
			jQuery: 'libs/jquery-2.1.1.min',
			ComboBox: 'ComboBox'
		}
	});

	require(['jQuery', 'ComboBox'], function () {

		// The creation
		var people = [
			{ id: 1, name: "Krasimir Radkov", age: 34, avatarUrl: "images/Gaco-Bacov.jpg" },
			{ id: 2, name: "Dimitar Rachkov", age: 50, avatarUrl: "images/Joro-Bekama.jpg" },
			{ id: 3, name: "Kamen Donev", age: 45, avatarUrl: "images/kamen-donev.jpg" }
		];


		var selectTemplate = document.getElementById('person-template');
		var templateString = selectTemplate.innerHTML;
		var template = Handlebars.compile(templateString);

		var comboBox = template({
			divs: people
		});

		document.getElementById('root').innerHTML += comboBox;
	});
}());