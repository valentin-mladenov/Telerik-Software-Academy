(function () {
	'use strict';

	//check if running on Node.js
	if (typeof require !== 'undefined') {
		//load underscore if on Node.js
		_ = require('../../scripts/underscore.js');
	}

	var Animal;

	Animal = (function () {

		function Animal(type, species, legs) {
			this._type = type;
			this._species = species;
			this._legs = legs;

			return {
				Type: this._type,
				Species: this._species,
				Legs: this._legs
			};
		}

		return Animal;
	})();

	var animals = [
		new Animal('Dog','Mamal', 4),
		new Animal('Snake', 'Reptile', 0),
		new Animal('Cockroach', 'Insect', 6),
		new Animal('Gorilla', 'Mamal', 2),
		new Animal('Human', 'Mamal', 2),
		new Animal('Spider', 'Arachnid', 8),
		new Animal('Alligator', 'Reptile', 4),
		new Animal('Cat', 'Mamal', 4),
		new Animal('Bee', 'Insect', 6),
		new Animal('Scorpion', 'Arachnid', 6)
	];

	var animalsGrouped;
	animalsGrouped = _.groupBy(animals, 'Species');

	var animalsSorted=[];
	_.each(animalsGrouped, function(item) {
		animalsSorted.push(_.sortBy(item, 'Legs'));
	});

	_.each(animalsSorted, function (item) { console.log(item); });
})();