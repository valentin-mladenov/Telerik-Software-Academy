(function () {
	'use strict';

	//check if running on Node.js
	if (typeof require !== 'undefined') {
		//load underscore if on Node.js
		_ = require('../../scripts/underscore.js');
	}

	var Student;

	Student = (function () {

		function Student(fName, lName, age,marks) {
			this._firstName = fName;
			this._lastName = lName;
			this._age = age;
			this._marks = marks;

			return {
				FirstName: this._firstName,
				LastName: this._lastName,
				Age: this._age,
				Marks:this._marks
			};
		}

		return Student;
	})();

	var students = [
		new Student('Gashnik', 'Pupeshov', 18,[5,4,6,2,3,6]),
		new Student('Pencho', 'Minchev', 39, [5, 4, 6, 6, 3, 6]),
		new Student('Ganka', 'Lqnkova', 24, [3, 4, 6, 2, 3, 2]),
		new Student('Rajcho', 'Gruev', 13, [5, 4, 2, 2, 3, 6]),
		new Student('Gosho', 'Benev', 19, [5, 4, 6, 2, 3, 4])
	];

	var high = function(stud) {
		var len = stud.Marks.length,
			highMark = 0,
			i;

		for (i = 0; i < len; i += 1) {
			highMark += stud.Marks[i];
		}
		return highMark / len;
	}

	var highestMarks;
	highestMarks = _.each(students, function (stud) {
		var innerHigh = high(stud);

		_.extend(stud, {
			HighestMarks: innerHigh
		});
	});

	var sortedHigh=_.sortBy(highestMarks, 'HighestMarks');
	
	console.log(_.last(sortedHigh));	
})();