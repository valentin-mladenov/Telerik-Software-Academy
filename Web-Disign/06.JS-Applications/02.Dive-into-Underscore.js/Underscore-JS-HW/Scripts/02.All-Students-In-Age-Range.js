(function () {
	'use strict';

	//check if running on Node.js
	if (typeof require !== 'undefined') {
		//load underscore if on Node.js
		_ = require('../../scripts/underscore.js');
	}

	var Student;

	Student = (function () {

		function Student(fName, lName,age) {
			this._firstName = fName;
			this._lastName = lName;
			this._age = age;

			return {
				FirstName: this._firstName,
				LastName: this._lastName,
				Age: this._age
			};
		}

		return Student;
	})();

	var students = [
		new Student('Gashnik', 'Pupeshov',18),
		new Student('Pencho', 'Minchev',39),
		new Student('Ganka', 'Lqnkova',24),
		new Student('Rajcho', 'Gruev',13),
		new Student('Gosho', 'Benev',19)
	];

	var allInAgeRange = [];
	function isInRange(item) {
		 return (item.Age >= 18) && (item.Age <= 24);
	};

	allInAgeRange = _.filter(students, isInRange);

	_.each(allInAgeRange, function (item) {
		delete item.Age;
		console.log(item);
	});
})();