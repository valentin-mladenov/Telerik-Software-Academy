(function() {
	'use strict';

	//check if running on Node.js
	if (typeof require !== 'undefined') {
		//load underscore if on Node.js
		_ = require('../../scripts/underscore.js');
	}

	var Student;

	Student = (function() {

		function Student(fName, lName) {
			this._firstName = fName;
			this._lastName = lName;

			return {
				FirstName: this._firstName,
				LastName: this._lastName
			};
		}

		return Student;
	})();

	var students = [
		new Student('Gashnik', 'Pupeshov'),
		new Student('Pencho', 'Minchev'),
		new Student('Ganka', 'Lqnkova'),
		new Student('Rajcho', 'Gruev'),
		new Student('Gosho', 'Benev')
	];

	var firstBeforeLast = [];
	_.each(students, function(item) {
		if (item.FirstName < item.LastName) {
			firstBeforeLast.push(item);
		}
	});

	_.sortBy(firstBeforeLast, 'FirstName');

	_.each(firstBeforeLast, function (item) {
		console.log(item);
	});
})();