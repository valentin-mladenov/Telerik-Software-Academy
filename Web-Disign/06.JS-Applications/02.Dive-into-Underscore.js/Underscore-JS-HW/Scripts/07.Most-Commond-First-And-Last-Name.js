(function () {
	'use strict';

	//check if running on Node.js
	if (typeof require !== 'undefined') {
		//load underscore if on Node.js
		_ = require('../../scripts/underscore.js');
	}

	var Human;

	Human = (function () {

		function Human(fname, lname) {
			this._fName = fname;
			this._lName = lname;

			return {
				FirstName: this._fName,
				LastName: this._lName
			};
		}

		return Human;
	})();

	var people = [
		new Human('Asya', 'Turgeneva'),
		new Human('Ivan', 'Mladenov'),
		new Human('William', 'Jhonson'),
		new Human('Isaac', 'Asimov'),
		new Human('Nikolay', 'Kolchev'),
		new Human('Georgy', 'Vazov'),
		new Human('Lois', 'Mladenov'),
		new Human('Nikolay', 'Bujold'),
		new Human('Georgy', 'Mladenov'),
		new Human('Nikolay', 'Shakespeare')
	];

	var mostFrequentFirstName,
		mostFrequentLastName;

	//I'm stuned from this chains?!?!
	mostFrequentFirstName = _.chain(people)
		.countBy('FirstName')
		.pairs()
		.max(_.last)
		.head()
		.value();

	mostFrequentLastName = _.chain(people)
		.countBy('LastName')
		.pairs()
		.max(_.last)
		.head()
		.value();

	console.log('Most frequent first name: ' + mostFrequentFirstName);
	console.log('Most frequent last name: ' + mostFrequentLastName);
})();